using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Interfaces;
using UnityEngine.UI;
using System.Security.Cryptography;

public class BossMovement : MonoBehaviour, IDamageable
{

	public float fleeFor;
	private float elapsedTime;

	// Start is called before the first frame update
	public float lookRadius = 10f;
	public int maxHealth = 30;
	private int currentHealth;
	public Animator enemyAnim;
	public HealthBar healthBar;
	Transform target;
    NavMeshAgent agent;

	private float lastAttackTime; // time when the last attack happened
	public float explosionAnimation = 1.0f; // minimum time between attacks

	public GameObject m_RightSpike;
	public GameObject m_LeftSpike;
	public GameObject m_Horn;

	private int attackChoice = 1;

	private float attackDelay = 3.0f;

	[SerializeField] private GameObject novaParticlesObject;

	bool canAttack = true; // Add this variable as a field in your class
	float attackCooldown = 3f; // Add the desired cooldown duration


	public bool dead = false;
	void Start()
    {
		elapsedTime = fleeFor;
		agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
		enemyAnim = GetComponent<Animator>();

		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

		setRigidbodyState(true);
		setColliderState(false);
		GetComponent<Animator>().enabled = true;
		novaParticlesObject.SetActive(false);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		Debug.Log(elapsedTime);

		if (currentHealth <= 0)
			die();
		

		//float distance = Vector3.Distance(target.position, transform.position);

			//if (distance < lookRadius )
			//{
			//    agent.SetDestination(target.position);
			//}

			//if (distance <= agent.stoppingDistance) 
			//{

			//}
		else
		{
			if (elapsedTime < fleeFor - 0.5)
			{
				transform.Translate(Vector3.down * Time.deltaTime);
				elapsedTime += Time.deltaTime;

			}
			else if (elapsedTime < fleeFor)
			{
				transform.Translate(Vector3.down * Time.deltaTime);
				elapsedTime += Time.deltaTime;
				FaceTarget();
			}
			else
			{
					getCloseAndAttack();
			}
		}
	}

	

	void getCloseAndAttack()
	{
		float distance = Vector3.Distance(target.position, transform.position);
		enemyAnim.SetBool("Walk_Cycle", false);
		if (distance <= lookRadius)
		{
			enemyAnim.SetBool("Walk_Cycle", true);
			agent.SetDestination(target.position);
			Debug.Log("Moving towards target");
			if (distance <= agent.stoppingDistance)
			{
				enemyAnim.SetBool("Walk_Cycle", false);
				//enemyAnim.SetTrigger("Attack_4");
				//FaceTarget();
				//enemyAnim.SetTrigger("Attack_5");
				//FaceTarget();
				//GameObject explosion = Instantiate(novaParticlesObject);
				//StartCoroutine(EnableAndDisableParticles());
				//FaceTarget();
				attackChoice = Random.Range(1, 3);
				switch (attackChoice)
				{
					case 1:
						enemyAnim.SetTrigger("Attack_4");
					FaceTarget();
					//attackChoice = 2;

					//enemyAnim.SetTrigger("Fight_Idle_1");
					break;
					case 2:
						enemyAnim.SetTrigger("Attack_5");
					FaceTarget();
					//GameObject explosion = Instantiate(novaParticlesObject);
					//StartCoroutine(EnableAndDisableParticles());
					//attackChoice = 1;
					//WaitForSeconds wait1 = new WaitForSeconds(explosionAnimation);
					//novaParticlesObject.SetActive(false);
					//enemyAnim.SetTrigger("Fight_Idle_1");
					break;
					//case 3:
					//	enemyAnim.SetTrigger("Intimidate_1");
					//FaceTarget();
					//attackChoice = 1;
					////enemyAnim.SetTrigger("Fight_Idle_1");
					//break;
				}
				WaitForSeconds wait = new WaitForSeconds(attackDelay);
				//FaceTarget();
				//canAttack = false; // Disable further attacks during the cooldown
				//StartCoroutine(AttackCooldown());
				//yield return wait;
			}
		}
	}



	IEnumerator Boom()
	{
		yield return new WaitForSeconds(1);

		StartCoroutine(EnableAndDisableParticles());

	}

	public void explosion() {
		StartCoroutine(Boom());
	}

	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(attackCooldown);
		canAttack = true; // Enable attacks after the cooldown period
	}


	IEnumerator EnableAndDisableParticles()
	{
		// Enable the particle system
		novaParticlesObject.SetActive(true);

		// Wait for 2 seconds
		yield return new WaitForSeconds(1.5f);

		// Disable the particle system
		novaParticlesObject.SetActive(false);
	}


	public void Damage(int damageAmount)
	{
		if (gameObject != null)
		{
			Debug.Log("IKIRTAU TAU"); //temp
			enemyAnim.SetTrigger("Take_Damage_1");


			currentHealth -= damageAmount;
			healthBar.SetHealth(currentHealth);

		}

	}

	public void die()
	{
		if (!dead)
		{
			enemyAnim.SetBool("Walk_Cycle", false);
			enemyAnim.SetBool("Die", true);
			//enemyAnim.SetTrigger("Die");
			//enemyAnim.GetComponent<Animator>().enabled = false;
			setRigidbodyState(false);
			setColliderState(true);

			// Get reference to LootBag component
			LootBag lootBag = GetComponent<LootBag>();

			if (lootBag != null)
			{
				Debug.Log("Kreipiames");
				// Call SpawnCoins() method on LootBag component to spawn coins
				lootBag.SpawnCoins(transform.position);
			}

			Destroy(gameObject, 3f);
			FindObjectOfType<AttackArea>().OnTriggerExit(GetComponent<Collider>());
			dead = true;
		}
		else
			return;
	}

	void FaceTarget()
	{
		enemyAnim.SetBool("Walk_Cycle", false);
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
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

	public void ActivateSpike()
	{
		m_RightSpike.GetComponent<Collider>().enabled = true;
		m_LeftSpike.GetComponent<Collider>().enabled = true;
	}

	public void DeactivateSpike()
	{
		m_RightSpike.GetComponent<Collider>().enabled = false;
		m_LeftSpike.GetComponent<Collider>().enabled = false;
	}

	public void ActivateHorn()
	{
		m_Horn.GetComponent<Collider>().enabled = true;
	}

	public void DeactivateHorn()
	{
		m_Horn.GetComponent<Collider>().enabled = false;
	}

	public void ActivateIntimidate()
	{
		m_Horn.GetComponent<Collider>().enabled = true;
	}

	public void DeactivateIntimidate()
	{
		m_Horn.GetComponent<Collider>().enabled = false;
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

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

	public void ResetTime()
	{
		elapsedTime = 0;
	}

	public void flee()
	{
		enemyAnim.SetBool("Walk_Cycle", true);
		agent.SetDestination(-target.position);
	}
}
