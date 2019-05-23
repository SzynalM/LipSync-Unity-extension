using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private LipSyncAnimator lipSyncAnimator;
    [SerializeField]
    private VisemeScriptableObject numbers;
    [SerializeField]
    private VisemeScriptableObject apples;
    [SerializeField]
    private VisemeScriptableObject newYork;

    public void PlayNumbers()
    {
        lipSyncAnimator.PlayLipSyncAnimation(numbers);
    }

    public void PlayNewYork()
    {
        lipSyncAnimator.PlayLipSyncAnimation(newYork);
    }

    public void PlayApples()
    {
        lipSyncAnimator.PlayLipSyncAnimation(apples);
    }
}
