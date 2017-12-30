using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseDragButton : MonoBehaviour {

    private bool visibility = false;
    
    void Start()
    {
        gameObject.SetActive(visibility);
    }

    public void ButtonVisibility()
    {
       
        if (visibility == false)
        {
            gameObject.SetActive(true);
            visibility = true;
        }
        else
        {
            gameObject.SetActive(false);
            visibility = false;
        }
    }
}
