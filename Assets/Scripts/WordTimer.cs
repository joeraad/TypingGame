using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordTimer : MonoBehaviour {

    public WordManager wordManager;
    public float nonLinearWordDelay = 1.5f;
    public float linearWordDelay = 2.5f;
    private float nextWordTime = 0f;
    private void Update()
    {
        if (SceneManager.GetSceneByName("non-linear").Equals(SceneManager.GetActiveScene()))
        {
            if (Time.time >= nextWordTime)
            {
                wordManager.AddWord();
                nextWordTime = Time.time + nonLinearWordDelay;
                nonLinearWordDelay *= 0.99f;
            }
        }else
        {
            if (Time.time >= nextWordTime)
            {
                wordManager.AddWord();
                nextWordTime = Time.time + linearWordDelay;
                linearWordDelay *= 0.99f;
            }

        }
    }
}
