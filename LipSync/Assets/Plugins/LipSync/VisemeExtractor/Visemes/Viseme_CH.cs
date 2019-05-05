using UnityEngine;

namespace VisemeExtractor
{
    public class Viseme_CH : Viseme
    {
        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, int intensity)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(BlendShapeGetter.GetBlendShape(this), intensity);
        }
    }
}