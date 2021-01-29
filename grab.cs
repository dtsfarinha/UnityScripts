using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    
    public Transform player;
    Vector3 moveStart, moveEnd, move;
    RaycastHit hit, oldHit;
    public float distance = 2.5f;
    int maskLayer = 1<<9;
    float speed = 2f;
    public bool isPicked,isThrew,canPickUp;
    public float throwCooldown = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        maskLayer = ~maskLayer;
        isThrew = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(Input.GetKey("mouse 1"))
        {   
            if((isPicked == false) /*&& (isThrew == false)*/)
            {
                getRay();
            }
            if(isPicked &&  !(Input.GetKey("mouse 0")))
            {
                PickUp();
            }
            else if(Input.GetKey("mouse 0"))
            {
                Throw();
                
            }
            else
            {
                
                //Debug.Log("sad,nocube");
                isPicked = false;
            }
            
            

            //isThrew = false;

            //Debug.Log("1");
            // if(Physics.Raycast(player.position, transform.TransformDirection(Vector3.forward), 10))
            // {
            //     Debug.Log("2");
            // }
            //Debug.Log(transform.position);
            // if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out nohit, distance)
            // {
            // }
            
        }
        else
        {
            if(isPicked)
            hit.rigidbody.constraints = RigidbodyConstraints.None;
            isPicked = false;
        }
    }

    void PickUp()
    {
        if(isThrew == true)
        {
            hit.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            hit.transform.position = transform.position + transform.forward;
        }
        else
        {
            hit.rigidbody.constraints = RigidbodyConstraints.None;
            isPicked = false;
        }
        
    } 

    void Throw()
    {
        if(isPicked)
        {
            isThrew = false;
            isPicked = false;
            hit.rigidbody.AddForce(transform.forward * speed,ForceMode.Impulse);
            hit.rigidbody.constraints = RigidbodyConstraints.None;
            Invoke("ReadyThrow", throwCooldown);
            
            
        }
    }

    void ReadyThrow()
    {
        isThrew = true;
    }

    void getRay()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, maskLayer))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                isPicked = true;

                //Debug.Log(hit.transform.position);
                //moveStart = hit.transform.position;
                //moveEnd = trns.position;
                //moveEnd = transform.position + Vector3.forward * distance;
                //move = (moveEnd - moveStart);
                //hit.transform.position = trns.position + transform.forward;
                //Debug.Log(move);
                ////////////
                //hit.rigidbody.AddForce(move,ForceMode.Impulse);
                //hit.transform.position = trns.position;
                //////////////
                //hit.rigidbody.MovePosition(trns.position );
                // if(Input.GetKeyDown("e"))
                // {
                //     hit.transform.position = trns.position;
                // }
            }
    }

}
