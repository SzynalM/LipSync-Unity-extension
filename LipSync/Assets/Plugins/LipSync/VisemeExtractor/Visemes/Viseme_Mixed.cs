using UnityEngine;

namespace VisemeExtractor
{
    [System.Serializable]
    public class Viseme_Mixed : Viseme, IVisemeCommand
    {
        private Viseme[] visemes;
        public Viseme_Mixed(params Viseme[] _visemes)
        {
            visemes = _visemes;
        }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            foreach(Viseme viseme in visemes)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(BlendShapeInfo.GetBlendShape(viseme), intensity);
            }
        }
    }
}

