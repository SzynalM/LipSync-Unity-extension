using System.Text.RegularExpressions;

namespace DataCleaning
{
    public class InsignificantPhonemeRemover
    {
        public string[] ExctractSignificantPhonemes(string[] phonemeData)
        {
            string phonemesInCurrentLine = "";
            for(int i = 0; i < phonemeData.Length;i++)
            {
                phonemesInCurrentLine = phonemeData[i];
                for(int j = 0; j < InsignificantPhonemes.Phonemes.Length; j++)
                {
                    phonemesInCurrentLine = Regex.Replace(phonemesInCurrentLine, $@"\b{InsignificantPhonemes.Phonemes[j]}\b", "");
                }
                phonemeData[i] = phonemesInCurrentLine;
            }
            return phonemeData;
        }
    } 
}
