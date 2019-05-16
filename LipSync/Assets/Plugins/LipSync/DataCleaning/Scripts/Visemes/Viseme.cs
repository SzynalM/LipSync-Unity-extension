using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme : ScriptableObject
    {
        public int StartTime;
        public int EndTime;

        public float intensity;
        public float pronunciationSpeed;

        public Viseme Init(float _intensity, float _pronunciationSpeed)
        {
            intensity = _intensity;
            pronunciationSpeed = _pronunciationSpeed;
            return this;
        }

        private int currentBlendShapeIndex;

        public virtual void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, int incrementationSpeed, int overallIntensity)
        {
            currentBlendShapeIndex = BlendShapeInfo.GetBlendShapeIndex(this);
            if (skinnedMeshRenderer.GetBlendShapeWeight(currentBlendShapeIndex) + (Time.deltaTime * incrementationSpeed * pronunciationSpeed) <= overallIntensity * intensity)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(currentBlendShapeIndex, skinnedMeshRenderer.GetBlendShapeWeight(currentBlendShapeIndex) + (Time.deltaTime * incrementationSpeed * pronunciationSpeed));
            }
        }
    }
}
