using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_Silence : Viseme
    {
        public Viseme_Silence Init(int startTime, int endTime)
        {
            pronunciationSpeed = 1;
            intensity = 1;
            StartTime = startTime;
            EndTime = endTime;
            return this;
        }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, Viseme viseme)
        {
            for(int i = 0; i < skinnedMeshRenderer.sharedMesh.blendShapeCount; i++)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(i, 0);
            }
        }
    }

}