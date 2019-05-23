using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme : ScriptableObject
    {
        public int startTime;
        public int endTime;

        public float intensity;
        public float pronunciationSpeed;

        private int currentBlendShapeIndex;
        private float currentBlendShapeWeight;

        public Viseme Init(float _intensity, float _pronunciationSpeed)
        {
            intensity = _intensity;
            pronunciationSpeed = _pronunciationSpeed;
            return this;
        }

        public virtual void ShowViseme(SkinnedMeshRenderer renderer, int speed, int overallIntensity)
        {
            currentBlendShapeIndex = BlendShapeInfo.GetBlendShapeIndex(this);
            currentBlendShapeWeight = renderer.GetBlendShapeWeight(currentBlendShapeIndex);
            if (IsBlendShapeInRange(renderer, speed, overallIntensity))
            {
                IncreaseBlendShapeValue(renderer, speed, overallIntensity);
            }
        }

        private void IncreaseBlendShapeValue(SkinnedMeshRenderer skinnedMeshRenderer, int speed, int overallIntensity)
        {
            currentBlendShapeWeight += (Time.deltaTime * speed * pronunciationSpeed);
            skinnedMeshRenderer.SetBlendShapeWeight(currentBlendShapeIndex, currentBlendShapeWeight);
        }

        private bool IsBlendShapeInRange(SkinnedMeshRenderer skinnedMeshRenderer, int speed, int overallIntensity)
        {
            return (currentBlendShapeWeight + (Time.deltaTime * speed * pronunciationSpeed) <= overallIntensity * intensity);
        }
    }
}
