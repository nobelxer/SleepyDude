using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour {

    public Button spawnButton;
    public GameObject prefabToSpawn;
    public GameObject buttonSpawnPosition;
    public GameObject mySpawnedPrefab;
    public GameManager gameManager;
    public bool objectSpawned;
    public bool positionChanged;
    public bool checkMyPosition;

    private Vector3 spawnPosition;

	void Start () {
        gameManager = FindObjectOfType<GameManager>();
    }
	
	void Update () {

        if (checkMyPosition)
        {
            if (spawnPosition != transform.position)
            {
                positionChanged = true;
            }
        }
	}

    public void ButtonClicked()
    {
        if (objectSpawned == false) {

            objectSpawned = true;
            mySpawnedPrefab = Instantiate(prefabToSpawn, buttonSpawnPosition.transform);
            gameManager.SetActiveDrag(mySpawnedPrefab);
            gameManager.ObjectMoving();
            spawnButton.GetComponent<Image>().color = new Color32(255, 255, 255, 40);
            spawnPosition = mySpawnedPrefab.transform.position;
            checkMyPosition = true;

        } else {
            objectSpawned = false;
            Destroy(mySpawnedPrefab);
            spawnButton.GetComponent<Image>().color = new Color32(141, 141, 141, 255);            
            gameManager.activeDrag = null;

        }
    }
}
