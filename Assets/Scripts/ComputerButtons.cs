using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerButtons : MonoBehaviour
{
    public Material portal1;
    public Material portal2;
    public GameObject display;
    public GameObject ButtonOne;
    public GameObject ButtonTwo;

    public void screen1(){
        display.GetComponent<MeshRenderer>().material = portal1;
        ButtonOne.SetActive(!ButtonOne.activeSelf);
        ButtonTwo.SetActive(!ButtonTwo.activeSelf);
    }

    public void screen2(){
        display.GetComponent<MeshRenderer>().material = portal2;
        ButtonOne.SetActive(!ButtonOne.activeSelf);
        ButtonTwo.SetActive(!ButtonTwo.activeSelf);
    }
}
