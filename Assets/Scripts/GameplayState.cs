using UnityEngine;

public class GameplayState : GameState
{
    public GameplayState(GameManager manager) : base(manager){ }

    public override void Enter()
    {
        Time.timeScale = 1.0f;
    }

    public override void Update()
    {
        
    }

}
