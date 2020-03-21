using PhonemeExtractor.SetupWindow;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;

namespace PhonemeExtractor
{ 
    //CMD Arguments: AcousticModel DictionaryPath WaveFilePath TranscriptionString TempFolderPath 
    public class PhonemeExtractor_Main
    {
        public static AudioClip audioClip;
        public static string textTranscripton = "";
        public static string pathToConvertedFile;

        private DataManager dataManager = new DataManager();
        private WindowData currentPaths;

        public void RunPhonemeExtractor(AudioClip audioFile, string transcription, string _pathToConvertedFile)
        {
            audioClip = audioFile;
            pathToConvertedFile = _pathToConvertedFile;
            textTranscripton = transcription;
            currentPaths = dataManager.LoadWindowData();
            RunJavaProcess();
            DataCleaning.LoadingBarViewer.Instance.StartLoading();
        }

        private void RunJavaProcess()
        {
            string arguments = " -jar "
                    + currentPaths.PluginPath + " "
                    + currentPaths.AcousticModelPath + " "
                    + currentPaths.DictionaryPath + " "
                    + pathToConvertedFile + " "
                    + "\"" + textTranscripton + "\" "
                    + currentPaths.TempFolderPath;
             
            Process javaPhonemeExtractor = new Process();
            javaPhonemeExtractor.EnableRaisingEvents = true;
            javaPhonemeExtractor.StartInfo = new ProcessStartInfo()
            {
                FileName = "java",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Minimized,
                Arguments = arguments
            };
            javaPhonemeExtractor.Start();
        }
    }
}

