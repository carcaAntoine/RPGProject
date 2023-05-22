using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemInInventory> content = new List<ItemInInventory>(); //Contenu de l'inventaire

    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private Transform inventorySlotsParent;

    const int InventorySize = 20;


    [Header("Action Panel References")]
    [SerializeField] private GameObject actionPanel;
    [SerializeField] private GameObject useItemButton;
    [SerializeField] private GameObject equipItemButton;
    [SerializeField] private GameObject dropItemButton;
    [SerializeField] private GameObject destroyItemButton;

    private ItemData itemCurrentlySelected;


    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RefreshContent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    public void AddItem(ItemData item)
    {
        //content.Add(item);


        ItemInInventory itemInInventory = content.Where(elem => elem.itemData == item).FirstOrDefault(); //Permet de savoir si on a déjà un exemplaire de l'item récupéré
        if (itemInInventory != null && item.stackable)
        {
            itemInInventory.count++;
            //quantityOfItem.text = itemInInventory.count.ToString();
        }
        else
        {
            content.Add(new ItemInInventory { itemData = item, count = 1 });
        }

        RefreshContent();
    }

    public void RemoveItem(ItemData item)
    {
        ItemInInventory itemInInventory = content.Where(elem => elem.itemData == item).FirstOrDefault(); //Permet de savoir si on a déjà un exemplaire de l'item récupéré
        if (itemInInventory.count > 1)
        {
            itemInInventory.count--;
            //quantityOfItem.text = itemInInventory.count.ToString();
        }
        else
        {
            content.Remove(itemInInventory);
        }

        RefreshContent();
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

    private void RefreshContent()
    {
         for(int i = 0; i <inventorySlotsParent.childCount; i++)
         {
            TooltipTrigger currentSlot = inventorySlotsParent.GetChild(i).GetComponent<TooltipTrigger>();

            currentSlot.item = null;
            currentSlot.quantityOfItem.enabled = false;
         }

        for (int i = 0; i < content.Count; i++)
        {
            TooltipTrigger currentSlot = inventorySlotsParent.GetChild(i).GetComponent<TooltipTrigger>();
            inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].itemData.visual;

            //if(currentSlot.item.stackable)
            //{
               currentSlot.quantityOfItem.enabled = true;
               currentSlot.quantityOfItem.text = content[i].count.ToString();
            //}
        }
    }

    public bool IsFull()
    {
        return InventorySize == content.Count;
    }


    public void OpenActionPanel(ItemData item)
    {
        itemCurrentlySelected = item;
        if (item == null)
        {
            return;
        }
        switch (item.itemType)
        {
            case ItemType.Ressource:
                useItemButton.SetActive(false);
                equipItemButton.SetActive(false);
                break;
            case ItemType.Equipment:
                useItemButton.SetActive(false);
                equipItemButton.SetActive(true);
                break;
            case ItemType.Consumable:
                useItemButton.SetActive(true);
                equipItemButton.SetActive(false);
                break;
        }

        actionPanel.SetActive(true);
    }

    public void CloseActionPanel()
    {
        actionPanel.SetActive(false);
        itemCurrentlySelected = null;
    }

    public void UseActionButton()
    {
        Debug.Log("Use item : " + itemCurrentlySelected.name);
        CloseActionPanel();
    }

    public void EquipActionButton()
    {
        Debug.Log("Equip item : " + itemCurrentlySelected.name);
        CloseActionPanel();
    }

    public void DropActionButton()
    {
        Debug.Log("Drop item : " + itemCurrentlySelected.name);
        CloseActionPanel();

    }

    public void DestroyActionButton()
    {
        //content.Remove(itemCurrentlySelected);
        CloseActionPanel();
    }
}

[System.Serializable]
public class ItemInInventory
{
    public ItemData itemData;
    public int count;
}