using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_UU : Viseme, IVisemeCommand
    {
        public Viseme_UU(float _intensity, float _pronunciationSpeed) : base(_intensity, _pronunciationSpeed) { }

        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer)
        {
            base.ShowViseme(skinnedMeshRenderer);
        }
    }

}