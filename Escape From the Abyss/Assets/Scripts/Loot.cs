using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject modelis;
    public string lootName;
    public float dropChance; // changed from int to float
    public Material lootMaterial;
    public Mesh lootMesh;

    public Loot(string lootName, float dropChance) // changed from int to float
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
