namespace VisemeExtractor
{
    public class VisemeExtractor_Main
    {
        private DiphthongSimplifier diphthongSimplifier = new DiphthongSimplifier();
        private PhonemeFileLoader phonemeFileLoader = new PhonemeFileLoader();

        private string stringToProcess = "";

        public void ExtractVisemes(string phonemeFilePath)
        {
            stringToProcess = diphthongSimplifier.SimplifyDiphthongs(phonemeFileLoader.LoadPhonemeFileContent(phonemeFilePath));
            UnityEngine.Debug.Log("String to process\n" + stringToProcess);
        }
    } 
}
