using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ElevenLabsApp.Models;
using Newtonsoft.Json;

namespace ElevenLabsApp.Main
{
    public static class ElevenLabsClient
    {
        private static readonly string ApiKey = "sk_8e546778f1ea6cea96ad4eda9f1b8415c6a84eff15e289f2"; // Insert your ElevenLabs API key
        private static readonly string ApiUrl = "https://api.elevenlabs.io/v1/text-to-speech/";

        public static async Task<HttpResponseMessage> GenerateSpeechAsync(SpeechRequest request)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("xi-api-key", ApiKey);

                var payload = new
                {
                    text = request.Text,
                    model_id = request.Model,
                    voice_settings = new
                    {
                        stability = request.Stability,
                        similarity_boost = request.Similarity,
                        style = request.Exaggeration,
                        use_speaker_boost = request.Boost
                    }
                };

                var jsonContent = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var fullUrl = $"{ApiUrl}{request.VoiceId}?output_format=mp3_44100_128";

                var response = await client.PostAsync(fullUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API call failed. Status: {response.StatusCode}, Error: {error}");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error communicating with ElevenLabs API", ex);
            }
        }
    }
}
