using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;

    public void GameOver()
    {
        GameOverScreen.Setup();
    }
}
