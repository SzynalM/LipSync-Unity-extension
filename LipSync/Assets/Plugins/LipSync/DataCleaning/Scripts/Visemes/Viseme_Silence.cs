using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_Silence : Viseme
    {
        public Viseme_Silence Init(int _startTime, int _endTime)
        {
            pronunciationSpeed = 1;
            intensity = 1;
            startTime = _startTime;
            endTime = _endTime;
            return this;
        }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, int incrementationSpeed, int overallIntensity)
        {
            base.ShowViseme(skinnedMeshRenderer, incrementationSpeed, overallIntensity);
        }
    }

}