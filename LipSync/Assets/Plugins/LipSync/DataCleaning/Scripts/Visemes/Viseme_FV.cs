using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_FV : Viseme
    {
        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, int incrementationSpeed, int overallIntensity)
        {
            base.ShowViseme(skinnedMeshRenderer, incrementationSpeed, overallIntensity);
        }
    }
}