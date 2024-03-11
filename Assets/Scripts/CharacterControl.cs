using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterControl : MonoBehaviour
{
    /// <summary>
    /// This class is used to control the player movement and triggers on the keyboard.
    /// </summary>


    public GameObject player;
    public Camera pMainCamera;
    public GameObject[] allRoofs;

    public bool isMoving;
    public float leftRightMove;
    public float upDownMove;

    void Start()
    {
        allRoofs = GameObject.FindGameObjectsWithTag("Roof");
    }

    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;
            
            if (Input.GetButton("Run"))
            {
                player.GetComponent<Animator>().Play("running");
                leftRightMove = Input.GetAxis("Horizontal") * Time.deltaTime * 120;
                upDownMove = Input.GetAxis("Vertical") * Time.deltaTime * 10;

            }
            else 
            {
                player.GetComponent<Animator>().Play("walking");
                leftRightMove = Input.GetAxis("Horizontal") * Time.deltaTime * 120;
                upDownMove = Input.GetAxis("Vertical") * Time.deltaTime * 4;
            }
            player.transform.Rotate(0, leftRightMove, 0);
            player.transform.Translate(0, 0, upDownMove);
        }
        else 
        { 
            isMoving = false;
            player.GetComponent<Animator>().Play("idle");
        }

        if (Input.GetButton("SupView"))
        {
            /// <remarks>
            ///  When the user inputs the "space" key on the keyboard, the roof hides and the camera that follows the player is enabled. 
            /// </remarks>
            foreach (GameObject roof in allRoofs)
            {
                roof.SetActive(false);
            }
            pMainCamera.enabled = true;
            pMainCamera.gameObject.SetActive(true);
        }
        else
        {
            foreach (GameObject roof in allRoofs)
            {
                roof.SetActive(true);
            }
            pMainCamera.gameObject.SetActive(false);
        }

    }
}