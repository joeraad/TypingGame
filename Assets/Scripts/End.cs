using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class End : MonoBehaviour {
    private int score;
    public Text scoreText;
    

    private void Start()
    {
        getScores();
        scoreText.text=score.ToString();
    }
    private void getScores()
    {
        score = PlayerPrefs.GetInt("Score");
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
