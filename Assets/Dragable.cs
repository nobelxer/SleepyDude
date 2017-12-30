using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class Dragable : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    private SpriteRenderer imageRenderer;


    void Start()
    {
        imageRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
      
        if (dragging == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            rayPoint.z = 0;
            float posX = transform.position.x;
            float posY = transform.position.y;
            float mouseX = rayPoint.x;
            float mouseY = rayPoint.y;
            float offSetX = posX - mouseX;
            float offSetY = posY - mouseY;
            transform.position = new Vector2(mouseX - offSetX, mouseY - offSetY);
            print(rayPoint);
                 
        }
    }

    void OnMouseEnter()
    {
        imageRenderer.material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        if (dragging == false)
        {
            imageRenderer.material.color = originalColor;
        }
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;       
    }  
}
