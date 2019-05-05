namespace PhonemeExtractor.SetupWindow
{
    public static class CustomEditorPrefs
    {
        public static readonly string pluginPath = "pluginPath";
        public static readonly string acousticModelPath = "acousticModelPath";
        public static readonly string dictionaryPath = "dictionaryPath";
        public static readonly string tempFolderPath = "tempFolderPath";

        public static string[] GetCustomEditorPrefs()
        {
            return new string[] { pluginPath, acousticModelPath, dictionaryPath, tempFolderPath };
        }
    }
}