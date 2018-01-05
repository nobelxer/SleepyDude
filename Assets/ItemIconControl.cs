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

    private BoxCollider2D boxCollider2D;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rotationArrowLeft.GetComponent<SpriteRenderer>().enabled = false;
        rotationArrowRight.GetComponent<SpriteRenderer>().enabled = false;
        moveArrows.GetComponent<SpriteRenderer>().enabled = false;
        wrongPosition.GetComponent<SpriteRenderer>().enabled = false;

    }


    void Update()
    {

        if (gameManager.activeDrag == gameObject)
        {
            if (gameManager.activeRotate)
            {
                rotationArrowLeft.GetComponent<SpriteRenderer>().enabled = true;
                rotationArrowRight.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                rotationArrowLeft.GetComponent<SpriteRenderer>().enabled = false;
                rotationArrowRight.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (gameManager.activeMove)
            {
                moveArrows.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                moveArrows.GetComponent<SpriteRenderer>().enabled = false;
            }
        }else
        {
            rotationArrowLeft.GetComponent<SpriteRenderer>().enabled = false;
            rotationArrowRight.GetComponent<SpriteRenderer>().enabled = false;
            moveArrows.GetComponent<SpriteRenderer>().enabled = false;
            wrongPosition.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }
}
