using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public Transform[] spawnPointArray;
    public GameObject obstaclePrefab;
    public float startTime;
    public float delayTime;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startTime, delayTime);
    }

    void SpawnObstacle ()
    {        
        int randomIndex = Random.Range(0, spawnPointArray.Length);

        foreach (Transform spawnPoint in spawnPointArray)
        {
            if (spawnPointArray[randomIndex] == spawnPoint)
            {
                Debug.Log("Obstacle spawned at: " + randomIndex);
                Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
