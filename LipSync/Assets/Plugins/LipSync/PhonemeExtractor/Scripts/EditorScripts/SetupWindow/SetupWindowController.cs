using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PhonemeExtractor.SetupWindow
{
    public class SetupWindowController : EditorWindow
    {
#if UNITY_EDITOR
        private DataManager dataManager = new DataManager();
        private CurrentPaths currentPaths;

        private static Vector2 windowSize = new Vector2(900, 200);
        private static bool hasLoaded = false;

        [MenuItem("Tools/Phoneme Extractor/Setup")]
        private static void InitializeWindow()
        {
            hasLoaded = false;
            SetupWindowController window = (SetupWindowController)GetWindow(typeof(SetupWindowController));
            window.name = "Phoneme Extractor Setup";
            window.minSize = windowSize;
            window.maxSize = windowSize;
            window.Focus();
            window.Show();
        }

        private void OnGUI()
        {
            if (hasLoaded == false)
            {
                currentPaths = dataManager.LoadWindowData();
                hasLoaded = true;
            }

            GUILayout.Label("Set necessary paths", EditorStyles.boldLabel);
            GUILayout.Label("Default values might be incorrect", EditorStyles.label);
            GUILayout.Space(20);

            EditorGUI.BeginChangeCheck();
            currentPaths.PluginPath = EditorGUILayout.TextField("Plugin path", currentPaths.PluginPath.Equals(DefaultPaths.defaultPluginPath) ? OnDefaultPathSet(ConfigDataType.Plugin) : currentPaths.PluginPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.Plugin, currentPaths.PluginPath);
            }

            EditorGUI.BeginChangeCheck();
            currentPaths.AcousticModelPath = EditorGUILayout.TextField("Acoustic model path", currentPaths.AcousticModelPath.Equals(DefaultPaths.defaultAcousticModelPath) ? OnDefaultPathSet(ConfigDataType.AcousticModel) : currentPaths.AcousticModelPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.AcousticModel, currentPaths.AcousticModelPath);
            }

            EditorGUI.BeginChangeCheck();
            currentPaths.DictionaryPath = EditorGUILayout.TextField("Dictionary path", currentPaths.DictionaryPath.Equals(DefaultPaths.defaultDictionaryPath) ? OnDefaultPathSet(ConfigDataType.Dictionary) : currentPaths.DictionaryPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.Dictionary, currentPaths.DictionaryPath);
            }

            EditorGUI.BeginChangeCheck();
            currentPaths.TempFolderPath = EditorGUILayout.TextField("Temp folder path", currentPaths.TempFolderPath.Equals(DefaultPaths.defaultTempFolderPath) ? OnDefaultPathSet(ConfigDataType.TempFolder) : currentPaths.TempFolderPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.TempFolder, currentPaths.TempFolderPath);
            }
        }

        private string OnDefaultPathSet(ConfigDataType defaultValueSet)
        {
            if (defaultValueSet == ConfigDataType.Plugin)
            {
                Debug.LogWarning(WarningMessages.defaultPluginPathSet);
                return DefaultPaths.defaultPluginPath;
            }
            else if (defaultValueSet == ConfigDataType.AcousticModel)
            {
                Debug.LogWarning(WarningMessages.defaultAcousticModelPathSet);
                return DefaultPaths.defaultAcousticModelPath;
            }
            else if (defaultValueSet == ConfigDataType.Dictionary)
            {
                Debug.LogWarning(WarningMessages.defaultDictionaryPathSet);
                return DefaultPaths.defaultDictionaryPath;
            }
            else if (defaultValueSet == ConfigDataType.TempFolder)
            {
                Debug.LogWarning(WarningMessages.defaultTempFolderPathSet);
                return DefaultPaths.defaultTempFolderPath;
            }
            else 
            {
                return string.Empty;
            }
        }
#endif
    }

}