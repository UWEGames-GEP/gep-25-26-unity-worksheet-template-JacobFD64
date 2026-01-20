using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;


public class GameManager : MonoBehaviour
{
    private GameState currentGameState;

    public GameState currentState => currentGameState;

    public PlayerCharacterContoller characterController;

    [SerializeField] private InputReader input;

    [SerializeField] private GameObject InventoryUI;

    bool paused;

    private void Start()
    {
        var gameplay = new GameplayState(this, InventoryUI);
        var pause = new PauseState(this, characterController);

        input.PauseEvent += HandlePause;
        input.ResumeEvent += HandleResume;

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
