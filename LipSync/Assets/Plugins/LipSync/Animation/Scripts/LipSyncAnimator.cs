using System;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using VisemeExtraction;

#pragma warning disable CS0649

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class LipSyncAnimator : MonoBehaviour
{
    public event Action<VisemeScriptableObject> OnDialogueStarted;
    public event Action OnDialogueEnded;

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
    private ShowSubtitles subtitlesDisplayer;

    [SerializeField]
    private AudioSource dialogueAudioSource;

    private List<ScriptableObject> visemes;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Mesh sharedMesh;
    private AudioClip dialogueAudio;
    private Viseme currentViseme;
    private int currentBlendShapeIndex;
    private int currentVisemeIndex;

    private bool isDialoguePlaying;

    private void Awake()
    {
        OnDialogueStarted += subtitlesDisplayer.DisplaySubtitles;
        OnDialogueEnded += subtitlesDisplayer.HideSubtitles;

        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        sharedMesh = skinnedMeshRenderer.sharedMesh;
        fasterReductionTime = reductionSpeed * 1.4f;
        halvedReductionTime = reductionSpeed / reduction;
        _reductionSpeed = reductionSpeed;
    }

    private void Update()
    {
        ShowVisemes();
    }

    public void PlayLipSyncAnimation(VisemeScriptableObject data)
    {
        dialogueData = data;
        PlayLipSyncAnimation();
    }

    [BurstCompile]
    public void PlayLipSyncAnimation()
    {
        dialogueAudio = dialogueData.dialogueAudio; //for tests
        visemes = dialogueData.generatedVisemes;
        currentVisemeIndex = 0;
        currentViseme = visemes[currentVisemeIndex] as Viseme;
        currentBlendShapeIndex = BlendShapeInfo.GetBlendShapeIndex(currentViseme);

        dialogueAudioSource.clip = dialogueAudio;
        dialogueAudioSource.Play();

        OnDialogueStarted?.Invoke(dialogueData);
    }

    [BurstCompile]
    private void ShowVisemes() //in update
    {
        if (AreAllBlendShapesZeroed() == true && dialogueAudioSource.isPlaying == false)
        {
            if(isDialoguePlaying == true)
            {
                isDialoguePlaying = false;
                OnDialogueEnded?.Invoke();
            }
            return;
        }
        else
        {
            isDialoguePlaying = true;
            if (AreAllBlendShapesZeroed() == false)
            {
                ZeroOutAllBlendShapes();
            }
            if (dialogueAudioSource.isPlaying)
            {
                IncrementCurrentVisemeBlendShape(currentViseme);
            }
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
