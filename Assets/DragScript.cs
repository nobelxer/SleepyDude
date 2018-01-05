using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragScript : MonoBehaviour {

    public GameManager gameManager;
    public float touchSensivity; // slows down rotation

    private Color newColor = Color.blue;
    private Color startColor = new Color(0.90F, 0.163F, 0.223F);
    private SpriteRenderer imageRenderer;

    // Drag and drop
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 screenPointOut;
    private Vector3 offsetOut;
    private bool objectHasBeenPicked;
    public bool enableRotate;
    public bool enableMove;
    // Drag and drop

    // Rotation
    private float startingPosition;
    public float distance;
    public float myRotation;
    // Rotation

    Vector3 playerSize;
    Rect screenRect;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        imageRenderer = GetComponent<SpriteRenderer>();
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        
    }

    void Update()
    {
        playerSize = imageRenderer.bounds.size; 


        var distanceToCamera = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + (playerSize.x / 2);
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x - (playerSize.x / 2);

        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).y + (playerSize.y / 2);
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceToCamera)).y - (playerSize.y / 2);
 
        touchSensivity = gameManager.touchSensitivityMultiplier;

        // Check with Gm if you are the active object
        if (gameManager.activeDrag == gameObject)
        {             
            enableRotate = gameManager.activeRotate;
            enableMove = gameManager.activeMove;
            imageRenderer.material.color = newColor;
        } else {
            imageRenderer.material.color = startColor;
            objectHasBeenPicked = false;
            enableMove = false;
            enableRotate = false;                   
        }

        // rotation logic
        if (enableRotate)
        {
            if (gameManager.mouseOverHUD == false)
            {
                // Rotation - starting point
                if (Input.GetMouseButtonDown(0))
                {
                    startingPosition = Input.mousePosition.y;
                    distance = 0;
                }
                // Rotation - distans
                if (Input.GetMouseButton(0))
                {
                    distance = startingPosition - Input.mousePosition.y;
                    transform.eulerAngles = new Vector3(0, 0, (distance + myRotation) * touchSensivity);
                }
                // Rotation - rotation alrady made
                if (Input.GetMouseButtonUp(0))
                {
                    myRotation = myRotation + distance;
                    distance = 0;
                }
            }
        }
              
        // drag logic
        if (enableMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                screenPointOut = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offsetOut = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPointOut.z));
            }

            if (gameManager.mouseOverHUD == false)
            {
                if (Input.GetMouseButton(0))
                {
                    Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                    Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offsetOut;
                    transform.position = (new Vector3(
    Mathf.Clamp(cursorPosition.x, leftBorder, rightBorder),
    Mathf.Clamp(cursorPosition.y, bottomBorder, topBorder),
    cursorPosition.z)
);
                   // transform.position = cursorPosition;
                }
            }
        }
    }

    void OnMouseDown()
    {
        // Set me as object being dragged and send to GM
        if (objectHasBeenPicked == false)
        {
            objectHasBeenPicked = true;
            gameManager.SetActiveDrag(gameObject);
            gameManager.activeMove = true;
            enableMove = true;  
        }

        // Set starting offSet
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        // drag logic
        if (gameManager.mouseOverHUD == false)
        {            
            if (enableRotate != true)
            {
                Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
                transform.position = cursorPosition;
            }
        }
    }    
}
