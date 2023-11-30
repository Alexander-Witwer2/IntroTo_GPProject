using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WineSpillTrigger : MonoBehaviour
{
    public TMP_Text displayText;
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Yo");
        if(other.tag == "sight")
        {
            displayText.text = "It's a wine Spill";
            Debug.Log("rwgfjnrwijbrji");
        }
    }

    private void OnTriggerStay(Collider other){
        if(other.tag == "sight"){
            if(Input.GetKeyDown(KeyCode.E)){
                displayText.text = "I need to clean up this wine spill. But I don't have Paper Towels";

                foreach(InventoryItem item in Inventory.current.inventory){
                    if(item.data.id == "tp"){
                        displayText.text = " ";
                        Destroy(door);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other){
        displayText.text = " ";
        Debug.Log("Exited");
    }

    private IEnumerator revertText(){
        Debug.Log("wait");
        yield return new WaitForSeconds(3);
        displayText.text = " ";
    }
}
