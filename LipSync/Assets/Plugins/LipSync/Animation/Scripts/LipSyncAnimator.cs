using LipsyncUtility;
using System.Collections.Generic;
using Unity.Burst;
using UnityEditor;
using UnityEngine;
using VisemeExtraction;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class LipSyncAnimator : MonoBehaviour
{
    [SerializeField]
    int minusIntensity = 300;
    [SerializeField]
    int plusIntencity = 500;
    [SerializeField]
    int overallIntensity = 100;

    [SerializeField] //for tests
    private VisemeScriptableObject dialogueData;

    [SerializeField]
    private AudioSource dialogueAudioSource;

    private Queue<ScriptableObject> animationSequence = new Queue<ScriptableObject>();
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Mesh sharedMesh;
    private AudioClip dialogueAudio;

    private void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        sharedMesh = skinnedMeshRenderer.sharedMesh;
    }

    private void Update()
    {
        ShowVisemes();
    }

    public void AssignNewDialogueData(VisemeScriptableObject data)
    {
        dialogueAudio = data.dialogueAudio;
        animationSequence.EnqueueAll(data.generatedVisemes);
    }

    [BurstCompile]
    public void PlayLipSyncAnimation()
    {
#if UNITY_EDITOR
        dialogueAudio = dialogueData.dialogueAudio;
        animationSequence.EnqueueAll(dialogueData.generatedVisemes);
        EditorApplication.update += EditorUpdate;
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        sharedMesh = skinnedMeshRenderer.sharedMesh;
#endif
        dialogueAudioSource.clip = dialogueAudio;
        dialogueAudioSource.Play();
    }

    [BurstCompile]
    private void ShowVisemes()
    {
        if (dialogueAudioSource.isPlaying && animationSequence.Count > 0)
        {
            Viseme currentViseme = (Viseme)animationSequence.Peek();
            int currentVisemeIndex = BlendShapeInfo.GetBlendShapeIndex(currentViseme);
            int currentVisemeStartTime = currentViseme.StartTime;
            int currentVisemeEndTime = currentViseme.EndTime;

            if (dialogueAudioSource.isPlaying)
            {
                if (dialogueAudioSource.time * 1000 > currentVisemeStartTime && dialogueAudioSource.time * 1000 < currentVisemeEndTime)
                {
                    for (int i = 0; i < sharedMesh.blendShapeCount; i++)
                    {
                        if (i != currentVisemeIndex)
                        {
                            if (skinnedMeshRenderer.GetBlendShapeWeight(i) - Time.deltaTime * currentViseme.pronunciationSpeed * minusIntensity > 0)
                            {
                                skinnedMeshRenderer.SetBlendShapeWeight(i, skinnedMeshRenderer.GetBlendShapeWeight(i) - Time.deltaTime * currentViseme.intensity * minusIntensity);
                            }
                        }
                        else
                        {
                            if (skinnedMeshRenderer.GetBlendShapeWeight(i) <= currentViseme.intensity * overallIntensity)
                            {
                                skinnedMeshRenderer.SetBlendShapeWeight(i, skinnedMeshRenderer.GetBlendShapeWeight(i) + Time.deltaTime * currentViseme.intensity * plusIntencity);
                            }
                        }
                    }
                    animationSequence.Dequeue();
                }
            }
        }
    }

    private void EditorUpdate()
    {
        ShowVisemes();
    }
}
