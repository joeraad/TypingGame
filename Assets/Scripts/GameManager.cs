using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    bool gameHasEnded = false;
    public float endDelay = 0.5f;
    public Score score;


    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            score.SaveScores();
            gameHasEnded = true;
            End();
            Invoke("End", endDelay);
        }
    }
    void End()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
