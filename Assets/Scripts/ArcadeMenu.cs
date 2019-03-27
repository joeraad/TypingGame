using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void LoadNonLinear()
    {
        sceneFader.FadeTo("non-linear");
       
    }
    public void LoadLinear()
    {
        sceneFader.FadeTo("Linear");
    }
}
