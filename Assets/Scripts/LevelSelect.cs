using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LoadSelectedLevel (string level)
    {
        SceneManager.LoadScene(level);
    }
}
