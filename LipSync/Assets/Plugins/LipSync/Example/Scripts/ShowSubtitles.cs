using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowSubtitles : MonoBehaviour
{
    private TextMeshProUGUI thisText;

    private void Awake()
    {
        thisText = GetComponent<TextMeshProUGUI>();
    }

    public void DisplaySubtitles(VisemeScriptableObject dialogueData)
    {
        thisText.text = dialogueData.dialogueTranscription;
    }

    public void HideSubtitles()
    {
        thisText.text = string.Empty;
    }
}
