using UnityEngine;
using System.Collections;

public class DoubleClickDetection : MonoBehaviour
{
    private GameManager gameManager;
    private float doubleClickTime = 0.2f;
    private float lastClickTime = -10f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            float timeDelta = Time.time - lastClickTime;

            if (timeDelta < doubleClickTime)
            {
                if (gameManager.activeItem != null)
                {
                    gameManager.ObjectSwapControl();
                }
                print("double click");
                lastClickTime = 0;
            }
            else
            {
                lastClickTime = Time.time;
            }
        }
    }
}
