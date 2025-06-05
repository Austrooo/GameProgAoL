using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject[] cameraObjects;

    private void Start()
    {
        SetDefaultPriority();
    }
    public void SwitchPriority(int a, int b)
    {
        CinemachineVirtualCamera camA = cameraObjects[a-1].GetComponent<CinemachineVirtualCamera>();
        CinemachineVirtualCamera camB = cameraObjects[b-1].GetComponent<CinemachineVirtualCamera>();

        int temp = camA.Priority;
        camA.Priority = camB.Priority;
        camB.Priority = temp;
    }

    public void SetDefaultPriority()
    {
        foreach (GameObject camObj in cameraObjects)
        {
            CinemachineVirtualCamera cam = camObj.GetComponent<CinemachineVirtualCamera>();
            cam.Priority = 0;
        }
        cameraObjects[0].GetComponent<CinemachineVirtualCamera>().Priority = 10;
    }

    public void SetPriority(int a)
    {
        foreach (GameObject camObj in cameraObjects)
        {
            CinemachineVirtualCamera cam = camObj.GetComponent<CinemachineVirtualCamera>();
            cam.Priority = 0;
        }
        cameraObjects[a - 1].GetComponent<CinemachineVirtualCamera>().Priority = 10;
    }

}
