using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public void Update()
    {
        if (gameManager.currentState is PauseState) { return; }

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    AddItemToInventory("Generic Item");
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    RemoveItemFromInventory("Generic Item");
        //}
    }

}
    
