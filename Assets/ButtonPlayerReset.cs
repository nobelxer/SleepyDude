using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayerReset : MonoBehaviour {

    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }



    void Update()
    {

    }
    void OnMouseDown()
    {
        gameManager.CreatePlayer();
    }
}
