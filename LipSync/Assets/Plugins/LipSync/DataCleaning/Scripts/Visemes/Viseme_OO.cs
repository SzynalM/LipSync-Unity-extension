using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_OO : Viseme, IVisemeCommand
    {
        public Viseme_OO(float _intensity, float _pronunciationSpeed) : base(_intensity, _pronunciationSpeed) { }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            base.ShowViseme(skinnedMeshRenderer);
        }
    }
}
