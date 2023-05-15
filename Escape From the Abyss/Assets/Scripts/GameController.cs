using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameOverScreen GameOverScreen;
    public GameObject barrel;
    public GameObject propan;
    public GameObject spawn;

    public GameObject thunderParticles;

    public GameObject enemyStageOne;
    public GameObject enemyStageTwo;
    public GameObject enemyStageThree;

    private AudioSource audioSource;

    public GameObject[] enemySpawns;

    public GameObject thunderSpawn;

    public int killCount = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        InitiateStageOne();
        Debug.Log("Game started");
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject instantiatedBarrel = Instantiate(barrel, spawn.transform.position, new Quaternion(-90, 0, 0, 0));
            Vector3 eulerRotation = instantiatedBarrel.transform.rotation.eulerAngles;
            Debug.Log("Barrel rotation: " + eulerRotation);


        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    public void IncreaseKillCount()
    {
        killCount++;
        if (killCount == 7)
            InitiateStageTwo();

        if (killCount == 12)
            InitiateStageThree();

        if (killCount == 21)
            InitiateFinalStage();

    }

    public void InitiateStageOne()
    {

        audioSource.Play();
        GameObject thunderObject = Instantiate(thunderParticles, thunderSpawn.transform.position, thunderSpawn.transform.rotation);

        Destroy(thunderObject, 3f);

        for (int i = 0; i < enemySpawns.Length; i++)
        {
            GameObject enemy = Instantiate(enemyStageOne, enemySpawns[i].transform.position, enemySpawns[i].transform.rotation);
        }
    }
    public void InitiateStageTwo()
    {
        PlayerScript.instance.addEnergy(100);
        audioSource.Play();
        GameObject thunderObject = Instantiate(thunderParticles, thunderSpawn.transform.position, thunderSpawn.transform.rotation);

        Destroy(thunderObject, 3f);

        for (int i = 0; i < 4; i++)
        {
            Instantiate(enemyStageTwo, enemySpawns[i].transform.position, enemySpawns[i].transform.rotation);
        }
    }

    public void InitiateStageThree()
    {
        PlayerScript.instance.addEnergy(100);
        audioSource.Play();
        GameObject thunderObject = Instantiate(thunderParticles, thunderSpawn.transform.position, thunderSpawn.transform.rotation);

        Destroy(thunderObject, 3f);


        for (int i = 0; i < 3; i++)
        {
            Instantiate(enemyStageTwo, enemySpawns[i].transform.position, enemySpawns[i].transform.rotation);
        }

        for (int i = 3; i < enemySpawns.Length; i++)
        {
            Instantiate(enemyStageOne, enemySpawns[i].transform.position, enemySpawns[i].transform.rotation);
        }
    }

    public void InitiateFinalStage()
    {
        PlayerScript.instance.addEnergy(100);
        audioSource.Play();
        GameObject thunderObject = Instantiate(thunderParticles, thunderSpawn.transform.position, thunderSpawn.transform.rotation);

        Destroy(thunderObject, 3f);


        // Boss spawn
    }


}
