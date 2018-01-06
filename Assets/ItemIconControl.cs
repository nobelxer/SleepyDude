using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIconControl : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject rotationArrowLeft;
    public GameObject rotationArrowRight;
    public GameObject moveArrows;
    public GameObject wrongPosition;
    public GameObject goodPosition;

    private bool showGreenBox;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rotationArrowLeft.GetComponent<SpriteRenderer>().enabled = false;
        rotationArrowRight.GetComponent<SpriteRenderer>().enabled = false;
        moveArrows.GetComponent<SpriteRenderer>().enabled = false;
        wrongPosition.GetComponent<SpriteRenderer>().enabled = false;
        goodPosition.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        if (gameManager.activeDrag == gameObject)
        {
            goodPosition.GetComponent<SpriteRenderer>().enabled = true;

            if (gameManager.activeRotate)
            {
                rotationArrowLeft.GetComponent<SpriteRenderer>().enabled = true;
                rotationArrowRight.GetComponent<SpriteRenderer>().enabled = true;           

            } else {
                rotationArrowLeft.GetComponent<SpriteRenderer>().enabled = false;
                rotationArrowRight.GetComponent<SpriteRenderer>().enabled = false;              
            }

            if (gameManager.activeMove)
            {
                moveArrows.GetComponent<SpriteRenderer>().enabled = true;                

            } else {
                moveArrows.GetComponent<SpriteRenderer>().enabled = false;      
            }
        } else {
            rotationArrowLeft.GetComponent<SpriteRenderer>().enabled = false;
            rotationArrowRight.GetComponent<SpriteRenderer>().enabled = false;
            moveArrows.GetComponent<SpriteRenderer>().enabled = false;
            wrongPosition.GetComponent<SpriteRenderer>().enabled = false;
            goodPosition.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Obstacle")
        {
            wrongPosition.GetComponent<SpriteRenderer>().enabled = true;
            wrongPosition.GetComponent<SpriteRenderer>().sortingOrder = 2;
            goodPosition.GetComponent<SpriteRenderer>().sortingOrder = -1;
            gameManager.cantPlaceHere = true; 
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Obstacle")
        {
            wrongPosition.GetComponent<SpriteRenderer>().enabled = true;
            wrongPosition.GetComponent<SpriteRenderer>().sortingOrder = 2;
            goodPosition.GetComponent<SpriteRenderer>().sortingOrder = -1;
            gameManager.cantPlaceHere = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Obstacle")
        {
            wrongPosition.GetComponent<SpriteRenderer>().enabled = false;
            wrongPosition.GetComponent<SpriteRenderer>().sortingOrder = -1;
            goodPosition.GetComponent<SpriteRenderer>().sortingOrder = 2;
            gameManager.cantPlaceHere = false;
        }
    }
}
