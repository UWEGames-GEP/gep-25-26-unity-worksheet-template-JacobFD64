using UnityEngine;

public class GameplayState : GameState
{
    GameObject InventoryUI;
    public GameplayState(GameManager manager,GameObject InventoryUI) : base(manager)
    {
        this.InventoryUI = InventoryUI;
    }

    public override void Enter()
    {
        Time.timeScale = 1.0f;
        InventoryUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void Update()
    {
        
    }
    public override void Exit()
    {
        InventoryUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

}
