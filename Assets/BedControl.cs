using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BedControl : MonoBehaviour {

    private GameManager gameManager;
    public GameObject[] bedChildren;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        bedChildren = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            bedChildren[i] = transform.GetChild(i).gameObject;
        }
    }

    void Update () {

        if (gameManager.gameInMotion == true)
        {
            foreach (GameObject child in bedChildren)
            {
                child.GetComponent<Rigidbody2D>().simulated = true;
            }
        }else
        {
            foreach (GameObject child in bedChildren)
            {
                child.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
        	
	}
}
