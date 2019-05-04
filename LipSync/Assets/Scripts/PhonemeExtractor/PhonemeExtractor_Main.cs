using System.Diagnostics;
using UnityEngine;

namespace PhonemeExtractor.SetupWindow
{
    //CMD Arguments: AcousticModel DictionaryPath WavFilePath TranscriptionString TempFolderPath
    public class PhonemeExtractor_Main : MonoBehaviour //monobehaviour to be deleted when there's a button running the function
    {
        private CurrentPaths currentPaths;
        private DataManager dataManager = new DataManager();

        [ContextMenu("Extract phonemes")]
        private void RunPhonemeExtrapolator()
        {
            string audioFilePath = @"D:/Projects/LipSync/LipSync/Assets/Test/AudioFiles/test.wav";
            string transcription = "One, zero, zero, one.";
            currentPaths = dataManager.LoadWindowData();
            Process javaPhonemeExtractor = new Process();
            javaPhonemeExtractor.StartInfo.UseShellExecute = true;
            javaPhonemeExtractor.StartInfo.FileName = "java";
            javaPhonemeExtractor.StartInfo.Arguments =
                " -jar "
                + currentPaths.PluginPath + " "
                + currentPaths.AcousticModelPath + " "
                + currentPaths.DictionaryPath + " "
                + audioFilePath + " "
                + "\"" + transcription + "\" "
                + currentPaths.TempFolderPath;
            UnityEngine.Debug.Log(javaPhonemeExtractor.StartInfo.Arguments);
            javaPhonemeExtractor.Start();


            //javaPhonemeExtractor.StartInfo.Arguments =
            //    " -jar D:/Projects/LipSync/LipSync/Assets/Plugins/PhonemeExtractor/PhonemeExtractor.jar D:/Projects/LipSync/LipSync/Assets/Plugins/PhonemeExtractor/RecognizerData/AcousticModel D:/Projects/LipSync/LipSync/Assets/Plugins/PhonemeExtractor/RecognizerData/cmudict-en-us.dict D:/Projects/LipSync/LipSync/Assets/Test/AudioFiles/test.wav \"one zero zero one\" D:/Projects/LipSync/LipSync/Assets/Plugins/PhonemeExtractor/Temp";
        }
    }
}

