using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Interfaces;
using UnityEngine.UI;


public class EnemyAI : MonoBehaviour, IDamageable
{
    public int maxHealth = 50;
    private int currentHealth;

    public Animator enemyAnim;

    public float lookRadius = 10f;

    public AudioClip[] hitSounds;

    public GameObject bloodParticles;

    private AudioSource audioSource;

    public HealthBar healthBar;

    public GameObject m_RightFist;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        setRigidbodyState(true);
        setColliderState(false);
        GetComponent<Animator>().enabled = true;
    }

    void Update()
    {
        if (currentHealth <= 0)
            die();
        else
        {
            float distance = Vector3.Distance(target.position, transform.position);
            enemyAnim.SetBool("walking", false);
            if (distance <= lookRadius)
            {
                enemyAnim.SetBool("walking", true);
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    //Cia pridet reiks, kad priesas pultu zaideja
                    enemyAnim.SetTrigger("Attack");
                    FaceTarget();
                }
            }
        }
    }

    public void ActivateFist()
    {
        m_RightFist.GetComponent<Collider>().enabled = true;
    }

    public void DeactivateFist()
    {
        m_RightFist.GetComponent<Collider>().enabled = false;
    }

    

    void FaceTarget()
    {
        enemyAnim.SetBool("walking", false);
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Damage(int damageAmount)
    {
        if (gameObject != null)
        {
            Debug.Log("IKIRTAU TAU"); //temp
            enemyAnim.SetTrigger("hit");

            audioSource.clip = hitSounds[Random.Range(0, hitSounds.Length)];
            audioSource.Play();

            currentHealth -= damageAmount;
            healthBar.SetHealth(currentHealth);

            GameObject bloodObject = Instantiate(bloodParticles, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Random.rotation);

            Destroy(bloodObject, 3);
        }

    }
    public void die()
    {

        GetComponent<Animator>().enabled = false;
        setRigidbodyState(false);
        setColliderState(true);
        if (gameObject != null)
        {
            
            Destroy(gameObject, 3f);
            FindObjectOfType<AttackArea>().OnTriggerExit(GetComponent<Collider>());
        }

    }

    void setRigidbodyState(bool state)
    {

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }


    void setColliderState(bool state)
    {

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

    }

}