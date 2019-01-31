using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Score : MonoBehaviour {
    private static int score;

    public static void IncreaseScore()
    {
        score++;
    }
    public void SaveScores()
    {
        PlayerPrefs.SetInt("Score", score);
    }




}
