using UnityEngine;

public class Prefabui : MonoBehaviour
{
    public float minRotationSpeed;
    public float maxRotationSpeed;
    public float minUp;
    public float maxUp;
    private float rotationSpeed;
    private float upSpeed;
    Rigidbody rigidbody;
    public Vector3 change;
    private bool down = true;
    private bool up = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        upSpeed = Random.Range(minUp, maxUp);
        change = rigidbody.position;
    }
    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
        if (change.y < 0.6)
        {
            up = true;
            down = false;
        }
        if (change.y > 1.15)
        {
            up = false;
            down = true;
        }
        if (down)
        {
            change.y -= 0.01f * upSpeed;
        }
        if (up)
        {
            change.y += 0.01f * upSpeed;
        }

        rigidbody.MovePosition(change);
    }
}

