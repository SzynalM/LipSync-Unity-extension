namespace VisemeExtraction
{
    public class BlendShapeInfo
    {
        public static int GetBlendShapeIndex(Viseme viseme)
        {
            if (viseme is Viseme_OO)
            {
                return 0;
            }
            else if (viseme is Viseme_FV)
            {
                return 1;
            }
            else if (viseme is Viseme_EE)
            {
                return 2;
            }
            else if (viseme is Viseme_BM)
            {
                return 3;
            }
            else if (viseme is Viseme_R)
            {
                return 4;
            }
            else if (viseme is Viseme_IH)
            {
                return 5;
            }
            else if (viseme is Viseme_CH)
            {
                return 6;
            }
            else if (viseme is Viseme_AA)
            {
                return 7;
            }
            else if (viseme is Viseme_UU)
            {
                return 8;
            }
            else return 0;
        }
    }
}