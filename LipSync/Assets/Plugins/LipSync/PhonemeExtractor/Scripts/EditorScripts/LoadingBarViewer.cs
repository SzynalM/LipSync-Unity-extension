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
                    instance = CreateInstance<LoadingBarViewer>();
                }
                return instance;
            }
        }
        #endregion

        private EditorWindow editorWindow;
        private bool isLoadingBarVisible = false;
        private string messageToDisplay = "";
        private float progress = 0;
        private int phase = 0;

        public void StartLoading()
        {
            SetInitialValues(true);
            UpdateLoadingBar();
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }

        public void SetNextPhase()
        {
            if (isLoadingBarVisible == true && phase < LoadingBarMessages.GetAllPhaseNames().Length)
            {
                phase++;
                progress = phase * 25;
                messageToDisplay = LoadingBarMessages.GetAllPhaseNames()[phase];
            }
            UpdateLoadingBar();
        }

        private void UpdateLoadingBar()
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

        private void SetInitialValues(bool visible)
        {
            phase = 0;
            messageToDisplay = LoadingBarMessages.GetAllPhaseNames()[phase];
            isLoadingBarVisible = visible;
            progress = 0;
        }
    }
}