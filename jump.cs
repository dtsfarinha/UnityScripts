using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [Range(1,10)]
    public float jumpVelocity;
    public Rigidbody rb;
    public Transform player;
    public Transform GroundCheck;
    public Transform WallCheckR;
    public Transform WallCheckL;
    public bool ground ;
    public bool wallR, wallL;
    public LayerMask whatIsGround;
    private static bool running;
    public float radius = 0.2f;
    public bool readyJump = true;
    public bool readyWallJumpR = true;
    public bool readyWallJumpL = true;
    [Range(1,10)]
    public float jumpCooldown = 0.4f;
    public float wallJumpVelocity = 6;
    public Vector3 WjumpR = new Vector3(2f, 2f, 0f);
    public Vector3 WjumpL = new Vector3(-2f, 2f, 0f);
    public Vector3 JumpVector = new Vector3();

    void Start()
    {

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        running = PlayerMovement.isRun;
        Jump();
        wallJumpR();
        wallJumpL();
        Grounded();
    }
    
    void Grounded()
    {
        ground = Physics.OverlapSphere(GroundCheck.position, radius, whatIsGround).Length >0;

        if ( ground)
        {
            readyJump = true;
            readyWallJumpL = true;
            readyWallJumpR = true;
        }
    }

    void Jump()
    {
        ground = Physics.OverlapSphere(GroundCheck.position, radius, whatIsGround).Length >0;

        //Pre-test Part (WORKS)
        if(Input.GetAxis("Jump" )!= 0 && ground &&  readyJump)
        {
            readyJump = false;
            rb.velocity =  Vector3.up * jumpVelocity;
            //Invoke("ResetJump",jumpCooldown);
            //Debug.Log(Input.GetAxis("Jump"));
        }
        // if(Input.GetAxis("Jump") == 0 && ground )
        // {
        //     ResetJump();
        // }
        
        
    }

    void wallJumpR()
    {
        wallR = Physics.OverlapSphere(WallCheckR.position, radius, whatIsGround).Length >0;

        if (Input.GetAxis("Jump" )!= 0 && wallR && readyWallJumpR && running)
        {
            readyJump = false;
            readyWallJumpR = false;
            readyWallJumpL = true;
            JumpVector = transform.right * WjumpR.x + Vector3.up + transform.forward * WjumpR.z;
            rb.velocity =  JumpVector * wallJumpVelocity;
            Invoke("ResetJump",jumpCooldown);
        }
        // if(ground)
        // {
        //     ResetWallJump();
        // }
    }

    void wallJumpL()
    {
        wallL = Physics.OverlapSphere(WallCheckL.position, radius, whatIsGround).Length >0;

        if (Input.GetAxis("Jump" )!= 0 && wallL && readyWallJumpL && running)
        {
            readyJump = false;
            readyWallJumpL = false;
            readyWallJumpR = true;
            JumpVector = transform.right * WjumpL.x + Vector3.up + transform.forward * WjumpL.z;
            rb.velocity =  JumpVector * wallJumpVelocity;
            readyJump = false;
            Invoke("ResetJump",jumpCooldown);
        }
        // if(ground)
        // {
        //     ResetWallJump();
        // }
    }

    void ResetJump()
    {
        readyJump = true;
    }

    void ResetWallJump()
    {
        readyWallJumpL = true;
        readyWallJumpR = true;
    }

}
