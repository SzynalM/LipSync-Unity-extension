﻿using UnityEngine;

namespace VisemeExtraction
{
    [System.Serializable]
    public class Viseme_FV : Viseme
    {
        public override void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, Viseme viseme)
        {
            base.ShowViseme(skinnedMeshRenderer, this);
        }
    }
}