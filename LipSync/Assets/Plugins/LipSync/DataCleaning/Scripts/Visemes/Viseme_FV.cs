using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_FV : Viseme, IVisemeCommand
    {
        public Viseme_FV(float _intensity, float _pronunciationSpeed) : base(_intensity, _pronunciationSpeed) { }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            base.ShowViseme(skinnedMeshRenderer);
        }
    }
}