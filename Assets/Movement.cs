using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool isOnGround;
    public bool isCrouching;

    public float speed;
    public float w_speed;
    public float r_speed;
    public float c_speed;
    public float rotSpeed;
    public float jumpHeight;

    Rigidbody body;
    //Animator anim;
    CapsuleCollider colliderSize;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        colliderSize = GetComponent<CapsuleCollider>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Toggling Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching)
            {
                isCrouching = false;
                //anim.SetBool("isCrouching", false);
                colliderSize.height = 2;
                colliderSize.center = new Vector3(0, 1, 0);
            }
            else
            {
                isCrouching = true;
                //anim.SetBool("isCrouching", true);
                speed = c_speed;
                colliderSize.height = 1;
                colliderSize.center = new Vector3(0, 0.5f, 0);
            }
        }

        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;

        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

        if (Input.GetKey(KeyCode.Space) && isOnGround == true)
        {
            body.AddForce(0, jumpHeight, 0);
           // anim.SetTrigger("isJumping");
            isCrouching = false;
            isOnGround = false;
        }
        if (isCrouching)
        {
            if (Input.GetKey(KeyCode.W))
            {
                /*anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);*/
            }
            else if (Input.GetKey(KeyCode.S))
            {
                /*anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);*/
            }
            else
            {
                /*anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);*/
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = r_speed;
            // Running Controls
            if (Input.GetKey(KeyCode.W))
            {
                /*anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", true);*/
            }
            else if (Input.GetKey(KeyCode.S))
            {
                /*anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", false);
                anim.SetBool("isRunning", true);*/
            }
            else
            {
                /*anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);*/
            }
        }

        else if (!isCrouching)
        {
            speed = w_speed;
            // Standing Controls
            if (Input.GetKey(KeyCode.W))
            {
                /*anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);*/
            }
            else if (Input.GetKey(KeyCode.S))
            {
                /*anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);*/
            }
            else
            {
                /*anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);*/
            }
        }
    }

    void OnCollisionEnter()
    {
        isOnGround = true;
    }
}
