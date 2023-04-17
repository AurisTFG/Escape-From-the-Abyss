using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coinsCount;
    public int health;
    public Vector3 playerPosition;

    public GameData()
    {
        this.coinsCount = 0;
        playerPosition = Vector3.zero;
        this.health = 0;
    }
}
