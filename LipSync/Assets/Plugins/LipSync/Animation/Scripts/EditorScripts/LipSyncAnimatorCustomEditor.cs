using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LipSyncAnimator))]
public class LipSyncAnimatorCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LipSyncAnimator myTarget = (LipSyncAnimator)target;

        EditorGUILayout.Space();

        if(GUILayout.Button("Play selected animation") == true)
        {
            myTarget.PlayLipSyncAnimation();
        }
    }
}
