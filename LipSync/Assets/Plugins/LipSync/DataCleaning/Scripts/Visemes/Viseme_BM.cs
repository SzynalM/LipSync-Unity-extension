using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_BM : Viseme, IVisemeCommand
    {
        public Viseme_BM(float _intensity, float _pronunciationSpeed) : base(_intensity, _pronunciationSpeed) { }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            base.ShowViseme(skinnedMeshRenderer);
        }
    }
}