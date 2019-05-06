using PhonemeExtractor.SetupWindow;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using VisemeExtractor;

namespace PhonemeExtractor
{
    //CMD Arguments: AcousticModel DictionaryPath WavFilePath TranscriptionString TempFolderPath
    public class PhonemeExtractor_Main : MonoBehaviour //monobehaviour to be deleted when there's a button running the function
    {
        private event Action OnProcessStarted;
        private event Action<string> OnProcessEnded;
        private DataManager dataManager = new DataManager();
        private VisemeExtractor_Main visemeExtractor = new VisemeExtractor_Main();
        private CurrentPaths currentPaths;

        [ContextMenu("Extract phonemes")]
        public void RunPhonemeExtrapolator() //arguments string audioFilePath, string transcription will be added later
        {
            Initialize();
            StartCoroutine(RunProcess(@"D:/Projects/LipSync/LipSync/Assets/Test/AudioFiles/test.wav", "One, zero, zero, one.")); //arguments are to be passed through the upper method
        }

        private IEnumerator RunProcess(string audioFilePath, string transcription)
        {
            currentPaths = dataManager.LoadWindowData();

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
                    + "\"" + transcription + "\" "
                    + currentPaths.TempFolderPath
            };
            OnProcessStarted?.Invoke();
            javaPhonemeExtractor.Start();
            yield return new WaitUntil(() => javaPhonemeExtractor.HasExited == true);
            OnProcessEnded?.Invoke(currentPaths.TempFolderPath);
            Terminate();
        }

        private void Initialize()
        {
            OnProcessEnded += visemeExtractor.ExtractVisemes;
        }

        private void Terminate()
        {
            OnProcessEnded -= visemeExtractor.ExtractVisemes;
        }
    }
}

