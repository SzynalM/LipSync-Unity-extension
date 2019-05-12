using UnityEngine;
using System.Collections.Generic;
using VisemeExtraction;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects")]
public class VisemeScriptableObject : ScriptableObject
{
    public string dialogueTranscription;
    public AudioClip dialogueAudio;
    public List<Viseme> generatedVisemes;
}