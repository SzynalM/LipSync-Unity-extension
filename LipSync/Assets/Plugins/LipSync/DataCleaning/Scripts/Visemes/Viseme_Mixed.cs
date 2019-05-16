using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_Mixed : Viseme
    {
        public Viseme[] visemes;
        private int currentVisemeBlendShapeIndex;

        public Viseme_Mixed Init(params Viseme[] _visemes)
        {
            visemes = _visemes;
            return this;
        }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, int incrementationSpeed, int overallIntensity)
        {
            for (int i = 0; i < visemes.Length; i++)
            {
                currentVisemeBlendShapeIndex = BlendShapeInfo.GetBlendShapeIndex(visemes[i]);
                if (skinnedMeshRenderer.GetBlendShapeWeight(currentVisemeBlendShapeIndex) + (Time.deltaTime * incrementationSpeed * visemes[i].pronunciationSpeed) <= overallIntensity * visemes[i].intensity)
                {
                    skinnedMeshRenderer.SetBlendShapeWeight(currentVisemeBlendShapeIndex, skinnedMeshRenderer.GetBlendShapeWeight(currentVisemeBlendShapeIndex) + (Time.deltaTime * incrementationSpeed * visemes[i].pronunciationSpeed));
                }
            }
        }
    }
}

