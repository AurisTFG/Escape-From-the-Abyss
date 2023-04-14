using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{

    public AudioSource collectSound;
    public TMP_Text coinDisplay;
    public int value;
    public float angle;

    public float speed;


    bool moveCoin;
    bool addCoins;
    GameObject target;


    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("toCoins");
    }

    // Update is called once per frame
    void Update()
    {

        if (moveCoin)
        {
            //Debug.Log("TELEPORTUOJAM");
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("PRIDEDAM PINIGU");
            collectSound.Play();
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            moveCoin = true;
            Destroy(gameObject, 1f);
        }
        
    }
    private void OnDestroy()
    {
        Debug.Log("SUNAIKINOM");
        CoinsCounter.instance.IncreaseCoins(value);
        
    }
}