using DataCleaning;
using PhonemeExtractor.SetupWindow;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using VisemeExtraction;
using PhonemeExtractor;
using System.IO;

public class LipSyncCreator
{
    private VisemeExtractor visemeExtractor = new VisemeExtractor();
    private DataManager dataManager = new DataManager();
    private DataCleaner dataCleaner = new DataCleaner();

    private List<Viseme> visemes;

    public void CreateLipsyncData(string phonemeFilePath)
    {
        visemes = visemeExtractor.ExtractVisemes(dataCleaner.CleanRawPhonemeData(phonemeFilePath));
        Dispatcher.Dispatch(CreateAsset);
    }

    public void CreateAsset()
    {
        try
        {
            string scriptableObjectPath;
            if (dataManager.LoadWindowData().DialogueToggle)
            {
                scriptableObjectPath = Path.Combine(Path.GetDirectoryName(PhonemeExtractor_Main.audioFilePath), PhonemeExtractor_Main.audioClip.name + ".asset");
            }
            else
            {
                scriptableObjectPath = Path.Combine(dataManager.LoadWindowData().DialogueDataSavingPath, PhonemeExtractor_Main.audioClip.name + ".asset");
            }
            VisemeScriptableObject newScriptableObject = ScriptableObject.CreateInstance<VisemeScriptableObject>();
            newScriptableObject.dialogueAudio = PhonemeExtractor_Main.audioClip;
            newScriptableObject.dialogueTranscription = PhonemeExtractor_Main.textTranscripton;
            newScriptableObject.generatedVisemes = visemes;
            AssetDatabase.CreateAsset(newScriptableObject, scriptableObjectPath);
            AssetDatabase.SaveAssets();
        }
        catch (Exception e)
        {
            Debug.Log("Failed to create ScriptableObject\n" + e);
        }
    }
}

public class ScriptableObjectCreator : ScriptableObject
{

}
