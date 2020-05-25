using System;
using System.Collections;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public Transform[] spawnPointArray;
    public GameObject obstaclePrefab;
    public float delayTime;
    public float difficultyCap;
    public int spawnPointArrayLimit;    

    private bool difficultyCapReached = false;
    private double difficultyCounter = 1;
    private bool objGenerationBool = true;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (objGenerationBool)
        {
            int randomIndex = UnityEngine.Random.Range(0, spawnPointArray.Length);

            Debug.Log("Obstacle spawned at: " + randomIndex);
            Instantiate(obstaclePrefab, spawnPointArray[randomIndex].position, Quaternion.identity);

            yield return new WaitForSeconds(CalculateDelayTime());
            Debug.Log("delay value: " + CalculateDelayTime());
            difficultyCounter++;
        }
    }

    float CalculateDelayTime()
    {
        if (!difficultyCapReached)
        {
            float resultantDelay = delayTime - (float)Math.Log(difficultyCounter / 10);


            if (CheckDifficultyCap(resultantDelay))
            {
                difficultyCapReached = true;
            }
            /**
             * For difficulty scaling, I have chosen to use a logarithmic 
             * value to scale the difficulty. 
             * 
             * This will cause a sharp increase, but will fall off quickly
             * and will slowly increase thereafter.
             */
            return resultantDelay;

        } else
        {
            return difficultyCap;
        }
    }

    bool CheckDifficultyCap(float resultantDelay)
    {
        /**
         * Check if the calculated end delay value has reach the difficult cap 
         * (meaning the delay end value, so it does not get too difficult).
         */
        return (resultantDelay > 1);
    }
}
