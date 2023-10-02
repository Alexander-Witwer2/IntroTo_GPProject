using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
public float ysen;
public float xsen;

public Transform pos;

float yrot;
float xrot;

private void Start(){
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

private void Update(){
    float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xsen;
    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ysen;

    yrot += mouseX;

    xrot -= mouseY;
    xrot = Mathf.Clamp(xrot,-90f,90f);

    transform.rotation = Quaternion.Euler(xrot,yrot,0);
    pos.rotation = Quaternion.Euler(0,yrot,0);

}
}
