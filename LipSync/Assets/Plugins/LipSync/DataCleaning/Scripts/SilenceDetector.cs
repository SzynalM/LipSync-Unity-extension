using System.Collections.Generic;
using UnityEngine;
using VisemeExtraction;
using PhonemeExtractor;

public class SilenceDetector
{
    private const int silenceInterval = 600; //ms

    public List<ScriptableObject> DetectSilence(List<ScriptableObject> visemes)
    {
        try
        {
            int[] timestamps = new int[visemes.Count + 2];

            timestamps[0] = 0;

            for (int i = 0; i < visemes.Count; i++)
            {
                timestamps[i + 1] = (visemes[i] as Viseme).startTime;
                timestamps[i + 2] = (visemes[i] as Viseme).endTime;
            }

            for (int i = 0; i < timestamps.Length - 2; i++)
            {
                if (timestamps[i + 1] - timestamps[i] >= silenceInterval)
                {
                    visemes.Insert(i, ScriptableObject.CreateInstance<Viseme_Silence>().Init(timestamps[i], timestamps[i + 1]));
                } 
            }
            visemes.Add(ScriptableObject.CreateInstance<Viseme_Silence>().Init(timestamps[timestamps.Length - 1], Mathf.RoundToInt(PhonemeExtractor_Main.audioClip.length * 1000)));

            return visemes; 
        }
        catch(System.Exception e)
        {
            Debug.LogError("Error in silence detector\n" + e);
            return null; 
        }
    }
}
