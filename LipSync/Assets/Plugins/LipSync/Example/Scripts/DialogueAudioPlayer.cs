using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogueAudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDialogueAudio(VisemeScriptableObject dialogueData)
    {
        audioSource.clip = dialogueData.dialogueAudio;
        audioSource.Play();
    }
}