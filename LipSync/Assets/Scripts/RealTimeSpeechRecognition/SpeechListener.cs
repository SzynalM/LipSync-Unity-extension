using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechListener : MonoBehaviour
{
    [SerializeField]
    private SpeechConfiguration speechConfiguration;

    [SerializeField]
    private SpokenPhraseDisplayer spokenPhraseDisplayer;

    [SerializeField]
    private RealTimeInputManager inputManager;

    private DictationRecognizer phraseRecognizer;

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
