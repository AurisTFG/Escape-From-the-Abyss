using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour, IDataPersistence
{
    public int maxHealth;
    private int currentHealth;

    public HealthBar healthBar;
    public GameController controller;

    public void LoadData(GameData data)
    {
        this.currentHealth = data.health;
    }

    public void SaveData(ref GameData data)
    {
        data.health = this.currentHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        setRigidbodyState(true);
        setColliderState(false);
        GetComponent<Animator>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20);
            healthBar.SetHealth(currentHealth);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
            die();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fist")
            TakeDamage(20);
    }

    public void die()
    {

        GetComponent<Animator>().enabled = false;
        setRigidbodyState(false);
        setColliderState(true);
        if (gameObject != null)
        {
            gameObject.GetComponent<CharacterMovement>().enabled = false;
            controller.GameOver();
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
            if(collider.gameObject.name != "AttackArea")
                collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

    }

   
}
