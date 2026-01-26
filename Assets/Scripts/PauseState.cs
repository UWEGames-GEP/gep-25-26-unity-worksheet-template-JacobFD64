using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PauseState : GameState
{
    private PlayerCharacterController controller;

    public PauseState(PlayerCharacterController controller)
    {
        this.controller = controller;
    }
    public override void Enter()
    {
        Time.timeScale = 0f;
        controller.lockCamera(true);
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        controller.lockCamera(false);
    }
}
