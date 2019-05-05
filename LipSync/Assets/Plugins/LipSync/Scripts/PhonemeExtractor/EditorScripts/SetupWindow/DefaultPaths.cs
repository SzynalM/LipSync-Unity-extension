using UnityEngine;
using System.IO;

namespace PhonemeExtractor.SetupWindow
{
    public class DefaultPaths
    {
        public static string defaultPluginPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor.jar");
        }
        public static string defaultAcousticModelPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "RecognizerData", "AcousticModel");
        }
        public static string defaultDictionaryPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "RecognizerData", "cmudict-en-us.dict");
        }
        public static string defaultTempFolderPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "Temp");
        }
    }
}