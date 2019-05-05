using UnityEngine;

namespace VisemeExtractor
{
    public abstract class Viseme 
    {
        public abstract void ShowViseme(SkinnedMeshRenderer skinnedMeshRenderer, int intensity);
    }
}
