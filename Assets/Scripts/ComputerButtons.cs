using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerButtons : MonoBehaviour
{
    public Material portal1;
    public Material portal2;
    public Material blackScreen;
    public GameObject display;
    public GameObject ButtonOne;
    public GameObject ButtonTwo;
    public GameObject text;
    public GameObject walls;

    public void screen1(){
        foreach(InventoryItem inv in Inventory.current.inventory){
            if(inv.data.id == "wine_glass"){
                display.GetComponent<MeshRenderer>().material = blackScreen;
                ButtonOne.SetActive(!ButtonOne.activeSelf);
                text.SetActive(true);
                walls.SetActive(false);
                Victory.compCheck = true;
            }
        }
        if(!Victory.compCheck){
            display.GetComponent<MeshRenderer>().material = portal1;
            ButtonOne.SetActive(!ButtonOne.activeSelf);
            ButtonTwo.SetActive(!ButtonTwo.activeSelf);
        }
    }

    public void screen2(){
        display.GetComponent<MeshRenderer>().material = portal2;
        ButtonOne.SetActive(!ButtonOne.activeSelf);
        ButtonTwo.SetActive(!ButtonTwo.activeSelf);
    }
}
