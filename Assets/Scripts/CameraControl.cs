using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera cameraToUse;
    public GameObject supViewCamera;
    public bool isTrigger = false;

    void Start()
    {
        supViewCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void FixedUpdate()
    {
        if (isTrigger)
        {
            if (supViewCamera.activeSelf == false)
            {
                cameraToUse.gameObject.SetActive(true);
            }
            else if (supViewCamera.activeSelf != false)
            {
                cameraToUse.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = true;
            cameraToUse.enabled = true;
            cameraToUse.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = false;
            cameraToUse.gameObject.SetActive(false);
            cameraToUse.enabled = false;
        }
    }
}
