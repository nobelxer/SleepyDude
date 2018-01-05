using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRotateDrag : MonoBehaviour {

    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Vector2 position;
    private Color newColor = Color.yellow;
    private Color startColor = new Color(0.90F, 0.163F, 0.223F);

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = transform.position;
    }


    void Update () {

        if (gameManager.activeRotate == true)
        {
            spriteRenderer.color = newColor;
        } else {
            spriteRenderer.color = startColor;
        }

        if (gameManager.activeDrag == null)
        {            
            transform.position = new Vector2(position.x + 200, position.y);
        } else {          
            transform.position = position;
        }
    }

    void OnMouseDown()
    {
        gameManager.ObjectRotating();             
        print("Rotate Clicked");   
    }
}
