using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameHasEnded { get => gameHasEnded; set => gameHasEnded = value; }
    private bool gameHasEnded = false;
    float restartDelay = 1f;
    public GameObject completeLevelUI;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
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
