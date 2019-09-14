using System.IO;
using UnityEditor;
using UnityEngine;
using PhonemeExtractor;
using PhonemeExtractor.SetupWindow;

[CustomEditor(typeof(AudioClip))]
public class AudioFileCustomEditor : Editor
{
    private PhonemeExtractor_Main phonemeExtractor = new PhonemeExtractor_Main();
    private LipSyncCreator lipSyncCreator = new LipSyncCreator();
    private DataManager dataManager = new DataManager();

    public bool audioClipIsDialogue = false;
    public bool buttonEnabled = true;
    public string transcription = "";

    private FileSystemWatcher fileSystemWatcher;
    private AudioClip myTarget;

    private const string title = "Viseme Generator options";
    private const string toggleText = "IsDialogue";
    private const string dataPersistencyTooltip = "[Note that this data is one use only and is not persistent. A scriptable object will be generated at setup location for data persistency.]";
    private const string buttonText = "Generate visemes for this audio file";

    public override void OnInspectorGUI()
    {
        myTarget = (AudioClip)target;
        GUI.enabled = true;
        EditorGUILayout.LabelField(new GUIContent(title, dataPersistencyTooltip), EditorStyles.boldLabel);
        EditorGUILayout.Space();
        audioClipIsDialogue = EditorGUILayout.Toggle(toggleText, audioClipIsDialogue);

        if (audioClipIsDialogue == true)
        {
            transcription = EditorGUILayout.TextField(transcription);

            buttonEnabled = transcription.Equals(string.Empty) ? true : false;
            EditorGUI.BeginDisabledGroup(buttonEnabled);
            if (GUILayout.Button(buttonText))
            {
                GenerateVisemesButtonOnClick();
            }
            EditorGUI.EndDisabledGroup();
        }
    }

    private void GenerateVisemesButtonOnClick()
    {
        fileSystemWatcher = new FileSystemWatcher(dataManager.LoadWindowData().TempFolderPath);
        fileSystemWatcher.EnableRaisingEvents = true;
        fileSystemWatcher.Filter = "*.txt"; 
        fileSystemWatcher.Created += OnPhonemeFileGenerated;
        fileSystemWatcher.Changed += OnPhonemeFileGenerated;
    }

    private void OnPhonemeFileGenerated(object o, FileSystemEventArgs e)
    {
        lipSyncCreator.CreateLipsyncData(e.FullPath);
        fileSystemWatcher.Created -= OnPhonemeFileGenerated;
        fileSystemWatcher.Changed -= OnPhonemeFileGenerated;
    }
}
