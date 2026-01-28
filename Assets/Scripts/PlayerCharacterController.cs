using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class PlayerCharacterController : ThirdPersonController
{

    public event Action<Item> CollideWithItemEvent;

    protected override void Awake()
    {
        base.Awake(); 
        GameManager.instance.OnStateChangedEvent += HandleStateChange;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item collisionItem = hit.gameObject.GetComponent<Item>();

        if (collisionItem != null)
        {
            CollideWithItemEvent?.Invoke(collisionItem);
        }
    }
    
    private void HandleStateChange(GameState state)
    {
        if (state is GameplayState)
        {
            LockCameraPosition = false;
        }
        else if (state is PauseState)
        {
            LockCameraPosition = true;
        }
    }

}
