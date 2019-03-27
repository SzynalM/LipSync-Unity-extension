using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechListener : MonoBehaviour
{
    [SerializeField]
    SpeechConfiguration speechConfiguration;

    [SerializeField]
    SpokenPhraseDisplayer spokenPhraseDisplayer;

    [SerializeField]
    InputManager inputManager;

    DictationRecognizer phraseRecognizer;

    void Start()
    {
        phraseRecognizer = new DictationRecognizer(speechConfiguration.ConfidenceLevel);
        inputManager.OnRecordingStarted += EnableRecording;
        phraseRecognizer.DictationResult += RecognizedWordAssembler;
    }

    void RecognizedWordAssembler(string capturedText, ConfidenceLevel confidenceLevel) 
    {
        spokenPhraseDisplayer.UpdateText(capturedText);
    }

    void EnableRecording(bool isEnabled)
    {
        if(isEnabled == true)
        {
            phraseRecognizer.Start();
        }
        else
        {
            phraseRecognizer.Stop();
        }
    }
}
