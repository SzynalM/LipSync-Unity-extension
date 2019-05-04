#if UNITY_EDITOR
using UnityEditor;
#endif
using PhonemeExtractor.SetupWindow;

public class EditorPrefsCleaner 
{
#if UNITY_EDITOR

    [MenuItem("Tools/Phoneme Extractor/Restore default configuration")]
    private static void ClearEditorPrefs()
    {
        foreach(string pref in CustomEditorPrefs.GetCustomEditorPrefs())
        {
            EditorPrefs.DeleteKey(pref);
        }
    }
#endif
}
