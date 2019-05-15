using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_Mixed : Viseme
    {
        public Viseme[] visemes;

        public Viseme_Mixed Init(params Viseme[] _visemes)
        {
            visemes = _visemes;
            return this;
        }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, Viseme viseme)
        {
            foreach(Viseme _viseme in visemes)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(BlendShapeInfo.GetBlendShapeIndex(_viseme), intensity);
            }
        }
    }
}

