using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterMovement : MonoBehaviour
{
    //private string fpsText;
    //public float deltaTime;
    //-------------------------------------------------------------------------------------------------
    public float speed;
    private Rigidbody myRigidbody;
    public Vector3 change;
    //public List<KeyCode> listed_buttons;
    //-------------------------------------------------------------------------------------------------
    void Start()
    {
        //Application.targetFrameRate = 50;
        myRigidbody = GetComponent<Rigidbody>();
    }
    //-------------------------------------------------------------------------------------------------
    private void Update() => GetInput();
    //-------------------------------------------------------------------------------------------------
    void FixedUpdate()
    {
        if (Mathf.Abs(change.x) < 1 && Mathf.Abs(change.z) < 1) return;
        UpdateMovement();
    }
    //-------------------------------------------------------------------------------------------------
    void UpdateMovement()
    {
        if (change != Vector3.zero)
        {
            if (Mathf.Abs(change.x) == 1 && Mathf.Abs(change.z) == 1)
            {
                float xpos = (float)(change.x * 0.707);
                float zpos = (float)(change.z * 0.707);
                myRigidbody.MovePosition(new Vector3(myRigidbody.position.x, myRigidbody.position.y, myRigidbody.position.z) + new Vector3(xpos, 0, zpos) * speed * Time.fixedDeltaTime);
            }
            else
            {
                myRigidbody.MovePosition(new Vector3(myRigidbody.position.x, myRigidbody.position.y, myRigidbody.position.z) + change * speed * Time.fixedDeltaTime);
            }
            change = Vector3.zero;
        }
    }
    //-------------------------------------------------------------------------------------------------
    void GetInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            change.x = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            change.x = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            change.z = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            change.z = -1;
        }
        
    }
    //-------------------------------------------------------------------------------------------------

    //first_pressed = GetFirstButton();

    /*if (first_pressed != KeyCode.None)
    {
        if (first_pressed == KeyCode.UpArrow)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {

                change.x = 1;
                change.z = 0;
                change.y = 0;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                change.x = -1;
                change.z = 0;
                change.y = 0;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {

                change.x = 0;
                change.z = -1;
                change.y = 0;
            }
            else
            {

                change.x = 0;
                change.z = 1;
                change.y = 0;

            }
        }
        if (first_pressed == KeyCode.DownArrow)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {

                change.x = 1;
                change.z = 0;
                change.y = 0;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {

                change.x = -1;
                change.z = 0;
                change.y = 0;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {

                change.x = 0;
                change.z = 1;
                change.y = 0;
            }
            else
            {

                change.x = 0;
                change.z = -1;
                change.y = 0;

            }
        }
        if (first_pressed == KeyCode.LeftArrow)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {

                change.x = 0;
                change.z = 1;
                change.y = 0;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {

                change.x = 0;
                change.z = -1;
                change.y = 0;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                change.x = 1;
                change.z = 0;
                change.y = 0;
            }
            else
            {

                change.x = -1;
                change.z = 0;
                change.y = 0;
            }
        }
        if (first_pressed == KeyCode.RightArrow)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                //transform.Translate(Vector3.up * speed * Time.deltaTime);
                change.x = 0;
                change.z = 1;
                change.y = 0;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //transform.Translate(Vector3.down * speed * Time.deltaTime);
                change.x = 0;
                change.z = -1;
                change.y = 0;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                //transform.Translate(Vector3.left * speed * Time.deltaTime);
                change.x = -1;
                change.z = 0;
                change.y = 0;
            }
            else
            {
                //transform.Translate(Vector3.right * speed * Time.deltaTime);
                change.x = 1;
                change.z = 0;
                change.y = 0;

            }

        }
    }*/
}
