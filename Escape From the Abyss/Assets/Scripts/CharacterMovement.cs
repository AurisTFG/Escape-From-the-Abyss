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
    private Vector3 change;
    public List<KeyCode> listed_buttons;
    //-------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 80;
        myRigidbody = GetComponent<Rigidbody>();
    }
    //-------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        //deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        //float fps = 1.0f / deltaTime;
        //fpsText = Mathf.Ceil(fps).ToString();
        //Debug.Log(fpsText);

        change = Vector3.zero;
        KeyCode first_pressed;
      
        
        first_pressed = GetFirstButton();

        if (first_pressed != KeyCode.None)
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
        }

        UpdateMovement();


    }
   
    void UpdateMovement()
    {
        if (change != Vector3.zero)
        {
            //myRigidbody.MovePosition(transform.position + change * Time.deltaTime * speed);
            myRigidbody.MovePosition(new Vector3(myRigidbody.position.x, myRigidbody.position.y, myRigidbody.position.z) + change * speed * Time.fixedDeltaTime);
        }
    }
    KeyCode GetFirstButton()
    {
        KeyCode first_pressed = KeyCode.None;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            listed_buttons.Add(KeyCode.UpArrow);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            listed_buttons.Add(KeyCode.DownArrow);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            listed_buttons.Add(KeyCode.RightArrow);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            listed_buttons.Add(KeyCode.LeftArrow);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            listed_buttons.Remove(KeyCode.UpArrow);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            listed_buttons.Remove(KeyCode.DownArrow);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            listed_buttons.Remove(KeyCode.RightArrow);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            listed_buttons.Remove(KeyCode.LeftArrow);
        }

        if (listed_buttons.Count != 0)
        {
            first_pressed = listed_buttons[0];
        }
        return first_pressed;
    }
}
