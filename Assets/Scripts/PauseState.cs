using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PauseState : GameState
{

    public override void Enter()
    {
        Time.timeScale = 0f;
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        
    }
}
