using UnityEngine;

namespace VisemeExtractor
{
    [System.Serializable]
    public class Viseme_Silence : Viseme, IVisemeCommand
    {
        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            for(int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(i, 0);
            }
        }
    }

}