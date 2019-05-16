using System;
using System.Collections.Generic;
using UnityEngine;
using VisemeExtraction;

#pragma warning disable CS0649

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class LipSyncAnimator : MonoBehaviour
{
    public event Action<VisemeScriptableObject> OnDialogueStarted;
    public event Action OnDialogueEnded;

    [SerializeField]
    private float reductionSpeedMultiplier = 3;
    [SerializeField]
    private float defaultReductionSpeed = 300;
    [SerializeField]
    private int incrementationSpeed = 500;
    [SerializeField]
    private int overallIntensity = 100;

    [SerializeField]
    private VisemeScriptableObject dialogueData;
    [SerializeField]
    private ShowSubtitles subtitlesDisplayer;
    [SerializeField]
    private DialogueAudioPlayer dialogueAudioPlayer;
    [SerializeField]
    private AudioSource dialogueAudioSource;

    private SkinnedMeshRenderer skinnedMeshRenderer;
    private List<ScriptableObject> visemes;
    private AudioClip dialogueAudio;
    private Viseme currentViseme;
    private Mesh sharedMesh;
    private bool isDialoguePlaying;
    private int currentBlendShapeIndex;
    private int currentVisemeIndex;
    private int currentVisemeStartTime;
    private int currentVisemeEndTime;
    private float _reductionSpeed;
    private float halvedReductionTime;
    private float fasterReductionTime;

    private void Awake()
    {
        SubscribeEvents();
        InitializeComponent();
    }

    private void Update()
    {
        CalculateVisemes();
    }

    public void PlayLipSyncAnimation(VisemeScriptableObject data)
    {
        dialogueData = data;
        PlayLipSyncAnimation();
    }

    public void PlayLipSyncAnimation()
    {
        visemes = dialogueData.generatedVisemes;
        currentVisemeIndex = 0;
        AssignCurrentVisemeData();

        OnDialogueStarted?.Invoke(dialogueData);
    }

    private void CalculateVisemes()
    {
        if (HasDialogueFinished() == true)
        {
            if (isDialoguePlaying == true)
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
                IncrementCurrentVisemeBlendShape();
            }
        }
    }

    private void IncrementCurrentVisemeBlendShape()
    {
        if (HasCurrentVisemeStarted() == true)
        {
            if (currentViseme is Viseme_Silence)
            {
                _reductionSpeed = fasterReductionTime;
                return;
            }
            else
            {
                _reductionSpeed = defaultReductionSpeed;
                currentViseme.ShowViseme(skinnedMeshRenderer, incrementationSpeed, overallIntensity);
            }
        }
        else if (HasCurrentVisemeEnded() == true)
        {
            currentVisemeIndex++;
            AssignCurrentVisemeData();
            _reductionSpeed = halvedReductionTime;
        }
        else //Undetected silence
        {
            _reductionSpeed = halvedReductionTime;
        }
    }

    private void InitializeComponent()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        sharedMesh = skinnedMeshRenderer.sharedMesh;
        fasterReductionTime = defaultReductionSpeed * reductionSpeedMultiplier;
        halvedReductionTime = defaultReductionSpeed / reductionSpeedMultiplier;
        _reductionSpeed = defaultReductionSpeed;
    }

    private void SubscribeEvents()
    {
        OnDialogueStarted += subtitlesDisplayer.DisplaySubtitles;
        OnDialogueEnded += subtitlesDisplayer.HideSubtitles;
        OnDialogueStarted += dialogueAudioPlayer.PlayDialogueAudio;
    }

    private void AssignCurrentVisemeData()
    {
        currentViseme = (Viseme)visemes[currentVisemeIndex];
        currentBlendShapeIndex = BlendShapeInfo.GetBlendShapeIndex(currentViseme);
        currentVisemeStartTime = currentViseme.StartTime;
        currentVisemeEndTime = currentViseme.EndTime;
    }

    private bool HasDialogueFinished()
    {
        return AreAllBlendShapesZeroed() == true && dialogueAudioSource.isPlaying == false;
    }

    private bool HasCurrentVisemeEnded()
    {
        return dialogueAudioSource.time * 1000 > currentViseme.EndTime;
    }

    private bool HasCurrentVisemeStarted()
    {
        return currentViseme.StartTime < dialogueAudioSource.time * 1000 && currentViseme.EndTime > dialogueAudioSource.time * 1000;
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