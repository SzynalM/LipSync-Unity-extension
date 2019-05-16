using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LipSyncAnimator))]
public class LipSyncAnimatorCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LipSyncAnimator myTarget = (LipSyncAnimator)target;

        EditorGUILayout.Space();

        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            if (GUILayout.Button("Play selected animation") == true)
            {
                myTarget.PlayLipSyncAnimation();
            }
        }
    }
}
