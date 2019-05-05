using UnityEngine;

namespace VisemeExtractor
{
    public class Viseme_BM : Viseme
    {
        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, int intensity)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(BlendShapeGetter.GetBlendShape(this), intensity);
        }
    }
}