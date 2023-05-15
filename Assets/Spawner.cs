using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnItems;
    
    public float TimeBetweenSpawns { get; private set; } = 2f;
    float lastSpawnTime;
    public Transform[] spawnPositions;
    public int goldenChance { get; set; }

    private void Awake()
    {
        //Chance for golden ball spawn (0-100)%
        goldenChance = 5;
    }
    void FixedUpdate()
    {
        
        if (Time.time > lastSpawnTime + TimeBetweenSpawns)
        {
            GameObject spawnItem = GetRandomGameObject();
            int randomPosition = Random.Range(0, spawnPositions.Length);
            Vector3 position = spawnPositions[randomPosition].transform.position;
            GameObject newSpawnObject = Instantiate(spawnItem, position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
    public void incrementFreq()
    {
        TimeBetweenSpawns -= 0.5f;
    }

    private GameObject GetRandomGameObject()
    {
        int randomInt = Random.Range(0, 100);
        if(randomInt <= goldenChance)
        {
            return spawnItems[spawnItems.Length - 1];
        }
        else
        {
            randomInt = Random.Range(0, spawnItems.Length - 1);
            return spawnItems[randomInt];
        }
    }
}
