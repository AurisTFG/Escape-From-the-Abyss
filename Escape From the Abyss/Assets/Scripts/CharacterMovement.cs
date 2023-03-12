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
    public Vector3 change;
    //public List<KeyCode> listed_buttons;
    //-------------------------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 80;
        //Application.targetFrameRate = 50;
        myRigidbody = GetComponent<Rigidbody>();
    }
    //-------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    private void Update() => GetInput();
    //-------------------------------------------------------------------------------------------------
    void FixedUpdate()
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

        if (Mathf.Abs(change.x) < 1 && Mathf.Abs(change.z) < 1) return;
        UpdateMovement();


    }

    //-------------------------------------------------------------------------------------------------
    void UpdateMovement()
    {
        if (change != Vector3.zero)
        {
            //myRigidbody.MovePosition(transform.position + change * Time.deltaTime * speed);
            myRigidbody.MovePosition(new Vector3(myRigidbody.position.x, myRigidbody.position.y, myRigidbody.position.z) + change * speed * Time.fixedDeltaTime);
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
    KeyCode GetFirstButton()
    //-------------------------------------------------------------------------------------------------
    void GetInput()
    {
        KeyCode first_pressed = KeyCode.None;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            listed_buttons.Add(KeyCode.UpArrow);
            change.x = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            listed_buttons.Add(KeyCode.DownArrow);
            change.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            listed_buttons.Add(KeyCode.RightArrow);
            change.z = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            listed_buttons.Add(KeyCode.LeftArrow);
            change.z = -1;
        }

    }
    //-------------------------------------------------------------------------------------------------

    //first_pressed = GetFirstButton();

        if (Input.GetKeyUp(KeyCode.UpArrow))
    /*if (first_pressed != KeyCode.None)
    {
        if (first_pressed == KeyCode.UpArrow)
        {
            listed_buttons.Remove(KeyCode.UpArrow);
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
        if (Input.GetKeyUp(KeyCode.DownArrow))
        if (first_pressed == KeyCode.DownArrow)
        {
            listed_buttons.Remove(KeyCode.DownArrow);
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
        if (Input.GetKeyUp(KeyCode.RightArrow))
        if (first_pressed == KeyCode.LeftArrow)
        {
            listed_buttons.Remove(KeyCode.RightArrow);
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
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        if (first_pressed == KeyCode.RightArrow)
        {
            listed_buttons.Remove(KeyCode.LeftArrow);
        }
        if (listed_buttons.Count != 0)
        {
            first_pressed = listed_buttons[0];
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
        return first_pressed;
    }
    }*/
}