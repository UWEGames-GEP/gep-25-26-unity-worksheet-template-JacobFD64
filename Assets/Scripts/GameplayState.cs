using UnityEngine;

public class GameplayState : GameState
{

    

    public override void Enter()
    {
        Time.timeScale = 1.0f;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void Update()
    {
        
    }
    public override void Exit()
    {
        
        Cursor.lockState = CursorLockMode.None;
    }

}
