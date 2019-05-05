using System;
using System.IO;
using UnityEngine;

namespace VisemeExtractor
{
    public class PhonemeFileLoader
    {
        private const string tempPhonemeFileName = @"\tempPhonemes.txt"; //file name is hard coded in executable jar

        public string LoadPhonemeFileContent(string filePath)
        {
            filePath += tempPhonemeFileName;
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception exception)
            {
                Debug.LogError($"Failed to load content from generated file at {filePath}.\nPlease check if Temp folder path is correctly set and try again.\n\n" + exception);
            }
            return string.Empty;
        }
    }
}

