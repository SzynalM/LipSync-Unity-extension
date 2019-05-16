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
            try
            {
                LoadingBarViewer.Instance.SetNextPhase();
                string[] rawPhonemeDataFromFile = phonemeFileLoader.LoadRawPhonemeData(phonemeFilePath);

                return
                    insignificantPhonemeRemover.ExctractSignificantPhonemes(
                        diphthongSimplifier.SimplifyDiphthongs(
                            wordRemover.RemoveWordsAtBeginningsOfLines(
                                rawPhonemeDataFromFile)));
            }
            catch(System.Exception e)
            {
                Debug.LogError("Data cleaning failed\n" + e);
                return null;
            }
        }
    }
}
