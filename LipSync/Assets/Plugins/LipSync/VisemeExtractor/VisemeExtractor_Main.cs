namespace VisemeExtractor
{
    public class VisemeExtractor_Main
    {
        private DiphthongSimplifier diphthongSimplifier = new DiphthongSimplifier();
        private PhonemeFileLoader phonemeFileLoader = new PhonemeFileLoader();

        private string stringToProcess = "";

        public void ExtractVisemes()
        {
            stringToProcess = diphthongSimplifier.SimplifyDiphthongs(phonemeFileLoader.LoadPhonemeFileContent());
        }
    } 
}
