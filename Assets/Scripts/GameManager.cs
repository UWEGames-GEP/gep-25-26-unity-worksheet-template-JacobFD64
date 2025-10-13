using UnityEngine;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    private GameState currentGameState;

    public GameState currentState => currentGameState;

    public PlayerInput input;


    private void Start()
    {
        var gameplay = new GameplayState(this);
        var pause = new PauseState(this,input);

        gameplay.AddTransition(pause, () => Input.GetKeyDown(KeyCode.Escape));
        pause.AddTransition(gameplay, () => Input.GetKeyDown(KeyCode.Escape));

        currentGameState = gameplay;

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
        currentGameState?.Enter();
    }
}
