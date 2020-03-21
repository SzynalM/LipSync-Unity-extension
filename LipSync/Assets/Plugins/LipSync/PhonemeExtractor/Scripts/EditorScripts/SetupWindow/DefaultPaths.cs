using UnityEngine;
using System.IO;

namespace PhonemeExtractor.SetupWindow
{
    public class DefaultPaths
    {
        public static string defaultPluginPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor", "PhonemeExtractor.jar").Replace(@"/", "\\\\");
        }
        public static string defaultAcousticModelPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor", "RecognizerData", "AcousticModel").Replace(@"/", "\\\\");
        }
        public static string defaultDictionaryPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor", "RecognizerData", "cmudict-en-us.dict").Replace(@"/", "\\\\");
        }
        public static string defaultTempFolderPath
        {
            get => Path.Combine(Application.dataPath, "Plugins", "LipSync", "PhonemeExtractor", "Temp").Replace(@"/", "\\\\");
        }
        public static string defaultDialogueSavingPath
        {
            get => Path.Combine("Assets", "Plugins", "LipSync", "Animation", "DefaultDialogueFolder").Replace(@"/", "\\\\");
        }
    }
}