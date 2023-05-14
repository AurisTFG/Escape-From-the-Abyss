using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioSource explodeSound;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public HealthBar healthBar;
    float cubesPivotDistance;
    Vector3 cubesPivot;

    public GameObject particleOnDestroy;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Touched player");
            explode();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Touched enemy");
            explode();
        }
    }

    public void explode()
    {
        // Play the explosion sound...
        if (explodeSound != null)
        {
            //explodeSound.enabled = true; // Enable the AudioSource
            Debug.Log("GAAARSOO!");
            explodeSound.Play();
        }
        if (particleOnDestroy)
        {
            GameObject explosion = Instantiate(particleOnDestroy, transform.position, transform.rotation);
           
            Destroy(explosion, 3);
        }



        gameObject.SetActive(false);
      
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }
       
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (rb.gameObject.name == "Player")
                {
                    if(PlayerScript.instance != null)
                    {
                        PlayerScript.instance.TakeDamage(20);
                    }
                   
                }                    
                if (rb.gameObject.tag == "Enemy")
                {

                    EnemyAI enemy = hit.gameObject.GetComponent<EnemyAI>();
                    if(enemy != null)
                    {
                        enemy.Damage(20);
                    }
                }
                if (rb.gameObject.tag == "Explosive")
                {
                    Debug.Log("SALIA SPROGMUO");
                    Destroy explosive = hit.gameObject.GetComponent<Destroy>();
                    if (explosive != null)
                    {
                        explosive.StartCoroutine(explosive.ExplodeAfterDelay());
                    }
                }

            }
        }
      
    }
    private IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Delay before exploding

        explode();
    }

    void createPiece(int x, int y, int z)
    {
       
        GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.AddComponent<Rigidbody>().mass = cubeSize;
    }
}
