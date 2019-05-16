using UnityEngine;

public class CameraSwapper : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private Camera camera_01;
    [SerializeField]
    private Camera camera_02;

    public void SwapCameras()
    {
        camera_01.gameObject.SetActive(!camera_01.gameObject.activeSelf);
        camera_02.gameObject.SetActive(!camera_02.gameObject.activeSelf);
    }
}
