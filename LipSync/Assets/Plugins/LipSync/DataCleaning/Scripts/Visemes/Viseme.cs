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

        public virtual void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, Viseme viseme)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(BlendShapeInfo.GetBlendShapeIndex(this), intensity);
            Debug.LogWarning("Viseme index: " + BlendShapeInfo.GetBlendShapeIndex(this));
        }
    }
}
