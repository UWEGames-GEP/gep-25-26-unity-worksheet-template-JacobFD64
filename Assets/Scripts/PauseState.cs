using UnityEngine;

public class PauseState : GameState
{
    public PauseState(GameManager manager) : base(manager){ }

    public bool isPaused;

    public override void Enter()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        isPaused = false;
    }
}
