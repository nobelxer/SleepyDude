using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReleaseDrag : MonoBehaviour
{

    private GameManager gameManager;
    private Vector2 position;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        position = transform.position;
    }

    void Update()
    {
        if (gameManager.activeDrag == null)
        {
            transform.position = new Vector2(position.x + 300, position.y);
        } else {
            transform.position = position;
        }
    }


    void OnMouseDown()
    {       
        gameManager.activeDrag = null;
        gameManager.ObjectMoving();      
    }
}
