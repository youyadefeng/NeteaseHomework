using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float randomRange = 9f;
    private int enemyCount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            SpawnWave(++waveNumber);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomX = Random.Range(-randomRange, randomRange);
        float randomZ = Random.Range(-randomRange, randomRange);
        Vector3 randomPos = new Vector3(randomX, 0, randomZ);
        return randomPos;
    }

    void SpawnWave(int enemyAmount)
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        for(int i=0; i<enemyAmount; ++i)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


}
