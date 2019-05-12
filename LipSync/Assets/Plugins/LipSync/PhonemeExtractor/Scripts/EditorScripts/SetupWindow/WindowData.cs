namespace PhonemeExtractor.SetupWindow
{
    public class WindowData
    {
        public string PluginPath { get; set; }
        public string AcousticModelPath { get; set; }
        public string DictionaryPath { get; set; }
        public string TempFolderPath { get; set; }
        public string DialogueDataSavingPath { get; set; }
        public bool DialogueToggle { get; set; }

        public WindowData(string pluginPath, string acousticModelPath, string dictionaryPath, string tempFolderPath, string dialogueDataSavingPath, bool dialogueToggle)
        {
            PluginPath = pluginPath;
            AcousticModelPath = acousticModelPath;
            DictionaryPath = dictionaryPath;
            TempFolderPath = tempFolderPath;
            DialogueDataSavingPath = dialogueDataSavingPath;
            DialogueToggle = dialogueToggle;
        }
    } 
}
