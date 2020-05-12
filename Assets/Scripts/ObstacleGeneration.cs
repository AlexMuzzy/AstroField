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

        for (var i = 0; i < spawnPointArray.Length; i++)
        {
            if (i == randomIndex)
            {
                Debug.Log("Obstacle spawned at: " + i.ToString());
                Instantiate(obstaclePrefab, spawnPointArray[i].position, Quaternion.identity);
            }
        }
    }
}
