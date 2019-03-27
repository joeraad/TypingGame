using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsTyped : MonoBehaviour
{
    private int score;
    public Text scoreText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        
        scoreText.text = "0";
        getScores();

        int words = 0;
        yield return new WaitForSeconds(.7f);
        while (words < score)
        {
            words++;
            scoreText.text = words.ToString();

            yield return new WaitForSeconds(.05f);
        }

    }
    private void getScores()
    {
        score = PlayerPrefs.GetInt("Score");
    }
}

