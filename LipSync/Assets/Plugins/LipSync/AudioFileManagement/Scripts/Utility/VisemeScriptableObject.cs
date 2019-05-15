using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects")]
public class VisemeScriptableObject : ScriptableObject
{
    public string dialogueTranscription;
    public AudioClip dialogueAudio;
    public List<ScriptableObject> generatedVisemes;
}