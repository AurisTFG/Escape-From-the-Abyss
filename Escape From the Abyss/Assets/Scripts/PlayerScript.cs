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

    public float elapsedTime;
    public float timeForHealth;
    public float timeForEnergy;
    public static PlayerScript instance;
    public HealthBar healthBar;
    public EnergyBar energyBar;
    public GameController controller;

    public Camera mainCamera;
    public Camera deathCamera;

    private void Awake()
    {
        instance = this;
    }
    public void LoadData(GameData data)
    {
        this.currentHealth = data.health;
        this.currentEnergy = data.energy;
        healthBar.SetHealth(currentHealth);
        energyBar.SetEnergy(currentEnergy);
        this.transform.position = data.playerPosition;
    }
    public int GetEnergy()
    {
        return currentEnergy;
    }

    public void SaveData(ref GameData data)
    {
        data.health = this.currentHealth;
        data.energy = this.currentEnergy;
        data.playerPosition = this.transform.position;
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
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 5)
        {
            addEnergy(15);
            addHealth(5);
            ResetTime();
        }
       
    }
    public void TakeEnergy(int damage)
    {
        currentEnergy -= damage;
        energyBar.SetEnergy(currentEnergy);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
            die();
    }
    public void addEnergy(int ammount)
    {
        if(currentEnergy + ammount >= maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        else
        currentEnergy += ammount;
        energyBar.SetEnergy(currentEnergy);
    }
    void addHealth (int ammount)
    {
        if(currentHealth + ammount >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        currentHealth += ammount;
        healthBar.SetHealth(currentHealth);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fist")
            TakeDamage(20);
    }

    public void die()
    {
        mainCamera.enabled = false;
        deathCamera.gameObject.SetActive(true);

        SoundManager.instance.StopMusic();

        GameController.instance.DisableCanvas();
        deathCamera.backgroundColor = Color.gray;
        deathCamera.GetComponent<AudioSource>().Play();
        GetComponents<AudioSource>()[0].Stop();
        GetComponent<Animator>().enabled = false;
        setRigidbodyState(false);
        setColliderState(true);
        if (gameObject != null)
        {
            gameObject.GetComponent<CharacterMovement>().enabled = false;
            controller.GameOver();
        }

        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;

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
    public void ResetTime()
    {
        elapsedTime = 0;
    }

}
