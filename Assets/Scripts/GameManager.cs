using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public static bool gameHasEnded;
    public float endDelay = 0.5f;
    public Score score;
    public GameObject gameOverUi;

    private void Start()
    {
        gameHasEnded = false;
        Score.ResetScore();
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            score.SaveScores();
            gameOverUi.SetActive(true);
            gameHasEnded = true;
            //End();
            //Invoke("End", endDelay);
        }
    }
    void End()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
