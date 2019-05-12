#if UNITY_EDITOR
using System;
using UnityEditor;
#endif

namespace PhonemeExtractor.SetupWindow
{
    public class DataManager
    {
        public WindowData LoadWindowData() //change return type to window data (currrent paths + toggle bool)
        {
            string pluginPath = "";
            string acousticModelPath = "";
            string dictionaryPath = "";
            string tempFolderPath = "";
            string dialoguePath = "";
            bool dialogueToggle = true;
            WindowData data;
            try
            {
                pluginPath = EditorPrefs.GetString(CustomEditorPrefs.pluginPath);
                acousticModelPath = EditorPrefs.GetString(CustomEditorPrefs.acousticModelPath);
                dictionaryPath = EditorPrefs.GetString(CustomEditorPrefs.dictionaryPath);
                tempFolderPath = EditorPrefs.GetString(CustomEditorPrefs.tempFolderPath);
                dialoguePath = EditorPrefs.GetString(CustomEditorPrefs.dialogueSavingPath);
                dialogueToggle = EditorPrefs.GetBool(CustomEditorPrefs.dialogueToggle);
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError("Couldn't load editor prefs \n" + e);
            }
            finally
            {
                data = new WindowData(
                    string.IsNullOrEmpty(pluginPath) ? DefaultPaths.defaultPluginPath : pluginPath,
                    string.IsNullOrEmpty(acousticModelPath) ? DefaultPaths.defaultAcousticModelPath : acousticModelPath,
                    string.IsNullOrEmpty(dictionaryPath) ? DefaultPaths.defaultDictionaryPath : dictionaryPath,
                    string.IsNullOrEmpty(tempFolderPath) ? DefaultPaths.defaultTempFolderPath : tempFolderPath,
                    string.IsNullOrEmpty(dialoguePath) ? DefaultPaths.defaultDialogueSavingPath : dialoguePath,
                    dialogueToggle);
            }
            return data;
        }

        public void SaveWindowData(ConfigDataType dataToSave, bool toggleValue)
        {
            if (dataToSave == ConfigDataType.DialogueToggle)
            {
                EditorPrefs.SetBool(CustomEditorPrefs.dialogueToggle, toggleValue);
            }
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
            } else if (dataToSave == ConfigDataType.DialoguePath)
            {
                EditorPrefs.SetString(CustomEditorPrefs.dialogueSavingPath, path);
            } 
        }
    }
}

