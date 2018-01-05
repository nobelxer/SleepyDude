using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyControl : MonoBehaviour {

    private GameManager gameManager;
    private Rigidbody2D rigidBody2D;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update () {
      rigidBody2D.gravityScale = gameManager.gravityScale;
    }
}
