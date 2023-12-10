using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickupItem(){
        Inventory.current.Add(referenceItem);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other){
        if(Input.GetKeyDown(KeyCode.E))
        {
            for(int i = 0; i < Inventory.current.pickups.Length; ++i){
                if(other.tag == "sight"){
                    Inventory.current.pickups[i].GetComponent<ItemObject>().OnHandlePickupItem();
                }
            }
        }
    }
}
