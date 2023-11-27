using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject ComputerCam;
    public GameObject player;
    public GameObject ButtonManage;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 3f){
                ButtonManage.SetActive(!ButtonManage.activeSelf);
                ComputerCam.SetActive(!ComputerCam.activeSelf);
                PlayerCam.SetActive(!PlayerCam.activeSelf);
                if(Cursor.lockState == CursorLockMode.Locked){
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = !Cursor.visible;
                }
                else{
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = !Cursor.visible;
                }
                }
        }
    }
}
