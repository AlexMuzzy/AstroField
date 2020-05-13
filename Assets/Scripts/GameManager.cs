using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameHasEnded { get => gameHasEnded; set => gameHasEnded = value; }
    private bool gameHasEnded = false;
    readonly float restartDelay = 1f;
    private GameObject completeLevelUI;
    public PlayerData playerData;
    public Transform player;
    public Text scoreText;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        /**
         * Check to see if the LevelCompleteCanvas has been added to the scene.
         * 
         * Methods related to the Complete Level UI are only related to the Endtrigger
         * being called, so it is unnecessary to include a null check.
         * 
         * This class is also used in an instance where the 'LevelCompleteCanvas'
         * will not exist, so a try catch block is used to handle such exceptions.
         */
        try
        {
            GameObject completeLevelCanvas = GameObject.Find("LevelCompleteCanvas");
            completeLevelUI = completeLevelCanvas.transform.Find("LevelComplete").gameObject;
        } 
        catch
        {
            Debug.Log("Complete Level Canvas was not detected.");
        }
    }

    void Update()
    {
        if (!gameHasEnded)
        {
            scoreText.text = player.position.z.ToString("0");
        }
        else
        {
            scoreText.text = "Game Over!";
        }
    }

    public void CompleteLevel ()
    {
        //TODO: Refactor this method to LevelComplete class.
        completeLevelUI.SetActive(true);
        Debug.Log("LEVEL WON");
    }

    public void EndGame ()
    {
        if (!GameHasEnded)
        {
            GameHasEnded = true;
            if (player.position.z > playerData.SaveData.hiScore)
            {
                Debug.Log("New High Score! High Score: " + player.position.z.ToString("0"));
                playerData.SerializeData(new PlayerJsonData((int)Math.Round(player.position.z)));
            }
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
