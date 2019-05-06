using System.Collections.Generic;
using LipsyncUtility;

namespace VisemeExtractor
{
    public class DiphthongSimplifier
    {
        private Dictionary<string, string> diphthongToPhonemesDictionary = new Dictionary<string, string>()
        {
            {"AW","AA UH"},
            {"AY", "AA IY"},
            {"ER", "UH R"},
            {"EY", "EH IY"},
            {"OW", "AO UH"},
            {"OY", "AO IY"}
        };

        public string[] SimplifyDiphthongs(string[] textLines)
        {
            for (int i = 0; i < textLines.Length; i++)
            {
                string[] textWords = textLines[i].Split(' ');
                for (int j = 0; j < textWords.Length; j++)
                {
                    if (diphthongToPhonemesDictionary.ContainsKey(textWords[j]))
                    {
                        textWords[j] = diphthongToPhonemesDictionary[textWords[j]];
                    }
                }
                textLines[i] = textWords.BuildStringFromArray(" ");
            }
            return textLines;
        }
    }
}
