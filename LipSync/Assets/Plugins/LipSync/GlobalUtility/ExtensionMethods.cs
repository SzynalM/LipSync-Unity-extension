namespace LipsyncUtility
{
    public static class ExtensionMethods
    {
        public static string BuildStringFromArray(this string[] stringArray, string separator)
        {
            string output = "";
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (i > 0)
                {
                    output += separator;
                }
                output += stringArray[i];
            }
            return output;
        }
    }
}