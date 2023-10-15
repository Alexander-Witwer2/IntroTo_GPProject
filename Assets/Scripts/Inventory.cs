using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform[] pickups;
    public Animator open;
    private bool opened = false;
    public Behaviour movement;

    private Dictionary<InventoryItemData, InventoryItem> inventoryDictionary;
    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        inventoryDictionary = new Dictionary<InventoryItemData,InventoryItem>();
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if(inventoryDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData referenceData)
    {
        if(inventoryDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            inventoryDictionary.Add(referenceData,newItem);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if(inventoryDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                inventoryDictionary.Remove(referenceData);
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            if(!opened)
            {
                open.SetTrigger("Open");
                opened = true;
                movement.enabled = false;
            }
            else
            {
                open.SetTrigger("Closed");
                opened = false;
                movement.enabled = true;
            }
        }
        if(Input.GetKeyDown("space"))
        {
            /*if(Vector3.Distance(sign.position, gameObject.transform.position) < 0.25f)
            {
                if(!panel.activeInHierarchy)
                {
                    panel.SetActive(true);
                }
                else if(panel.activeInHierarchy)
                {
                    panel.SetActive(false);
                    break;
                }
                text.text = "This is a sign";
            }*/
        }
    }
}
