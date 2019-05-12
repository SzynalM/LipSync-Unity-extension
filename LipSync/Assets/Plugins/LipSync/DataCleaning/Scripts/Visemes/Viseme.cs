using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme : IVisemeCommand
    {
        public int StartTime;
        public int EndTime;

        protected float intensity;
        protected float pronunciationSpeed;

        protected Viseme(params Viseme[] _visemes) { }

        protected Viseme(float _intensity, float _pronunciationSpeed) //internal
        {
            intensity = _intensity;
            pronunciationSpeed = _pronunciationSpeed;
        }

        public virtual void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(BlendShapeInfo.GetBlendShape(this), intensity);
        }
    }
}
