using PhonemeExtractor.SetupWindow;
using System.IO;

namespace VisemeExtractor
{
    public class PhonemeFileLoader
    {
        DataManager dataManager = new DataManager();
        string pathToPhonemeFile = "";
        string loadedText = "";

        public string LoadPhonemeFileContent()
        {
            pathToPhonemeFile = dataManager.LoadWindowData().TempFolderPath + @"\tempPhonemes.txt";
            loadedText = File.ReadAllText(pathToPhonemeFile);
            return loadedText;
        }
    }
}

