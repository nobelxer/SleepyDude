using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragLogic : MonoBehaviour {

    //all of it goes private
    public bool objectToDrag;
    public Vector3 mousePosWhenClicked;
    public Vector3 posDifferenceWhenStartedDragging;
    public Vector3 dragPosition;

    public Button releaseDragButton;

    void Start () {
		
	}
	

	void Update () {

        if (objectToDrag == true)
        {
            if (Input.GetMouseButton(0))
            {
                transform.position = Input.mousePosition - posDifferenceWhenStartedDragging;
            }
        }

    }

    void OnMouseDown()
    {
        objectToDrag = true;
        mousePosWhenClicked = Input.mousePosition;
        posDifferenceWhenStartedDragging = mousePosWhenClicked - transform.position;
    }
}
