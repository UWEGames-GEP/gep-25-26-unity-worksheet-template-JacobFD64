using UnityEngine;

public class PauseState : GameState
{
    public PauseState(GameManager manager) : base(manager){ }

    public override void Enter()
    {
        Time.timeScale = 0f;
    }

    public override void Update()
    {
        
    }
}
