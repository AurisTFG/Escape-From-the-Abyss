using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Interfaces;


public class EnemyAI : MonoBehaviour, IDamageable
{
    public Animator enemyAnim;

    public float lookRadius = 10f;

    public AudioClip[] hits;

    private AudioSource audioSource;



    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }

    void Update()
    {
        enemyAnim.SetBool("walking", false);
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            enemyAnim.SetBool("walking", true);
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                //Cia pridet reiks, kad priesas pultu zaideja
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        enemyAnim.SetBool("walking", false);
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Damage(int damageAmount)
    {
        Debug.Log("IKIRTAU TAU"); //temp
        enemyAnim.SetTrigger("hit");
        audioSource.Play();
        
    }
}
