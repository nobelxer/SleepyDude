using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragScript : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 screenPointOut;
    private Vector3 offsetOut;

    public bool pickedToBeDragged;
    public GameObject releaseDragUI;
    private ReleaseDragButton releaseDragButton;
 

    void Start()
    {
        releaseDragButton = releaseDragUI.GetComponent<ReleaseDragButton>();
    }

    void Update()
    {
        
        if (pickedToBeDragged)
        {
            if (Input.GetMouseButtonDown(0))
            {
                screenPointOut = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offsetOut = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPointOut.z));
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offsetOut;
                transform.position = cursorPosition;
            }
        }
    }
    

    void OnMouseDown()
    {
        pickedToBeDragged = true;
        releaseDragButton.ButtonVisibility();
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }
}
