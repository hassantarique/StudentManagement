using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using OfficeOpenXml;

using ElevenLabsApp.Models;
using System.ComponentModel;

namespace ElevenLabsApp.Main
{
    public static class ExcelReader
    {

        public static List<SpeechRequest> ReadRequests(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Excel file not found.", filePath);

            var requests = new List<SpeechRequest>();

            using var package = new ExcelPackage(new FileInfo(filePath));
            var worksheet = package.Workbook.Worksheets[0];

            int row = 2;
            while (!string.IsNullOrWhiteSpace(worksheet.Cells[row, 1]?.Text))
            {
                try
                {
                    var request = new SpeechRequest
                    {
                        Text = worksheet.Cells[row, 1].Text.Trim(),
                        VoiceId = worksheet.Cells[row, 2].Text.Trim(),
                        Model = worksheet.Cells[row, 3].Text.Trim(),
                        Stability = ParseFloat(worksheet.Cells[row, 5].Text, 0.75f),
                        Similarity = ParseFloat(worksheet.Cells[row, 6].Text, 0.75f),
                        Exaggeration = ParseFloat(worksheet.Cells[row, 7].Text, 0.0f),
                        Boost = ParseBool(worksheet.Cells[row, 8].Text)
                    };

                    requests.Add(request);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to parse row {row}: {ex.Message}");
                }

                row++;
            }

            return requests;
        }

        private static float ParseFloat(string input, float fallback)
        {
            return float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var result)
                ? result
                : fallback;
        }

        private static bool ParseBool(string input)
        {
            return bool.TryParse(input, out var result) && result;
        }
    }
}
