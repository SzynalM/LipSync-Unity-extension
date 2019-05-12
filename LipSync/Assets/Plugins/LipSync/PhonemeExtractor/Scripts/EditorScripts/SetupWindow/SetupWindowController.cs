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
        private WindowData windowData;

        private static Vector2 windowSize = new Vector2(900, 200);
        private static bool hasLoaded = false;

        private bool saveDialogueNextToAudioFile = true;

        [MenuItem("Tools/Phoneme Extractor/Setup")]
        private static void InitializeWindow()
        {
            hasLoaded = false;
            SetupWindowController window = GetWindow<SetupWindowController>();
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
                windowData = dataManager.LoadWindowData();
                saveDialogueNextToAudioFile = EditorPrefs.GetBool(CustomEditorPrefs.dialogueToggle);
                hasLoaded = true;
            }

            GUILayout.Label("Set necessary paths", EditorStyles.boldLabel);
            GUILayout.Label("Default values might be incorrect", EditorStyles.label);
            GUILayout.Space(20);

            EditorGUI.BeginChangeCheck();
            windowData.PluginPath = EditorGUILayout.TextField("Plugin path", windowData.PluginPath.Equals(DefaultPaths.defaultPluginPath) ? OnDefaultPathSet(ConfigDataType.Plugin) : windowData.PluginPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.Plugin, windowData.PluginPath);
            }

            EditorGUI.BeginChangeCheck();
            windowData.AcousticModelPath = EditorGUILayout.TextField("Acoustic model path", windowData.AcousticModelPath.Equals(DefaultPaths.defaultAcousticModelPath) ? OnDefaultPathSet(ConfigDataType.AcousticModel) : windowData.AcousticModelPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.AcousticModel, windowData.AcousticModelPath);
            }

            EditorGUI.BeginChangeCheck();
            windowData.DictionaryPath = EditorGUILayout.TextField("Dictionary path", windowData.DictionaryPath.Equals(DefaultPaths.defaultDictionaryPath) ? OnDefaultPathSet(ConfigDataType.Dictionary) : windowData.DictionaryPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.Dictionary, windowData.DictionaryPath);
            }

            EditorGUI.BeginChangeCheck();
            windowData.TempFolderPath = EditorGUILayout.TextField("Temp folder path", windowData.TempFolderPath.Equals(DefaultPaths.defaultTempFolderPath) ? OnDefaultPathSet(ConfigDataType.TempFolder) : windowData.TempFolderPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.TempFolder, windowData.TempFolderPath);
            }

            EditorGUI.BeginChangeCheck();
            float originalWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 250;
            windowData.DialogueToggle = EditorGUILayout.Toggle("Save dialogue data in audio file directory", windowData.DialogueToggle);
            EditorGUIUtility.labelWidth = originalWidth;
            if(EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.DialogueToggle, windowData.DialogueToggle);
            }

            EditorGUI.BeginDisabledGroup(windowData.DialogueToggle);
            EditorGUI.BeginChangeCheck();
            windowData.DialogueDataSavingPath = EditorGUILayout.TextField("Dialogue folder path", windowData.DialogueDataSavingPath.Equals(DefaultPaths.defaultDialogueSavingPath) ? OnDefaultPathSet(ConfigDataType.DialoguePath) : windowData.DialogueDataSavingPath);
            if (EditorGUI.EndChangeCheck() == true)
            {
                dataManager.SaveWindowData(ConfigDataType.DialoguePath, windowData.DialogueDataSavingPath);
            }
            EditorGUI.EndDisabledGroup();
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