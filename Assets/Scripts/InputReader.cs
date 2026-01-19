using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, InputMap.IPlayerActions, InputMap.IUIActions
{
    InputMap input;

    private void OnEnable()
    {
        if (input == null)
        {
            input = new InputMap();

            input.UI.SetCallbacks(this);
            input.Player.SetCallbacks(this);

            setGameplay();
        }
    }

    public void setGameplay()
    {
        input.Player.Enable();
        input.UI.Disable();
    }

    public void setUI()
    {
        input.Player.Disable();
        input.UI.Enable();
    }

    public event Action PauseEvent;
    public event Action ResumeEvent;

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
}
