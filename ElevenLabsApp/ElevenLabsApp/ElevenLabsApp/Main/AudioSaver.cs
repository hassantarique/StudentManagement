using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ElevenLabsApp.Main
{
    public static class AudioSaver
    {
        // Method to save the audio data as a file on the disk
        public static async Task SaveAudioAsync(string voiceId, byte[] audioData, string outputPath, string fileName)
        {
            try
            {
                // Ensure the output directory exists
                if (!Directory.Exists(outputPath))
                    Directory.CreateDirectory(outputPath);

                // Construct a safe file path with voice ID and filename
                string fullPath = Path.Combine(outputPath, $"{SanitizeFileName(fileName)}_{voiceId}.mp3");

                // Save the audio data to the file system
                await File.WriteAllBytesAsync(fullPath, audioData);

                Console.WriteLine($"✅ Audio saved successfully: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Failed to save audio: {ex.Message}");
            }
        }

        // Method to download the audio content from the HTTP response
        public static async Task<byte[]> DownloadAudioFromStreamAsync(HttpResponseMessage response)
        {
            try
            {
                // Ensure the response is valid and read the content as byte array
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    throw new Exception("Failed to download audio from stream. API response was not successful.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error downloading audio: {ex.Message}");
            }
        }

        // Helper method to sanitize file names by removing invalid characters
        private static string SanitizeFileName(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }
            return name;
        }
    }
}
