using UnityEngine;

namespace VisemeExtractor
{
    [System.Serializable]
    public class Viseme : IVisemeCommand
    {
        /// <summary>
        /// Create a new viseme
        /// </summary>
        /// <param name="_intensity">Range[0, 1] Controls how much this viseme affects the base model</param>
        /// <param name="_pronunciationSpeed">Range[0, 1] Controls how quickly the mouth reaches intensity value</param>
        protected Viseme(float _intensity, float _pronunciationSpeed)
        {
            intensity = _intensity;
            pronunciationSpeed = _pronunciationSpeed;
        }

        protected Viseme(params Viseme[] _visemes) { }

        protected float intensity;
        protected float pronunciationSpeed;
        public virtual void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(BlendShapeInfo.GetBlendShape(this), intensity);
        }

        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}
