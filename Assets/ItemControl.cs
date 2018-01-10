using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemControl : MonoBehaviour {

    public GameObject myParent;
    public GameManager gameManager;


    void Start () {
        myParent = transform.parent.gameObject;
        gameManager = FindObjectOfType<GameManager>();
    }

	void Update () {		
	}

    void OnTriggerStay2D(Collider2D coll)
    {     
        if (coll.gameObject.tag == "SpawnControl")
        {
            myParent.GetComponent<ButtonControl>().mySpawnShouldBeDeleted = true;
        }
        if (coll.tag == "Obstacle")
        {
            gameManager.cantPlaceHere = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {     
        if (coll.gameObject.tag == "SpawnControl")
        {
            myParent.GetComponent<ButtonControl>().mySpawnShouldBeDeleted = false;
        }
        if (coll.tag == "Obstacle")
        {
            gameManager.cantPlaceHere = false;
        }
    } 
}
