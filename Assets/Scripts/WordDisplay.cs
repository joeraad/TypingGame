using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WordDisplay : MonoBehaviour {

    //public TextMesh text;
    public Text text;
    public float fallSpeed = 1f;
    public float slideSpeed = 1.5f;
    //public Score score;
    
    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        Score.IncreaseScore();
        Destroy(gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetSceneByName("non-linear").Equals(SceneManager.GetActiveScene()))
        {
            transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
        }
        else
        {
            transform.Translate(-slideSpeed * Time.deltaTime, 0f, 0f);
        }
    }

}
