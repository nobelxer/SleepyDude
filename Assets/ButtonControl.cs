using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour {

    public Button spawnButton;
    public GameObject prefabToSpawn;
    public GameObject buttonSpawnPosition;
    public bool itemUsed;

    private Vector3 spawnPosition;

	void Start () {     

    }
	
	void Update () {
		
	}

    public void SpawnPrefab()
    {
       Instantiate(prefabToSpawn, buttonSpawnPosition.transform);
    }
}
