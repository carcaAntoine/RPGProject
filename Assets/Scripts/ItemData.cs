using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New item")]

public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite visual; //image de l'item qui sera affichée dans l'inventaire
    public GameObject prefab; //prefab de l'item
    public bool stackable;
    public ItemType itemType;
}

public enum ItemType
{
    Ressource,
    Consumable,
    Equipment
}
