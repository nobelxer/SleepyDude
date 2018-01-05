using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour {

    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void OnMouseDown()
    {
        gameManager.stopPlayerMoving = false; // set to false to release hingeJoint2D
        gameManager.gravityScale = 15;
    }
}
