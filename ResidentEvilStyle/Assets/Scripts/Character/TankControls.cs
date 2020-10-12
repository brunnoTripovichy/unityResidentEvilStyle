using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{

    [SerializeField] BodyCamMotionScript bodyCamMotionScript;

    [SerializeField] float bodyCamBobSpeed, idleHeadBob;

    public bool canMove;
    public GameObject player;
    public GameObject currentCamera;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;
    public bool isRunning;
    public bool isCrouching;
    public bool backwardsCheck = false;
    public Rigidbody rb;
    public PlayerStealthBehaviour psb;

    private float movementCounter, idleCounter;

    private Animator animator;

    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    void Update()
    {
        float distance = 0;
        distance = CheckIfCanMove(distance);
    }

    private float CheckIfCanMove(float distance)
    {
        if (canMove)
        {
            CheckIfIsCrouching();
            CheckIfIsRunning();

            distance = ProcessMovement(distance);
        }

        return distance;
    }

    private void CheckIfIsRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void CheckIfIsCrouching()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
    }

    private float ProcessMovement(float distance)
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;
            if (Input.GetButton("SKey"))
            {
                ProcessMovingBackwards();
            }
            else
            {
                ProcessMovingForwards();
            }

            distance = ProcessMovementVelocity();

        }
        else
        {
            ProcessStopMoving();
        }

        return distance;
    }

    private float ProcessMovementVelocity()
    {
        float distance;
        if (isRunning && !backwardsCheck)
        {
            verticalMove = Input.GetAxis("Vertical") * 14;
        }
        else
        {
            if (isCrouching)
            {
                verticalMove = Input.GetAxis("Vertical") * 4;
            }
            else
            {
                verticalMove = Input.GetAxis("Vertical") * 4.8f;
            }

        }

        horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
        player.transform.Rotate(0, horizontalMove, 0);
        rb.velocity = transform.forward * verticalMove;

        distance = Vector3.Distance(player.transform.position, currentCamera.transform.position);
        return distance;
    }

    private void ProcessMovingForwards()
    {
        backwardsCheck = false;
        if (isRunning && !isCrouching)
        {
            ResetAnimations();
            animator.SetBool("Running", true);
        }
        else if (isCrouching)
        {
            ResetAnimations();
            animator.SetBool("Crouching", true);
        }
        else
        {
            ResetAnimations();
            animator.SetBool("Walking", true);
        }
    }

    private void ProcessMovingBackwards()
    {
        backwardsCheck = true;
        ResetAnimations();
        if (backwardsCheck && !isCrouching)
        {
            animator.SetBool("WalkingBack", true);
        }
        else
        {
            animator.SetBool("CrouchingBack", true);
        }
    }

    private void ProcessStopMoving()
    {
        isMoving = false;
        rb.velocity = Vector3.zero;

        if (isCrouching)
        {
            ResetAnimations();
            animator.SetBool("CrouchingIdle", true);
        }
        else
        {
            ResetAnimations();
        }

        //BodyCam Bob
        //bodyCamMotionScript.HeadBob(idleHeadBob, idleHeadBob, idleCounter);
        //idleCounter += Time.deltaTime;
        //bodyCamMotionScript.IdleBob(bodyCamBobSpeed);
    }

    private void ResetAnimations()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("WalkingBack", false);
        animator.SetBool("Running", false);
        animator.SetBool("CrouchingIdle", false);
        animator.SetBool("Crouching", false);
        animator.SetBool("CrouchingBack", false);
    }

    public void StartStealthKill(GameObject target)
    {
        ResetAnimations();
        canMove = false;
        animator.SetTrigger("StealthKill");
    }

    public void FinishStealthKill()
    {
        canMove = true;
        psb.isStrangling = false;
    }
}
