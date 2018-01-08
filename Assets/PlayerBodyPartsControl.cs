using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBodyPartsControl : MonoBehaviour
{
    public Collider2D myCollider2D;
    public Text hitText;
    private GameManager gameManager;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;

    private bool hitRecorded;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rigidBody2D.gravityScale = gameManager.gravityScale;

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Obstacle" || coll.gameObject.tag == "Bed")
        {
            if (gameManager.timeMachine.slowTimeDown == false)
            {
                gameManager.SlowTimeDown();
            }
        }

        if (coll.gameObject.tag == "Obstacle")
        {
            if (hitRecorded == false)
            {
                spriteRenderer.color = new Color32(255, 69, 0, 255);
                hitRecorded = true;
            }
        }
        // implement this one
        if (coll.gameObject.tag == "Bed")
        {
        }
    }
}
