using UnityEngine;

namespace VisemeExtractor
{
    [System.Serializable]
    public class Viseme_EE : Viseme, IVisemeCommand
    {
        public Viseme_EE(float _intensity, float _pronunciationSpeed) : base(_intensity, _pronunciationSpeed) { }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            base.ShowViseme(skinnedMeshRenderer);
        }
    }
}