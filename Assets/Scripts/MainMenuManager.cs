using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Assets/Scenes/GEP Sample Scene.unity");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
