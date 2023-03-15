using UnityEngine;
using System.Collections.Generic;
public class CharacterMovement : MonoBehaviour
{
    //--------------------------------------------------------------------------------------------------
    public Animator playerAnim; 
    private Rigidbody myRigidbody;
    //--------------------------------------------------------------------------------------------------
    private float angle;
    public float speed;
    public float turnSpeed;
    private Vector3 change, forward, right;
    private Quaternion targetRotation;
    private Quaternion fixedQ = new Quaternion(0, 0, 0, 1);
    private Quaternion lastRotation;
    public Stack<KeyCode> listed_buttons;
    //--------------------------------------------------------------------------------------------------
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        myRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        if (playerAnim.GetBool("walking"))
        {
            lastRotation = myRigidbody.transform.rotation;
        }
        else
        {
            myRigidbody.transform.rotation = lastRotation;
        }    

        GetInput();
        UpdateMovement();
    }


    void UpdateMovement()
    {
        if (change != Vector3.zero)
        {

            playerAnim.SetBool("walking", true);
            change = Vector3.ClampMagnitude(change, 1f);
            Vector3 rightMovement = right * speed * Time.deltaTime * change.z;
            Vector3 upMovement = forward * speed * Time.deltaTime * change.x;

            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

            transform.forward = Vector3.Lerp(transform.forward, heading, 0.1f);
            myRigidbody.position += rightMovement + upMovement;
        }

    }
    void GetInput()
    {


        change = Vector3.zero;
        playerAnim.SetBool("walking", false);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            change.z = -1;
            
            
        }
            
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (change.z == -1)
            {
                change = Vector3.zero;
                return;
            }
            change.z = 1;
            
           
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            change.x = -1;
           
            
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
           
            if (change.x == -1)
            {
                change = Vector3.zero;
                return;
            }
            change.x = 1;
           
            
        }
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            listed_buttons.Push(KeyCode.UpArrow);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            listed_buttons.Push(KeyCode.DownArrow);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            listed_buttons.Push(KeyCode.RightArrow);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            listed_buttons.Push(KeyCode.LeftArrow);
        }

        
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //listed_buttons.Peek();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //listed_buttons.Push(KeyCode.DownArrow);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if(listed_buttons.Peek() == KeyCode.RightArrow)
            {
                listed_buttons.Pop()
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
           // listed_buttons.Remove(KeyCode.LeftArrow);
        }*/

    }
    


}