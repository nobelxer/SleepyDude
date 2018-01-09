using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{

    public Button spawnButton;
    public GameObject prefabToSpawn;
    public GameObject buttonSpawnPosition;
    public GameObject mySpawnedPrefab;
    public GameManager gameManager;
    public bool objectSpawned;
    public bool positionChanged;

    public Vector3 mySpawnedPosition;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        print(IMoved());
    }
    public void ButtonClicked()
    {
        if (gameManager.lastSpawnedItem != null)
        {
            gameManager.CheckIfSpawnedShouldBeDestroyed();
        }

        if (gameManager.CheckIfGameIsInMotion())
        {
            if (gameManager.CheckIfActiveItemCanBeChanged())
            {
                if (objectSpawned == false)
                {
                    
                    objectSpawned = true;
                    CheckButtonColor();
                    mySpawnedPrefab = Instantiate(prefabToSpawn, buttonSpawnPosition.transform);
                    mySpawnedPrefab.transform.position = new Vector3(0,-3f,0);
                    mySpawnedPrefab.transform.parent = gameObject.transform;
                    gameManager.lastSpawnStartingPosition = mySpawnedPrefab.transform.position;
                    gameManager.SetLastSpawnedItem(mySpawnedPrefab);
                    gameManager.SetLastClickedButton(spawnButton);
                    gameManager.SetActiveDrag(mySpawnedPrefab);
                    gameManager.ObjectMoving();
                    Invoke("SetDistanceToZero", 0.5f);
                    mySpawnedPosition = mySpawnedPrefab.transform.position;
                }
                else
                {
                    DestroyMyItem();

                }
            }
          
        }
    }

    public void DestroyMyItem()
    {
        objectSpawned = false;
        CheckButtonColor();
        Destroy(mySpawnedPrefab);        
        gameManager.activeItem = null;
    }

    private void CheckButtonColor()
    {
        if (objectSpawned)
        {
            spawnButton.GetComponent<Image>().color = new Color32(255, 255, 255, 40);
        }
        else
        {
            spawnButton.GetComponent<Image>().color = new Color32(141, 141, 141, 255);
        }
    }

    void SetDistanceToZero()
    {
        gameManager.distance = 0;
    }

    public bool IMoved() {

        if (mySpawnedPosition  == mySpawnedPrefab.transform.position)
        {
            return false;
        }else
        {
            return true;
        }
        }
}
