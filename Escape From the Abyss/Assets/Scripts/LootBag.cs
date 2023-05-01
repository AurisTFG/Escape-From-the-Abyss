using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject coinPrefab;
    public int minCoinsToDrop;
    public int maxCoinsToDrop;
    public float coinSplashForce;
    public float coinSplashDuration;
    public float maxSpawnOffset;


    public void SpawnCoins(Vector3 spawnPosition)
    {
        int coinsToDrop = Random.Range(minCoinsToDrop, maxCoinsToDrop + 1);
        for (int i = 0; i < coinsToDrop; i++)
        {
            GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

            // Add random position offset
            Vector3 dropOffset = new Vector3(Random.Range(-maxSpawnOffset, maxSpawnOffset), 0, Random.Range(-maxSpawnOffset, maxSpawnOffset));
            coin.transform.position += dropOffset;

            // Add random force
            Vector3 dropDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            float dropForce = Random.Range(coinSplashForce / 2f, coinSplashForce);
            Vector3 force = dropDirection * dropForce;
            coin.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

            StartCoroutine(SplashCoin(coin));
        }
    }

    IEnumerator SplashCoin(GameObject coin)
    {
        yield return new WaitForSeconds(coinSplashDuration);

        Vector3 splashDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        Vector3 splashForce = splashDirection * coinSplashForce;
        coin.GetComponent<Rigidbody>().AddForce(splashForce, ForceMode.Impulse);

        yield return null;
    }
}
