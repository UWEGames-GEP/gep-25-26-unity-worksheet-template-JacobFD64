using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private GameState currentGameState;
    public static GameManager instance;

    private void Awake()
    {
       
    }
    private void Start()
    {
        if (currentGameState == null)
        {
            ChangeState(new MainMenuState(this));
        }
        var mainMenu = new MainMenuState(this);
        var gameplay = new GameplayState(this);
        var pause = new PauseState(this);

        UIManager.Instance.startButton.onClick.AddListener(mainMenu.onStartButtonPressed);


        mainMenu.AddTransition(gameplay, () => mainMenu.startPressed);
        gameplay.AddTransition(pause, () => Input.GetKeyDown(KeyCode.Escape));
        pause.AddTransition(mainMenu, () => Input.GetKeyDown(KeyCode.Space));
        pause.AddTransition(gameplay, () => Input.GetKeyDown(KeyCode.Escape));
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
    public void StartGame()
    {
        ChangeState(new GameplayState(this));
    }
    public void ChangeState(GameState newState)
    {
        currentGameState?.Exit();
        currentGameState = newState;
        currentGameState?.Enter();
    }
}
