using System.Collections.Generic;

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

        public string SimplifyDiphthongs(string textToSimplify)
        {
            textToSimplify = textToSimplify.Trim();
            string[] splitText = textToSimplify.Split(' ');
            for(int i = 0; i < splitText.Length; i++)
            {
                if (diphthongToPhonemesDictionary.ContainsKey(splitText[i]))
                {
                    splitText[i] = diphthongToPhonemesDictionary[splitText[i]];
                }
            }
            textToSimplify = RecomposeStringFromArray(splitText);
            return textToSimplify;
        }

        private string RecomposeStringFromArray(string[] stringArray)
        {
            string output = "";
            for(int i = 0; i < stringArray.Length; i++)
            {
                if(i > 0)
                {
                    output += " ";
                }
                output += stringArray[i];
            }
            return output;
        }
    }
}
