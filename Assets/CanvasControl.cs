using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour {

    public Text testText;
    Vector3 mousePos;
    private string mousePosition;

    void Start()
    {

    }

    void Update()
    {
        mousePos = Input.mousePosition;
        testText.text = mousePos.ToString();
    }
}
