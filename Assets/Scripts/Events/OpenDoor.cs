using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public TMP_Text displayText;
    public int keyCount = 0;

    private void OnTriggerEnter(){
        displayText.text = "I need more key to open this door";
    }
    
    private void OnTriggerStay(Collider other){
        if(other.tag == "sight"){
            if(Input.GetKeyDown(KeyCode.E)){
                foreach(InventoryItem item in Inventory.current.inventory){
                    if(item.data.id == "key_1" || item.data.id == "key_2" || item.data.id == "key_3"){
                        Debug.Log("Key is had");
                        keyCount++;
                    }
                }
                if(keyCount == 3){
                    displayText.text = "";
                    Destroy(door);
                }
                keyCount = 0;
            }
        }
    }

    private void OnTriggerExit(){
        displayText.text = "";
    }

    private IEnumerator wait(){
        yield return new WaitForSeconds(3);
    }
}
