using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel ()
    {
        //add + 1 to the end of this function if you want to go to next level.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
