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
    public Vector3 change;
    private Quaternion targetRotation;
    private Quaternion fixedQ = new Quaternion(0, 0, 0, 1);
    private Quaternion lastRotation;
    public Stack<KeyCode> listed_buttons;
    //--------------------------------------------------------------------------------------------------
    void Start()
    {
        
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
  
        CalculateDirection();
        Rotate();
        GetInput();
        UpdateMovement();
    }
    void CalculateDirection()
    {
        angle = Mathf.Atan2(change.x, change.z);
        angle *= Mathf.Rad2Deg;
    }

    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
    void UpdateMovement()
    {
        if (change != Vector3.zero)
        {
            if (Mathf.Abs(change.x) == 1 && Mathf.Abs(change.z) == 1) // eina istrizai
            {
                change *= 0.707f;
            }
            playerAnim.SetBool("walking", true);
            myRigidbody.MovePosition(myRigidbody.position + change * speed * Time.fixedDeltaTime);
        }
       
    }
    void GetInput()
    {


        change = Vector3.zero;
        playerAnim.SetBool("walking", false);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            change.z = 1;
            
            
        }
            
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (change.z == 1)
            {
                change = Vector3.zero;
                return;
            }
            change.z = -1;
            
           
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