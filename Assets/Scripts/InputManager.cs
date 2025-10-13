using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance {  get; private set; }

    public InputActionMap inputActions;

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchToPlayer()
    {
        //inputActions.
    }

    public void SwitchToUI()
    {
        //inputActions.FindActionMap("UI").Enable();
        //inputActions.FindActionMap("Player").Disable();
    }
}
