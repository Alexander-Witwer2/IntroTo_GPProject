using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryNav : MonoBehaviour
{
    public GameObject selection;
    Vector3 myPos;
    public TMP_Text ItemName;
    public TMP_Text ItemDescription;
    private int i = 0;
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.W)){
            myPos = selection.transform.position;
            if((selection.transform.position.y+70) < 341.0f){
                myPos.y += 70.0f;
                selection.transform.position = myPos;
                i -= 9;
            }
        }
        if(Input.GetKeyDown(KeyCode.S)){
            myPos = selection.transform.position;
            if((selection.transform.position.y-70) > 69.0f){
                myPos.y -= 70.0f;
                selection.transform.position = myPos;
                i += 9;
            }
        }
        if(Input.GetKeyDown(KeyCode.A)){
            myPos = selection.transform.position;
            if((selection.transform.position.x-70) > 25.0f){
                myPos.x -= 75.0f;
                selection.transform.position = myPos;
                i -= 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.D)){
            myPos = selection.transform.position;
            if((selection.transform.position.x+75) < 750.0f){
                myPos.x += 75.0f;
                selection.transform.position = myPos;
                i += 1;
            }
        }
        if(i < 35){
            if((i < Inventory.current.inventory.Count) && (Inventory.current.inventory.Count > 0)){
                ItemName.text = Inventory.current.inventory[i].data.displayName;
                ItemDescription.text = Inventory.current.inventory[i].data.description;
            }
            else{
                ItemName.text = "Empty";
                ItemDescription.text = "There is nothing here";
            }
        }
    }
}
