using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void LoadNonLinear()
    {
        SceneManager.LoadScene("non-linear");
        
    }
    public void LoadLinear()
    {
        SceneManager.LoadScene("Linear");
    }
}
