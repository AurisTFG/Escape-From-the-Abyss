using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    CharacterMovement moveScript;
    PlayerScript data;
    public float dashSpeed;
    public float dashTime;

    public GameObject dashParticles;

    AudioSource audioSource;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<CharacterMovement>();
        data = GetComponent<PlayerScript>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponents<AudioSource>()[2];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (data.GetEnergy() < 50)
            {
                Debug.Log("Dashui trûksta energijos");
            }
            else
            {
                Debug.Log("DASHINAM!");
                data.TakeEnergy(50);

                audioSource.Play();

                GameObject dashObject = Instantiate(dashParticles, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Random.rotation);

                Destroy(dashObject, 1.5f);

                StartCoroutine(Dash());
            }
            
        }
    }
    IEnumerator Dash()
    {
        /*moveScript.enabled = false;
        Vector3 startPos = transform.position;
        Vector3 dashDirection = transform.forward;

        float t = 0f;
        while(t < 1f)
        {
            t += Time.deltaTime / dashTime;
            transform.position = Vector3.Lerp(startPos, startPos + dashDirection * dashSpeed, t);
            yield return null;
        }

        yield return new WaitForSeconds(dashTime - (dashTime * t));
        moveScript.enabled = true;*/
        
            moveScript.enabled = false;
            rb.velocity = transform.forward * dashSpeed;
            rb.isKinematic = false;

            yield return new WaitForSeconds(dashTime);

            rb.velocity = Vector3.zero;
            //rb.isKinematic = true;
            moveScript.enabled = true;
        


    }
}
