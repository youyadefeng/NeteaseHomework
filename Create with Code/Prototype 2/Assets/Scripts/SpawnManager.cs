using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int animalIndex;
    private float spawnRangeX = 20;
    private float spawnPositionZ = 20;
    public float spawnInternal = 1.5f;
    private float startDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInternal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        animalIndex = Random.Range(0,animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], new Vector3(Random.Range(-spawnRangeX, spawnRangeX),0,spawnPositionZ), animalPrefabs[animalIndex].transform.rotation);
    }
}
