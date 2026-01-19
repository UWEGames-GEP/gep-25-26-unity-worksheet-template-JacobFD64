using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseState : GameState
{
    //public PlayerInput playerInput;
    public PauseState(GameManager manager) : base(manager) 
    { 
        //playerInput = input;
    }

    public override void Enter()
    {
        //playerInput.SwitchCurrentActionMap("UI");
        Time.timeScale = 0f;

    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        //playerInput.SwitchCurrentActionMap("Player");
    }
}
