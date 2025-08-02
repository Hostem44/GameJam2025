using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Play scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
