using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public GameObject[] pickups;
    public GameObject[] invPanels;
    public Animator open;
    private bool opened = false;
    public Behaviour movement;
    public Behaviour cam;
    public Behaviour inNav;
    public static Inventory current;

    private Dictionary<InventoryItemData, InventoryItem> inventoryDictionary;
    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        inventoryDictionary = new Dictionary<InventoryItemData,InventoryItem>();
        current = this;

        pickups = GameObject.FindGameObjectsWithTag("Pickup");
        invPanels = GameObject.FindGameObjectsWithTag("InvImg");
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

    public void Display(){
        for(int i = 0; i < inventory.Count; i++){
            invPanels[i].GetComponent<Image>().sprite = inventory[i].data.icon;
            invPanels[i].GetComponent<Image>().enabled = !invPanels[i].GetComponent<Image>().enabled;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            Display();
            if(!opened)
            {
                open.SetTrigger("Open");
                opened = true;
                movement.enabled = false;
                cam.enabled = false;
                inNav.enabled = true;
            }
            else
            {
                open.SetTrigger("Closed");
                opened = false;
                movement.enabled = true;
                cam.enabled = true;
                inNav.enabled = false;
            }
        }
    }
}
