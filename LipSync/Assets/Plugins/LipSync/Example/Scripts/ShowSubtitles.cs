using UnityEngine;
using UnityEngine.UI;

public class ShowSubtitles : MonoBehaviour
{
    private Text thisText;

    private void Awake()
    {
        thisText = GetComponent<Text>();
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
