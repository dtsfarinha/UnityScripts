using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public PlayerMovement play;
    public Transform player;
    public float var = 1.65f;
    public float varc = 1f;
    public Vector3 cam;
    bool anchor ;
    public float pos = 0f;
    public float yup = 2.65f;
    public float ydown = 2f;
    public float z = -2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fixCrouch();
        anchor = play.isCrouch;
        transform.position = player.position + cam;
    }

    void fixCrouch()
    {
        if (anchor)
        {
            cam = new Vector3(0f, varc, pos);

            ////////////////
            // third person test crouch

            //cam = new Vector3(0f, ydown, z);


        }
        else
        {
            cam = new Vector3(0f, var, pos);

            ////////////////
            // third person test up

            //cam = new Vector3(0f, yup, z);

        }
    }
}
