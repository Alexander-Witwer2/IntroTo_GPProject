using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public static bool compCheck = false;

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(compCheck){
                SceneManager.LoadScene(3);
            }
        }
        StartCoroutine(wait());
    }

    private IEnumerator wait(){
        yield return new WaitForSeconds(5);
    }
}
