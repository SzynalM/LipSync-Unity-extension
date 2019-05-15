using LipsyncUtility;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using VisemeExtraction;

#pragma warning disable CS0649

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class LipSyncAnimator : MonoBehaviour
{
    [SerializeField]
    float reduction = 3;
    [SerializeField]
    float reductionSpeed = 300;
    float _reductionSpeed = 300;
    float halvedReductionTime = 150;
    float fasterReductionTime = 450;
    [SerializeField]
    int incrementationSpeed = 500;
    [SerializeField]
    int overallIntensity = 100;

    [SerializeField] //for tests
    private VisemeScriptableObject dialogueData;

    [SerializeField]
    private AudioSource dialogueAudioSource;

    private List<ScriptableObject> visemes;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Mesh sharedMesh;
    private AudioClip dialogueAudio;
    private Viseme currentViseme;
    private int currentBlendShapeIndex;
    private int currentVisemeIndex;

    private void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        sharedMesh = skinnedMeshRenderer.sharedMesh;
        AssignNewDialogueData(dialogueData);
    }

    private void Update()
    {
        ShowVisemes();
    }

    public void AssignNewDialogueData(VisemeScriptableObject data)
    {
        dialogueAudio = data.dialogueAudio;
    }

    [BurstCompile]
    public void PlayLipSyncAnimation()
    {
#if UNITY_EDITOR
        dialogueAudio = dialogueData.dialogueAudio;
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        sharedMesh = skinnedMeshRenderer.sharedMesh;
#endif
        _reductionSpeed = reductionSpeed;
        fasterReductionTime = reductionSpeed * 1.4f;
        halvedReductionTime = reductionSpeed / reduction;
        dialogueAudioSource.clip = dialogueAudio;
        dialogueAudioSource.Play();
        visemes = dialogueData.generatedVisemes;
        currentVisemeIndex = 0;
        currentViseme = visemes[currentVisemeIndex] as Viseme;
        currentBlendShapeIndex = BlendShapeInfo.GetBlendShapeIndex(currentViseme);
    }

    [BurstCompile]
    private void ShowVisemes() //in update
    {
        if (AreAllBlendShapesZeroed() == false)
        {
            Debug.Log("Zeroing " + AreAllBlendShapesZeroed());
            ZeroOutAllBlendShapes();
        }
        if (dialogueAudioSource.isPlaying)
        {
            IncrementCurrentVisemeBlendShape(currentViseme);
        }
    }

    private void IncrementCurrentVisemeBlendShape(Viseme _currentViseme)
    {
        if (_currentViseme.StartTime < dialogueAudioSource.time * 1000 && _currentViseme.EndTime > dialogueAudioSource.time * 1000) //currentVisemeBeingDisplayed
        {
            if (_currentViseme is Viseme_Silence)
            {
                _reductionSpeed = fasterReductionTime;
                return;
            }
            else if (_currentViseme is Viseme_Mixed)
            {
                _reductionSpeed = reductionSpeed;
                for (int i = 0; i < (_currentViseme as Viseme_Mixed).visemes.Length; i++)
                {
                    if (skinnedMeshRenderer.GetBlendShapeWeight(BlendShapeInfo.GetBlendShapeIndex((_currentViseme as Viseme_Mixed).visemes[i])) + (Time.deltaTime * incrementationSpeed * (_currentViseme as Viseme_Mixed).visemes[i].pronunciationSpeed) <= overallIntensity * (_currentViseme as Viseme_Mixed).visemes[i].intensity)
                    {
                        skinnedMeshRenderer.SetBlendShapeWeight(BlendShapeInfo.GetBlendShapeIndex((_currentViseme as Viseme_Mixed).visemes[i]), skinnedMeshRenderer.GetBlendShapeWeight(BlendShapeInfo.GetBlendShapeIndex((_currentViseme as Viseme_Mixed).visemes[i])) + (Time.deltaTime * incrementationSpeed * (_currentViseme as Viseme_Mixed).visemes[i].pronunciationSpeed));
                    }
                }
            }
            else
            {
                _reductionSpeed = reductionSpeed;
                if (skinnedMeshRenderer.GetBlendShapeWeight(currentBlendShapeIndex) + (Time.deltaTime * incrementationSpeed * _currentViseme.pronunciationSpeed) <= overallIntensity * _currentViseme.intensity)
                {
                    skinnedMeshRenderer.SetBlendShapeWeight(currentBlendShapeIndex, skinnedMeshRenderer.GetBlendShapeWeight(currentBlendShapeIndex) + (Time.deltaTime * incrementationSpeed * _currentViseme.pronunciationSpeed));
                }
            }
        }
        else if (dialogueAudioSource.time * 1000 > _currentViseme.EndTime) //this viseme has ended
        {
            currentVisemeIndex++;
            currentViseme = (Viseme)visemes[currentVisemeIndex];
            currentBlendShapeIndex = BlendShapeInfo.GetBlendShapeIndex(currentViseme);
            int currentVisemeStartTime = _currentViseme.StartTime;
            int currentVisemeEndTime = _currentViseme.EndTime;
            _reductionSpeed = halvedReductionTime;
        }
        else 
        {
            Debug.Log("Reduction " + _reductionSpeed + " = " + halvedReductionTime);
            _reductionSpeed = halvedReductionTime;
        }
    }

    private bool AreAllBlendShapesZeroed()
    {
        for (int i = 0; i < sharedMesh.blendShapeCount; i++)
        {
            if (skinnedMeshRenderer.GetBlendShapeWeight(i) != 0)
            {
                return false;
            }
        }
        return true;
    }

    private void ZeroOutAllBlendShapes()
    {
        for (int i = 0; i < sharedMesh.blendShapeCount; i++)
        {
            if (skinnedMeshRenderer.GetBlendShapeWeight(i) - (Time.deltaTime * _reductionSpeed) > 0)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(i, skinnedMeshRenderer.GetBlendShapeWeight(i) - (Time.deltaTime * _reductionSpeed));
            }
            else
            {
                skinnedMeshRenderer.SetBlendShapeWeight(i, 0);
            }
        }
    }
}
