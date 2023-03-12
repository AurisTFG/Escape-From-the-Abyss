using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public Vector3 change;
    private Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        GetInput();
        UpdateMovement();
    }
    void UpdateMovement()
    {
        if (Mathf.Abs(change.x) == 1 && Mathf.Abs(change.z) == 1) // eina istrizai
            change *= 0.707f;

        myRigidbody.MovePosition(myRigidbody.position + change * speed * Time.fixedDeltaTime);  
    }
    void GetInput()
    {
        change = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            change.x = 1;
        }
            
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (change.x == 1)
            {
                change = Vector3.zero;
                return;
            }
            change.x = -1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            change.z = 1;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (change.z == 1)
            {
                change = Vector3.zero;
                return;
            }
            change.z = -1;
        }      
    }
}