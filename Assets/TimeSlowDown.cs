using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowDown : MonoBehaviour
{

    public float slowDownFactor = 0.05f;
    public float slowDownLenght = 2f;
    public float slowDownHold = 2f;
    public bool slowTimeDown;

   // private GameManager gameManager;

    void Start()
    {
     //   gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Time.timeScale < 1f)
        {  
            Time.timeScale += (1f / slowDownLenght) * Time.unscaledDeltaTime / slowDownHold;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            if (Time.timeScale >= 0.9f)
            {
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
            }
        }
    }

    public void DoSlowMotion()
    {
        if (slowTimeDown == false)
        {
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            slowTimeDown = true;
        }
    }
}
