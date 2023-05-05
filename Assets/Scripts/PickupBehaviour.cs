using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Inventory inventory;


    public void DoPickup(Item item)
    {
        if(inventory.IsFull())
        {
            Debug.Log("Inventory is full");
            return;
        }
        
        //Ajoute l'objet passé à l'inventaire du player
        inventory.AddItem(item.itemData);

        //Joue l'animation de pickup
        playerAnimator.SetTrigger("Pickup");

        //Bloque déplacement du player pendant qu'on ramasse un objet
        playerMovement.canMove = false;


        Destroy(item.gameObject);
    }

    public void ReEnablePlayerMovement()
    {
        playerMovement.canMove = true;
    }
}
