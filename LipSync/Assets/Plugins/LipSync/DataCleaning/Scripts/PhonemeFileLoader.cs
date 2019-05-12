using System;
using System.IO;
using UnityEngine;

namespace DataCleaning.Utility
{
    public class PhonemeFileLoader
    {
        public string[] LoadRawPhonemeData(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception exception)
            {
                Debug.LogError($"Failed to load content from generated file at {filePath}.\nPlease check if Temp folder path is correctly set and try again.\n\n" + exception);
            }
            return null;
        }
    }
}

