using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDieAudio : MonoBehaviour
{
    void Awake()
    {
        /**
         * sourced from: https://answers.unity.com/questions/1253516/playing-audio-through-multiple-scenes.html
         */
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Audio");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
/*        if (SceneManager.GetActiveScene().name == "SceneName")
        {
            Destroy(this.gameObject);
        }
        Uncomment if you want to disable the music for a particular scene.
         */
    }
}