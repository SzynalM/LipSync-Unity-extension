namespace VisemeExtractor
{
    public class WordRemover
    {
        public string[] RemoveWordsAtBeginningsOfLines(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = data[i].Substring(data[i].IndexOf('('));
            }
            return data;
        }
    }
}

