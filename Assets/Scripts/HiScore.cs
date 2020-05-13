using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public Text hiScoreText;
    public PlayerData playerData;
    
    // Start is called before the first frame update
    void Start()
    {
        int playerHiScore = 0;
        if (playerData.SaveData != null)
        {
            playerHiScore = playerData.SaveData.hiScore;
        }
        else
        {
            Debug.Log("Save data not found!");
        }

        hiScoreText.text = playerHiScore.ToString();
    }
}
