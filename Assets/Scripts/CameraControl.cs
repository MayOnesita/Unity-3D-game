using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject prevCamera;
    public GameObject newCamera;

    public bool cameraOn = false;
    public int cameraNumber;

    void Start()
    {
        cameraNumber = 1;
        StartCoroutine(CameraSwitch());

        
    }

    IEnumerator CameraSwitch()
    {
        yield return new WaitForSeconds(5);
        newCamera.SetActive(true);
        prevCamera.SetActive(false);
        cameraOn = true;
        cameraNumber = 2;

    }

}
