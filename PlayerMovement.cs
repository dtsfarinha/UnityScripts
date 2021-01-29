using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 movement;
    public Vector3 crouchScale = new Vector3(1f, 0.5f, 1);
    public float Axvert, Axhor;
    public float speed;
    public  float runSpeed = 10.0f;
    public float walkSpeed = 5.0f;
    public float crouchSpeed = 2.5f;
    public float slideSpeed = 15.0f;
    private Vector3 playerScale;
    public bool isCrouch;
    public static bool isRun;
    public bool isMoving;
    [Range(1,10)]
    public float RunCooldown = 0.8f;
    public float slideVelocity = 100f;
    //int x = 0;
    //public Animator AnimPar;
 
    void Start()
    {   
        speed = walkSpeed;
        playerScale = transform.localScale;
        // readyToJump = true;

    }

    // Update is called once per frame
    void Update()
    {   
        Axvert = Input.GetAxis("Vertical");
        Axhor = Input.GetAxis("Horizontal");
        if (Axvert != 0f || Axhor != 0f )
        {
            //AnimPar.SetBool("Anim", true);
            isMoving = true;
        }
        else
        {
            //AnimPar.SetBool("Anim", false);
            isMoving = false;
        }
        // jumping = new Vector3(0f, Input.GetAxis("Jump"),0f);
        movement = new Vector3(Axhor,0f,Axvert);
        movement = transform.right * movement.x + transform.forward * movement.z;

    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    void run()
    {
        if (Input.GetButton("Sprint") )
        {   
            isRun = true;
            speed = runSpeed;
            //AnimPar.SetBool("sprint", true);
        }
        else
        {
            speed = walkSpeed;
            Invoke("NotRunning", RunCooldown);
            //AnimPar.SetBool("sprint", false);
        }
    }

    void NotRunning()
    {
        isRun = false;
    }
    
    void Crouch()
    {
        if (Input.GetButton("Crouch"))
        {
            StartCrouch();
        }
        else
            StopCrouch();
    }

    void StartCrouch()
    {   //AnimPar.SetBool("Crouch", true);
        isCrouch = true;
        transform.localScale = crouchScale;
        //transform.position = new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z);
        speed = crouchSpeed;
    }

    void StopCrouch()
    {
        //AnimPar.SetBool("Crouch", false);
        isCrouch = false;
        transform.localScale = playerScale;
        //transform.position = new Vector3(transform.position.x, transform.position.y +0.5f, transform.position.z);
        speed = walkSpeed;
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
        Crouch();
        run();
        slide(movement);
        if (isCrouch)
        {
            speed = crouchSpeed;
        }
        else if (isRun)
        {
            speed = runSpeed;
        }
        else
            speed = walkSpeed;
        
    }

    void slide(Vector3 direction)
    {
        if (isRun && Input.GetButton("Crouch"))
        {   
            speed = 0f;
            //x = x + 1;
            //print(x);
            rb.velocity =  direction  * slideSpeed;

            //x = x-1


        }

    }

    

    //     print(grounded);

    //     float x = Input.GetAxis("Horizontal");
    //     float z = Input.GetAxis("Vertical");
    //     bool jumping = Input.GetButton("Jump");

    //     //Vector2 mag = FindVelRelativeToLook();
    //     //float xMag = mag.x, zMag = mag.z;

    //     //CounterMovement(x,z,mag);

    //     //if(x > 0 && xMag > 5) x = 0;
    //     //if(x < 0 && xMag < -5)x = 0;
    //     //if(z > 0 && zMag > 5) z = 0;
    //     //if(z < 0 && zMag < -5)z = 0;

    //     //

    //     if ()
    //     rb.AddForce(transform.right * x * speed * Time.deltaTime);
    //     rb.AddForce(transform.forward * z * speed * Time.deltaTime);

    //     

    // 

}
