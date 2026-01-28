using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, InputMap.IPlayerActions, InputMap.IUIActions
{
    public static InputReader instance;

    private InputMap input;

    private void OnEnable()
    {
        if (input == null)
        {
            input = new InputMap();

            input.UI.SetCallbacks(this);
            input.Player.SetCallbacks(this);

            setGameplay();
        }

        instance = this;
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }

    private void setGameplay()
    {
        input.Player.Enable();
        input.UI.Disable();
    }

    private void setUI()
    {
        input.Player.Disable();
        input.UI.Enable();
    }

    public event Action PauseEvent;
    public event Action ResumeEvent;

    public event Action DropItemEvent;

    public event Action MoveItemEvent;
    public event Action StopMoveItemEvent;

    public void OnJump(InputAction.CallbackContext context)
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseEvent?.Invoke();
            setUI();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ResumeEvent?.Invoke();
            setGameplay();
        }
    }

    public void OnRemoveItem(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            DropItemEvent?.Invoke();
        }
    }

    public void OnDragItem(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            MoveItemEvent?.Invoke();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            StopMoveItemEvent?.Invoke();
        }
    }
}
