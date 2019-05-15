using DataCleaning;
using PhonemeExtractor;
using PhonemeExtractor.SetupWindow;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using VisemeExtraction;

public class LipSyncCreator
{
    private VisemeExtractor visemeExtractor = new VisemeExtractor();
    private SilenceDetector silenceDetector = new SilenceDetector();
    private DataManager dataManager = new DataManager();
    private DataCleaner dataCleaner = new DataCleaner();

    private List<ScriptableObject> visemes;
    private string phonemeFilePath;

    public void CreateLipsyncData(string _phonemeFilePath)
    {
        phonemeFilePath = _phonemeFilePath;
        Dispatcher.Dispatch(AssignVisemeData);
        Dispatcher.Dispatch(CreateAsset);
    }

    private void AssignVisemeData()
    {
        visemes = silenceDetector.DetectSilence(visemeExtractor.ExtractVisemes(dataCleaner.CleanRawPhonemeData(phonemeFilePath)));
    }

    private void CreateAsset()
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
            for (int i = 0; i < visemes.Count; i++)
            {
                visemes[i].name = visemes[i].GetType().ToString().Split('.')[1];
                //visemes[i].hideFlags = HideFlags.HideInHierarchy;
                AssetDatabase.AddObjectToAsset(visemes[i], scriptableObjectPath);
            }
            AssetDatabase.SaveAssets();

        }
        catch (Exception e)
        {
            Debug.Log("Failed to create ScriptableObject\n" + e);
        }
    }
}