using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera cameraToUse;
    public GameObject supViewCamera;

    void Start()
    {
        supViewCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerStay(Collider other)
    {
        cameraToUse.enabled = true;

        if (other.tag == "Player" && supViewCamera.activeSelf == false)
        {
            cameraToUse.gameObject.SetActive(true);
        }
        else if (other.tag == "Player" && supViewCamera.activeSelf != false)
        {
            cameraToUse.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraToUse.gameObject.SetActive(false);
            cameraToUse.enabled = false;
        }
    }
}
