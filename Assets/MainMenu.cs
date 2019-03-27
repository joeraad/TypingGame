using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void LoadArcade()
    {
        sceneFader.FadeTo("ArcadeMenu");

    }
    public void LoadTraining()
    {
        sceneFader.FadeTo("TrainingMenu");
    }
    public void Quit()
    {
         Debug.Log("Exiting....");
         Application.Quit();
    }
}
