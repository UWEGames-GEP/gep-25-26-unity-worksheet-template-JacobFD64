using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class PlayerCharacterController : ThirdPersonController
{

    public event Action<Item> CollideWithItemEvent;

    public void lockCamera(bool islocked)
    {
        if (islocked)
        {
            LockCameraPosition = true;
        }
        else
        {
            LockCameraPosition = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item collisionItem = hit.gameObject.GetComponent<Item>();

        if (collisionItem != null)
        {
            CollideWithItemEvent?.Invoke(collisionItem);
        }
    }

}
