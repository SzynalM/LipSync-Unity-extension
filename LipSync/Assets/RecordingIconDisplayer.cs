using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class RecordingIconDisplayer : MonoBehaviour
{
    [SerializeField]
    InputManager inputManager;

    [SerializeField]
    float imageFadeDuration = 0.5f;

    Image thisImage;

    void Start()
    {
        thisImage = GetComponent<Image>();
        inputManager.OnRecordingStarted += DisplayRecordingImage;
    }

    void DisplayRecordingImage(bool isVisible)
    {
        thisImage.DOFade(isVisible ? 1 : 0, imageFadeDuration);
    }
}
