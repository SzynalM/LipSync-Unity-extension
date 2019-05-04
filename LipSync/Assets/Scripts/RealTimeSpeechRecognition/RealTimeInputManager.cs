using System;
using UnityEngine;

public class RealTimeInputManager : MonoBehaviour
{
    public Action<bool> OnRecordingStarted;

    void Update()
    {
        if (Input.GetButtonDown("Recording"))
        {
            if (OnRecordingStarted != null)
            {
                OnRecordingStarted.Invoke(true);
            }
        }
        else if (Input.GetButtonUp("Recording"))
        {
            if (OnRecordingStarted != null)
            {
                OnRecordingStarted.Invoke(false);
            }
        }
    }
}
