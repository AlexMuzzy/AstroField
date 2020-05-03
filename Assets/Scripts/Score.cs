using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public bool gameHasEnded;
    

    // Update is called once per frame
    void Update()
    {
        gameHasEnded = FindObjectOfType<GameManager>().GameHasEnded;
        
        if (!gameHasEnded)
        {
            scoreText.text = player.position.z.ToString("0");
        } else
        {
            scoreText.text = "Game Over!";
        }
    }
}
