#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PhonemeExtractor.SetupWindow
{
    public class DataManager 
    {
        public CurrentPaths LoadWindowData()
        {
            string pluginPath = EditorPrefs.GetString(CustomEditorPrefs.pluginPath);
            string acousticModelPath = EditorPrefs.GetString(CustomEditorPrefs.acousticModelPath);
            string dictionaryPath = EditorPrefs.GetString(CustomEditorPrefs.dictionaryPath);
            string tempFolderPath = EditorPrefs.GetString(CustomEditorPrefs.tempFolderPath);
            CurrentPaths paths = new CurrentPaths(
                string.IsNullOrEmpty(pluginPath) ? DefaultPaths.defaultPluginPath : pluginPath,
                string.IsNullOrEmpty(acousticModelPath) ? DefaultPaths.defaultAcousticModelPath : acousticModelPath,
                string.IsNullOrEmpty(dictionaryPath) ? DefaultPaths.defaultDictionaryPath : dictionaryPath,
                string.IsNullOrEmpty(tempFolderPath) ? DefaultPaths.defaultTempFolderPath : tempFolderPath);
            return paths;
        }

        public void SaveWindowData(ConfigDataType dataToSave, string path)
        {
            if (dataToSave == ConfigDataType.Plugin)
            {
                EditorPrefs.SetString(CustomEditorPrefs.pluginPath, path);
            }
            else if (dataToSave == ConfigDataType.AcousticModel)
            {
                EditorPrefs.SetString(CustomEditorPrefs.acousticModelPath, path);
            }
            else if (dataToSave == ConfigDataType.Dictionary)
            {
                EditorPrefs.SetString(CustomEditorPrefs.dictionaryPath, path);
            }
            else if (dataToSave == ConfigDataType.TempFolder)
            {
                EditorPrefs.SetString(CustomEditorPrefs.tempFolderPath, path);
            }
        }
    }
}

