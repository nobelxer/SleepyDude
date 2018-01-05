using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReset : MonoBehaviour {

    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }



    void Update () {
		
	}
    void OnMouseDown()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
