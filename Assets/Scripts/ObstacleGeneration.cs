using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public Transform[] spawnPointArray;
    public GameObject obstaclePrefab;

    void Update()
    {
        int randomIndex = Random.Range(0, spawnPointArray.Length);

        for (var i = 0; i < spawnPointArray.Length; i++)
        {
            if (i == randomIndex)
            {
                Instantiate(obstaclePrefab, spawnPointArray[i].position, Quaternion.identity);
            }
        }
    }

    void spawnObstacle ()
    {

    }
}
