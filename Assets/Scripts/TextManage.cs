using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManage : MonoBehaviour
{
    public  TMP_Text displayText;

    public  void gone(){
        StartCoroutine(revertText());
    }

    public IEnumerator revertText(){
        yield return new WaitForSeconds(3);
        displayText.text = "";
    }
}
