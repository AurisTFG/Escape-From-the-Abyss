using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    
    // Start is called before the first frame update
    public int maxEnergy = 100;
    public int currentEnergy;

    public EnergyBar energyBar;


    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }

}
