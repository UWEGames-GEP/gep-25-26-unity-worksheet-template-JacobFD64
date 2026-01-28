using System;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } 
    
    private GameState currentGameState;

    public GameState currentState => currentGameState;

    bool paused;

    public event Action<GameState> OnStateChangedEvent;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        var gameplay = new GameplayState();
        var pause = new PauseState();

        InputReader.instance.PauseEvent += HandlePause;
        InputReader.instance.ResumeEvent += HandleResume;

        pause.AddTransition(gameplay, () => !isPaused());
        gameplay.AddTransition(pause, () => isPaused());

        ChangeState(gameplay);

    }
    private void Update()
    {
        currentGameState?.Update();

        var nextState = currentGameState?.CheckTransitions();
        if (nextState != null)
        {
            ChangeState(nextState);
        }
    }
    public void ChangeState(GameState newState)
    {
        currentGameState?.Exit();
        currentGameState = newState;
        OnStateChangedEvent?.Invoke(newState);
        currentGameState?.Enter();
    }

    private void HandlePause()
    {
        paused = true;
        Debug.Log("Pause Game.");
    }

    private void HandleResume()
    {
        paused = false;
        Debug.Log("Resume Game.");
    }
    private bool isPaused() => paused;
}
