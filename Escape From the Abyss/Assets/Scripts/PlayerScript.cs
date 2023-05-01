using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour, IDataPersistence
{
    public int maxHealth;
    public int maxEnergy;
    private int currentHealth;
    private int currentEnergy;

    public HealthBar healthBar;
    public EnergyBar energyBar;
    public GameController controller;

    public void LoadData(GameData data)
    {
        this.currentHealth = data.health;
        this.currentEnergy = data.energy;
    }

    public void SaveData(ref GameData data)
    {
        data.health = this.currentHealth;
        data.energy = this.currentEnergy;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        healthBar.SetMaxHealth(maxHealth);
        energyBar.SetMaxEnergy(maxEnergy);
        setRigidbodyState(true);
        setColliderState(false);
        GetComponent<Animator>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeEnergy(20);
            energyBar.SetEnergy(currentEnergy);
        }
    }
    void TakeEnergy(int damage)
    {
        currentEnergy -= damage;
        energyBar.SetEnergy(currentEnergy);
        //if (currentEber <= 0)
           // die();
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
