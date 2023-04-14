using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    Rigidbody rigidbody;
    public float rotateSpeed;
    public Vector3 change;
    public float moveSpeed;
    private bool down = true;
    private bool up = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        change = rigidbody.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
        if(change.y < 0.6)
        {
            up = true;
            down = false;
        }
        if(change.y > 1.15)
        {
            up = false;
            down = true;
        }
        if(down)
        {
            change.y -= 0.01f*moveSpeed;
        }
        if(up)
        {
            change.y += 0.01f*moveSpeed;
        }

        rigidbody.MovePosition(change);
    }
}
