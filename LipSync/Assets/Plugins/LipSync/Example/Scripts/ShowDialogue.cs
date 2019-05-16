using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private LipSyncAnimator animator;
    [SerializeField]
    private VisemeScriptableObject numbers;
    [SerializeField]
    private VisemeScriptableObject apples;
    [SerializeField]
    private VisemeScriptableObject newYork;

    public void PlayNumbers()
    {
        animator.PlayLipSyncAnimation(numbers);
    }

    public void PlayNewYork()
    {
        animator.PlayLipSyncAnimation(newYork);
    }

    public void PlayApples()
    {
        animator.PlayLipSyncAnimation(apples);
    }
}
