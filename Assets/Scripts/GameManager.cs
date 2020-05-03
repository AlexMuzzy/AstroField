using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameHasEnded { get => gameHasEnded; set => gameHasEnded = value; }
    private bool gameHasEnded = false;
    readonly float restartDelay = 1f;
    private GameObject completeLevelUI;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        /**
         * Check to see if the LevelCompleteCanvas has been added to the scene.
         * 
         * Methods related to the Complete Level UI are only related to the Endtrigger
         * being called, so it is unnecessary to include a null check.
         */
        GameObject completeLevelCanvas = GameObject.Find("LevelCompleteCanvas");
        completeLevelUI = completeLevelCanvas.transform.Find("LevelComplete").gameObject;
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
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
