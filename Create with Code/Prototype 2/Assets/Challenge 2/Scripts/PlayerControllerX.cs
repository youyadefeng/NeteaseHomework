using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnInterval = 1f;
    private float lastSpawnTime = 0;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Time.time - lastSpawnTime >= spawnInterval && Input.GetKeyDown(KeyCode.Space))
        {
            lastSpawnTime = Time.time;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
