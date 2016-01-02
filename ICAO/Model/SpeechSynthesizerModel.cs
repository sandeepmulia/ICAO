using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ICAO.Model
{
    public class SpeechSynthesizerModel
    {
        private SpeechSynthesizer _speech;
        private static readonly Lazy<SpeechSynthesizerModel> _instance = new Lazy<SpeechSynthesizerModel>(() => new SpeechSynthesizerModel(), true);
        

        public static SpeechSynthesizerModel Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private SpeechSynthesizerModel()
        {
            _speech = new SpeechSynthesizer();
            _speech.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Adult);
            _speech.Rate = 0;
        }

        public void Speak(string text)
        {
            _speech.SpeakAsync(text);
        }
    }
}
