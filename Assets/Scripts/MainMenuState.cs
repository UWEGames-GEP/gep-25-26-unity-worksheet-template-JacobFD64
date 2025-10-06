using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MainMenuState : GameState
{
    public MainMenuState(GameManager manager) : base(manager) { }

    public bool startPressed;

    public override void Enter()
    {
        SceneManager.LoadScene("Assets/Scenes/Menu.unity");
    }
    public override void Update()
    {
        //if (startPressed == true)
        //{
        //    startPressed = false;
        //}
    }
    public void onStartButtonPressed()
    {
        startPressed = true;
    }
    public override void Exit()
    {
        SceneManager.LoadScene("Assets/Scenes/GEP Sample Scene.unity");
    }
}
