using LipsyncUtility;
using System.Collections.Generic;

namespace DataCleaning
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
            try
            {
                for (int i = 0; i < textLines.Length; i++)
                {
                    string[] textWords = textLines[i].Split(' ');
                    for (int j = 0; j < textWords.Length; j++)
                    {
                        if (j == 0)
                        {
                            if (diphthongToPhonemesDictionary.ContainsKey(textWords[j].Trim().Substring(1)))
                            {
                                textWords[j] = "(" + diphthongToPhonemesDictionary[textWords[j].Trim().Substring(1)];
                            }
                        }
                        else
                        {
                            if (diphthongToPhonemesDictionary.ContainsKey(textWords[j].Trim()))
                            {
                                textWords[j] = diphthongToPhonemesDictionary[textWords[j].Trim()];
                            }  
                        } 
                    }
                    textLines[i] = textWords.BuildStringFromArray(" ");
                }
                return textLines;
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogError("Diphthong simplifier failed\n" + e);
                return null;
            }
        }
    }
}
