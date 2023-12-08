using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoormatKey : MonoBehaviour
{
    public GameObject key;
    public TMP_Text displayText;

    private void OnTriggerStay(Collider other){
        if(other.tag == "sight" && key.activeSelf == false){
            displayText.text = "I think there is something under the mat";
            if(Input.GetKeyDown(KeyCode.E)){
                transform.position = transform.position + new Vector3 (0,0,0.5f);
                displayText.text = "";
                key.SetActive(true);
                Inventory.current.pickups = GameObject.FindGameObjectsWithTag("Pickup");
            }
        }
    }
}
