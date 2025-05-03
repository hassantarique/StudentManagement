using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ElevenLabsApp.Models;

namespace ElevenLabsApp.Main
{
    public static class AudioGenerationService
    {
        public static async Task GenerateFromExcelAsync(string excelPath, string outputPath)
        {
            List<SpeechRequest> requests;

            try
            {
                requests = ExcelReader.ReadRequests(excelPath); // Read requests from Excel
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading Excel file: {ex.Message}");
            }

            foreach (var request in requests)
            {
                try
                {
                    Console.WriteLine($"🔊 Generating audio for: \"{Truncate(request.Text, 40)}...\"");

                    // Call ElevenLabs API to generate speech
                    HttpResponseMessage response = await ElevenLabsClient.GenerateSpeechAsync(request);

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"❌ Failed to generate audio for \"{Truncate(request.Text, 30)}...\": {response.ReasonPhrase}");
                        continue;
                    }

                    byte[] audioData = await AudioSaver.DownloadAudioFromStreamAsync(response);

                    // Create a safe file name for the output
                    string filename = CreateSafeFilename(request.Text);

                    // Save the audio to the file system
                    await AudioSaver.SaveAudioAsync(request.VoiceId, audioData, outputPath, filename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Failed to generate audio for \"{Truncate(request.Text, 30)}...\": {ex.Message}");
                }
            }
        }

        // Helper method to create a safe filename
        private static string CreateSafeFilename(string input)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                input = input.Replace(c, '_');
            }
            return input.Length > 30 ? input.Substring(0, 30) : input;
        }

        // Helper method to truncate the text for displaying in logs
        private static string Truncate(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Length <= maxLength ? text : text.Substring(0, maxLength);
        }
    }
}
