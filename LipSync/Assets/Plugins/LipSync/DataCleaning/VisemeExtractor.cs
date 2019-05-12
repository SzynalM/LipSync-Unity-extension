using System.Collections.Generic;
using UnityEngine;

namespace VisemeExtraction
{
    public class VisemeExtractor
    {
        private string[] phonemesInWord;
        private string phonemes = "";
        private string timings = "";

        private Dictionary<string, Viseme> phonemeToVisemeDictionary;

        public List<Viseme> ExtractVisemes(string[] text)
        {
            List<Viseme> visemes = new List<Viseme>();
            Queue<Viseme> visemesQueue = new Queue<Viseme>();

            for (int i = 0; i < text.Length; i++)
            {
                text[i] = text[i].Substring(1);
                phonemes = text[i].Split(')')[0].Trim();
                timings = text[i].Split(')')[1].Trim();
                phonemesInWord = phonemes.Split(' ');

                for (int j = 0; j < phonemesInWord.Length; j++)
                {
                    phonemeToVisemeDictionary = CreateDictionary(); //to lose references 
                    Viseme currentViseme = phonemeToVisemeDictionary[phonemesInWord[j]];
                    GetVisemeTimings(currentViseme, int.Parse(timings.Split(':')[0]), int.Parse(timings.Split(':')[1]), phonemesInWord.Length, j);
                    visemesQueue.Enqueue(currentViseme);
                    visemes.Add(currentViseme);
                }
            }
            Debug.Log("Visemes extracted");
            return visemes;
        }

        private void GetVisemeTimings(Viseme viseme, int startTime, int endTime, int amountOfPhonemesInWord, int index)
        {
            int interval = endTime - startTime;
            int visemeDuration = Mathf.RoundToInt(interval / amountOfPhonemesInWord);
            viseme.StartTime = startTime + visemeDuration * index;
            viseme.EndTime = startTime + visemeDuration * (index + 1);
        }

        private Dictionary<string, Viseme> CreateDictionary()
        {
            return new Dictionary<string, Viseme>(){
                    {"AA", new Viseme_AA(1, 0.75f) },
                    {"AE", new Viseme_AA(0.75f, 1) },
                    {"AH", new Viseme_AA(1, 1) },
                    {"AO", new Viseme_OO(0.60f, 0.9f) },
                    {"B", new Viseme_BM(0.6f, 1) },
                    {"CH", new Viseme_CH(1, 0.85f) },
                    {"D", new Viseme_IH(0.3f, 0.85f) },
                    {"DH", new Viseme_Mixed(new Viseme_FV(0.5f, 1), new Viseme_AA(0.12f, 1)) },
                    {"EH", new Viseme_EE(1, 0.8f) },
                    {"F", new Viseme_FV(0.6f, 1) },
                    {"G", new Viseme_EE(0.44f, 1) },
                    {"HH", new Viseme_AA(0.15f, 0.85f) }, //insignificant (inherits from previous and next)
                    {"IH", new Viseme_EE(0.6f, 0.8f) },
                    {"IY", new Viseme_IH(0.7f, 1) },
                    {"JH", new Viseme_CH(1, 1) },
                    {"K", new Viseme_AA(0.15f, 0.85f) }, //insignificant (inherits from previous and next)
                    {"L", new Viseme_Mixed(new Viseme_OO(0.22f, 0.8f), new Viseme_AA(0.3f, 0.8f)) },
                    {"M", new Viseme_BM(0.6f, 1) },
                    {"N", new Viseme_AA(0.15f, 0.85f) }, //insignificant (inherits from previous and next)
                    {"NG", new Viseme_EE(0.3f, 0.85f)  }, //insignificant (inherits from previous)
                    {"P",  new Viseme_BM(0.5f, 1)},
                    {"R", new Viseme_R(0.58f, 0.8f) },
                    {"S", new Viseme_R(0.48f, 0.8f) },
                    {"SH", new Viseme_CH(0.64f, 0.8f) },
                    {"SIL", new Viseme_Silence() },
                    {"T", new Viseme_EE(0.3f, 1) }, //insignificant
                    {"TH", new Viseme_R(0.3f, 1) }, //insignificant
                    {"UH", new Viseme_UU(1, 1) },
                    {"UW", new Viseme_UU(0.6f, 1) },
                    {"V", new Viseme_FV(0.75f, 1) },
                    {"W", new Viseme_UU(0.60f, 1) },
                    {"Z", new Viseme_EE(0.3f, 0.7f) },
                    {"ZH", new Viseme_Mixed(new Viseme_EE(0.4f, 0.9f), new Viseme_CH(0.53f, 0.9f)) }
                };
        }
    }
}