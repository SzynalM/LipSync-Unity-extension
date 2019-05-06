using LipsyncUtility;
using System.Collections.Generic;
using UnityEngine;

namespace VisemeExtractor
{
    public class VisemeExtractor_Main
    {
        private DiphthongSimplifier diphthongSimplifier = new DiphthongSimplifier();
        private PhonemeFileLoader phonemeFileLoader = new PhonemeFileLoader();
        private WordRemover wordRemover = new WordRemover();
        private InsignificantPhonemeRemover insignificantPhonemeRemover = new InsignificantPhonemeRemover();

        private string stringToProcess = "";

        public void ExtractVisemes(string phonemeFilePath)
        {
            string[] phonemeLines = CleanRawPhonemeData(phonemeFileLoader.LoadRawPhonemeData(phonemeFilePath));
            stringToProcess = phonemeLines.BuildStringFromArray("\n");
            Debug.Log("String to process\n" + stringToProcess);
        }

        private string[] CleanRawPhonemeData(string[] rawPhonemeDataFromFile)
        {
            return
                insignificantPhonemeRemover.ExctractSignificantPhonemes(
                    diphthongSimplifier.SimplifyDiphthongs(
                        wordRemover.RemoveWordsAtBeginningsOfLines(
                            rawPhonemeDataFromFile)));
        }

        private Dictionary<string, Viseme> phonemeToVisemeDictionary = new Dictionary<string, Viseme>()
        {
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
