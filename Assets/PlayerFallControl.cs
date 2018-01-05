using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallControl : MonoBehaviour {

    private GameManager gameManager;

    private HingeJoint2D hingeJoint2D;

  

    void Start () {

        gameManager = FindObjectOfType<GameManager>();
        hingeJoint2D = GetComponent<HingeJoint2D>();      

    }	

	void Update () {
        hingeJoint2D.enabled = gameManager.stopPlayerMoving;
    }
}
