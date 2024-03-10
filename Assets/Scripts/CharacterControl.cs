using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject player;
    public bool isMoving;
    public float leftRightMove;
    public float upDownMove;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;
            player.GetComponent<Animator>().Play("walking");
            leftRightMove = Input.GetAxis("Horizontal") * Time.deltaTime * 200;
            upDownMove = Input.GetAxis("Vertical") * Time.deltaTime * 3.5f;
            player.transform.Rotate(0, leftRightMove, 0);
            player.transform.Translate(0, 0, upDownMove);
        }
        else 
        { 
            isMoving = false;
            player.GetComponent<Animator>().Play("idle");
        }

    }
}
