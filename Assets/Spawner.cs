using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnItems;
    public float Frequency { get; private set; }
    float lastSpawnTime;
    public Transform[] spawnPositions;

    private void Awake()
    {
        Frequency = 2f;
    }
    void FixedUpdate()
    {

        if (Time.time > lastSpawnTime + Frequency)
        {
            int randomItem = Random.Range(0, spawnItems.Length);
            GameObject spawnItem = spawnItems[randomItem];
            int randomPosition = Random.Range(0, spawnPositions.Length);
            Vector3 position = spawnPositions[randomPosition].transform.position;
            GameObject newSpawnObject = Instantiate(spawnItem, position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
    public void incrementFreq()
    {
        Frequency += 1;
    }
}
