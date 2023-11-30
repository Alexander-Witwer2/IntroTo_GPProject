using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropShadow : MonoBehaviour
{
    public TMP_Text text;
    private TMP_Text thisText;

    void Start()
    {
        thisText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        thisText.text = text.text;
    }
}
