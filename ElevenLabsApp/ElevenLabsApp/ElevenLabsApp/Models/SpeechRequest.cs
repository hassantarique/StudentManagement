namespace ElevenLabsApp.Models
{
    public class SpeechRequest
    {
        public string Text { get; set; } = string.Empty;
        public string VoiceId { get; set; } = string.Empty;
        public string Model { get; set; } = "eleven_multilingual_v2"; // Default model
        public float Stability { get; set; } = 0.75f;
        public float Similarity { get; set; } = 0.75f;
        public float Exaggeration { get; set; } = 0.0f;
        public bool Boost { get; set; } = false;
    }
}
