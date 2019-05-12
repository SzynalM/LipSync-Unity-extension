namespace PhonemeExtractor.SetupWindow
{
    public static class CustomEditorPrefs
    {
        public static readonly string pluginPath = "pluginPath";
        public static readonly string acousticModelPath = "acousticModelPath";
        public static readonly string dictionaryPath = "dictionaryPath";
        public static readonly string tempFolderPath = "tempFolderPath";
        public static readonly string dialogueSavingPath = "dialoguePath";
        public static readonly string dialogueToggle = "dialogueToggle";

        public static string[] GetCustomEditorPrefsNames()
        {
            return new string[] { pluginPath, acousticModelPath, dictionaryPath, tempFolderPath, dialogueSavingPath, dialogueToggle
            };
        }
    }
}