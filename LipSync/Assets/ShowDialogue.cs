using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    [SerializeField]
    private LipSyncAnimator animator;
    [SerializeField]
    private VisemeScriptableObject numbers;
    [SerializeField]
    private VisemeScriptableObject apples;
    [SerializeField]
    private VisemeScriptableObject newYork;

    [SerializeField]
    public enum Dialogue { Numbers, Apples, NewYork }

    public void PlayNumbers()
    {
        animator.AssignNewDialogueData(numbers);
    }

    public void PlayNewYork()
    {
        animator.AssignNewDialogueData(newYork);
    }

    public void PlayApples()
    {
        animator.AssignNewDialogueData(apples);
    }
}
