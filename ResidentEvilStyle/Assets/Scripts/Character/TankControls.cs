using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{

    public GameObject player;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;
    public bool isRunning;
    public bool backwardsCheck = false;
    public Rigidbody rb;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;
            if (Input.GetButton("SKey"))
            {
                backwardsCheck = true;
                player.GetComponent<Animator>().Play("WalkBack");
            }
            else
            {
                backwardsCheck = false;
                if (isRunning)
                {
                    player.GetComponent<Animator>().Play("Run");
                }
                else
                {
                    player.GetComponent<Animator>().Play("Walk");
                }
            }
            
            if (isRunning && !backwardsCheck)
            {
                verticalMove = Input.GetAxis("Vertical") * 15.1f;
            }
            else
            {
                verticalMove = Input.GetAxis("Vertical") * 4.8f;
            }
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
            player.transform.Rotate(0, horizontalMove, 0);
            rb.velocity = transform.forward * verticalMove;

        }
        else
        {
            isMoving = false;
            rb.velocity = Vector3.zero;
            player.GetComponent<Animator>().Play("Idle");
        }
    }
}
