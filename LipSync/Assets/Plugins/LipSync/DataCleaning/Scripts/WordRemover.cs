namespace DataCleaning
{
    public class WordRemover 
    {
        public string[] RemoveWordsAtBeginningsOfLines(string[] data)
        {
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i].Substring(data[i].IndexOf('('));
                }
                return data;
            }
            catch(System.Exception e)
            {
                UnityEngine.Debug.LogError("Removing words failed\n" + e);
                return null;
            }
        }
    }
}

