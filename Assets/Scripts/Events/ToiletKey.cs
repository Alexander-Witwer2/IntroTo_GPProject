using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToiletKey : MonoBehaviour
{
    public GameObject key;
    public TMP_Text displayText;
    private bool hasBrush;

    private void OnTriggerEnter(Collider other){
        if(!hasBrush){
            displayText.text = "There's something in the toilet, but I can't reach it";
        }
    }

    private void OnTriggerStay(Collider other){

        if(other.tag == "sight" && key.activeSelf == false){
            if(Input.GetKeyDown(KeyCode.E)){
                foreach(InventoryItem item in Inventory.current.inventory){
                    if(item.data.id == "toothbrush"){
                        hasBrush = true;
                        break;
                    }
                }
                if(hasBrush){
                    displayText.text = "";
                    key.SetActive(true);
                    Inventory.current.pickups = GameObject.FindGameObjectsWithTag("Pickup");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other){
        displayText.text = " ";
    }
}
