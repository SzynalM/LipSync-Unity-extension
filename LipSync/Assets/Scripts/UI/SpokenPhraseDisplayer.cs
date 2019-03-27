using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SpokenPhraseDisplayer : MonoBehaviour
{
    TextMeshProUGUI thisText;

    void Start()
    {
        thisText = GetComponent<TextMeshProUGUI>();
        thisText.text = "";
    }

    public void UpdateText(string textContent) 
    {
        thisText.text = textContent;
    }
}
