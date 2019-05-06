using UnityEngine;

namespace VisemeExtractor
{
    [System.Serializable]
    public class Viseme_CH : Viseme, IVisemeCommand
    {
        public Viseme_CH(float _intensity, float _pronunciationSpeed) : base(_intensity, _pronunciationSpeed) { }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            base.ShowViseme(skinnedMeshRenderer);
        }
    }
}