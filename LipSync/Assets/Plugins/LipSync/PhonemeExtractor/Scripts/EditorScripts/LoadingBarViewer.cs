using UnityEditor;

namespace DataCleaning
{
    public class LoadingBarViewer : EditorWindow
    {
        #region Singleton
        private static LoadingBarViewer instance;
        public static LoadingBarViewer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoadingBarViewer();
                }
                return instance;
            }
        }
        #endregion

        private static EditorWindow editorWindow;
        private static bool isLoadingBarVisible = false;
        private static string messageToDisplay = "";
        private static float progress = 0;
        private static int phase = 0;

        [MenuItem("Tools/Quit test Loading bar")]
        public static void StartLoading()
        {
            SetInitialValues(true);
            UpdateLoadingBar();
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }

        [MenuItem("Tools/NextPhase")]
        public static void SetNextPhase()
        {
            if (isLoadingBarVisible == true && phase < LoadingBarMessages.GetAllPhaseNames().Length)
            {
                phase++;
                progress = phase * 25;
                messageToDisplay = LoadingBarMessages.GetAllPhaseNames()[phase];
            }
            UpdateLoadingBar();
        }

        private static void UpdateLoadingBar()
        {
            if (isLoadingBarVisible)
            {
                if (progress < 100)
                {
                    EditorUtility.DisplayProgressBar("Working...", messageToDisplay, progress / 100);
                }
                else
                {
                    SetInitialValues(false);
                    EditorUtility.ClearProgressBar();
                    EditorUtility.DisplayDialog("Completed", "Lip sync data has been successfully generated", "Ok");
                }
            }
        }

        private static void SetInitialValues(bool visible)
        {
            phase = 0;
            messageToDisplay = LoadingBarMessages.GetAllPhaseNames()[phase];
            isLoadingBarVisible = visible;
            progress = 0;
        }
    }
}