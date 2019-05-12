using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_R : Viseme, IVisemeCommand
    {
        public Viseme_R(float _intensity, float _pronunciationSpeed) : base(_intensity, _pronunciationSpeed) { }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            base.ShowViseme(skinnedMeshRenderer);
        }
    }
}