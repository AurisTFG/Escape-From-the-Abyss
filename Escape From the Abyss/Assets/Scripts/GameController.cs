using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public GameObject barrel;
    public GameObject propan;
    public GameObject spawn;
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
}
