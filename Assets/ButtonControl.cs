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
    public bool mySpawnIsActiveItem;

    public bool mySpawnShouldBeDeleted;

    public Vector3 mySpawnedPosition;

    public Color activeButtonColor;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
      
        if (gameManager.lastSpawnedItem != null)
        {
            if (objectSpawned == true)
            {
                if (gameManager.activeItem == mySpawnedPrefab)
                {
                    mySpawnIsActiveItem = true;
                }
                else
                {
                    mySpawnIsActiveItem = false;
                }
            }
        }

        ButtonColorControl();
    }

    public void ButtonClicked()
    {
        if (gameManager.CheckIfGameIsInMotion())
        {
            if (objectSpawned == true)
            {
                if (mySpawnIsActiveItem == true)
                {
                    print("Destroyin item");
                    DestroyMyItem();
                    return;
                }
                gameManager.SetLastSpawnedItem(mySpawnedPrefab);
                gameManager.SetLastClickedButton(spawnButton);
                gameManager.SetActiveDrag(mySpawnedPrefab);
                gameManager.ObjectMoving();
            }

            if (gameManager.cantPlaceHere == true)
            {
                if (mySpawnIsActiveItem == false)
                {
                    gameManager.uiControl.ShowInfoBoxCantBePlacedHere();
                }
            }

            if (gameManager.lastSpawnedItem != null)
            {
                gameManager.CheckIfSpawnedItemShouldBeDeleted();
            }

            if (objectSpawned == false && gameManager.cantPlaceHere == false)
            {
                print("Object spawn code");
                objectSpawned = true;
                mySpawnedPrefab = Instantiate(prefabToSpawn, buttonSpawnPosition.transform);
                mySpawnedPrefab.transform.parent = gameObject.transform;
                gameManager.SetLastSpawnedItem(mySpawnedPrefab);
                gameManager.SetLastClickedButton(spawnButton);
                gameManager.SetActiveDrag(mySpawnedPrefab);
                gameManager.ObjectMoving();
            }
        }
    }

    public void DestroyMyItem()
    {
        mySpawnIsActiveItem = false;
        objectSpawned = false;
        Destroy(mySpawnedPrefab);
        gameManager.activeItem = null;
    }

    private void ButtonColorControl()
    {
        if (mySpawnIsActiveItem == true)
        {
            spawnButton.GetComponent<Image>().color = activeButtonColor;
        }
        else
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
    }
}
