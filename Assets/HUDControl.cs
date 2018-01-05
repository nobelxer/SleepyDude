using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDControl : MonoBehaviour {

    public GameManager gameManager;

    void Start () {
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        gameManager.mouseOverHUD = true;
    }

    void OnMouseExit()
    {
        gameManager.mouseOverHUD = false;
    }
}
