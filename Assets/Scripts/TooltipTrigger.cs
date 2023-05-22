using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemData item;
    public TMP_Text quantityOfItem;

   
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("J'affiche une description");
        TooltipSystem.instance.Show();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.instance.Hide();
    }

    public void ClickOnSlot()
    {
       Inventory.instance.OpenActionPanel(item);
    }
}
