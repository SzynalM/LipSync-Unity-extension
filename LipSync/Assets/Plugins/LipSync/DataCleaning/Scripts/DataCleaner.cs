using LipsyncUtility;
using UnityEngine;
using DataCleaning.Utility;

namespace DataCleaning
{
    public class DataCleaner
    {
        private DiphthongSimplifier diphthongSimplifier = new DiphthongSimplifier();
        private PhonemeFileLoader phonemeFileLoader = new PhonemeFileLoader();
        private WordRemover wordRemover = new WordRemover();
        private InsignificantPhonemeRemover insignificantPhonemeRemover = new InsignificantPhonemeRemover();

        public string[] CleanRawPhonemeData(string phonemeFilePath)
        {
            string[] rawPhonemeDataFromFile = phonemeFileLoader.LoadRawPhonemeData(phonemeFilePath);

            return
                insignificantPhonemeRemover.ExctractSignificantPhonemes(
                    diphthongSimplifier.SimplifyDiphthongs(
                        wordRemover.RemoveWordsAtBeginningsOfLines(
                            rawPhonemeDataFromFile)));
        }
    }
}
