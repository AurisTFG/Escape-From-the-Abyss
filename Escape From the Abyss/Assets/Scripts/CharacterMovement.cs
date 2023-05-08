using UnityEngine;

public class CharacterMovement : MonoBehaviour, IDataPersistence
{
    public Animator playerAnim;
    private Rigidbody myRigidbody;
    float[] pitchRanges = new float[]{ 0.95f, 1, 1.05f };

    private AudioSource audioSource;
   

 

    public float walkingSpeed;
    private Vector3 walkingChange;
    private Vector3 forward, right;
    private Vector3 heading;

    public float rotationSpeed;
    private float rotationAngle;
    private Quaternion targetRotation;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponents<AudioSource>()[0];

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        walkingSpeed = 4;
        rotationSpeed = 5;
    }
    void FixedUpdate()
    {
        GetInput();
        UpdateMovement();
        UpdateRotation();
    }
    void UpdateRotation()
    {
        rotationAngle = Mathf.Atan2(heading.x, heading.z);
        rotationAngle *= Mathf.Rad2Deg;

        targetRotation = Quaternion.Euler(0, rotationAngle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }
    void UpdateMovement()
    {
        if (walkingChange != Vector3.zero)
        {

            playerAnim.SetBool("walking", true);
            walkingChange = Vector3.ClampMagnitude(walkingChange, 1f);
            Vector3 rightMovement = right * walkingSpeed * Time.fixedDeltaTime * walkingChange.z;
            Vector3 upMovement = forward * walkingSpeed * Time.fixedDeltaTime * walkingChange.x;


            heading = Vector3.Normalize(rightMovement + upMovement);

            myRigidbody.position += rightMovement + upMovement;



            if (!audioSource.isPlaying)
            {
                audioSource.pitch = pitchRanges[Random.Range(0, 3)];
                audioSource.Play();
            }

        }
        else
            audioSource.Stop();



    }
    void GetInput()
    {
        walkingChange = Vector3.zero;
        playerAnim.SetBool("walking", false);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            walkingChange.z = -1;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (walkingChange.z == -1)
            {
                walkingChange = Vector3.zero;
                return;
            }
            walkingChange.z = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            walkingChange.x = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (walkingChange.x == -1)
            {
                walkingChange = Vector3.zero;
                return;
            }
            walkingChange.x = 1;
        }

    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }
}