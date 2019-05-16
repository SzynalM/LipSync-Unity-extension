using PhonemeExtractor.SetupWindow;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;

namespace PhonemeExtractor
{
    //CMD Arguments: AcousticModel DictionaryPath WavFilePath TranscriptionString TempFolderPath 
    public class PhonemeExtractor_Main
    {
        //May be extracted to separate static class
        public static AudioClip audioClip;
        public static string textTranscripton = "";
        public static string audioFilePath = "";

        private DataManager dataManager = new DataManager();
        private WindowData currentPaths;

        public void RunPhonemeExtractor(AudioClip audioFile, string transcription)
        {
            audioClip = audioFile;
            textTranscripton = transcription;
            audioFilePath = AssetDatabase.GetAssetPath(audioFile);
            currentPaths = dataManager.LoadWindowData();
            RunJavaProcess();
            DataCleaning.LoadingBarViewer.Instance.StartLoading();
        }

        void RunJavaProcess()
        {
            Process javaPhonemeExtractor = new Process();
            javaPhonemeExtractor.EnableRaisingEvents = true;
            javaPhonemeExtractor.StartInfo = new ProcessStartInfo()
            {
                FileName = "java",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Minimized,
                Arguments =
                     " -jar "
                    + currentPaths.PluginPath + " "
                    + currentPaths.AcousticModelPath + " "
                    + currentPaths.DictionaryPath + " "
                    + audioFilePath + " "
                    + "\"" + textTranscripton + "\" "
                    + currentPaths.TempFolderPath
            };
            javaPhonemeExtractor.Start();
        }
    }
}

