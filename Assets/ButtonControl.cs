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


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }

    void Update()
    {
                
    }
    public void ButtonClicked()
    {
       

        if (gameManager.CheckIfGameIsInMotion())
        {
            if (gameManager.CheckIfActiveItemCanBeChanged())
            {
                if (objectSpawned == false)
                {

                    if (gameManager.lastSpawnedItem != null)
                    {
                        gameManager.SetLastClickedButton(spawnButton);
                        gameManager.lastClickedButton.GetComponent<ButtonControl>().CheckIfColorShouldGoBackToInactive();
                        gameManager.CheckIfSpawnedShouldBeDestroyed();
                    }

                    objectSpawned = true;
                    CheckButtonColor();
                    mySpawnedPrefab = Instantiate(prefabToSpawn, buttonSpawnPosition.transform);
                    mySpawnedPrefab.transform.position = new Vector3(0,-3f,0);
                    gameManager.SetLastSpawnedItem(mySpawnedPrefab);
                    gameManager.SetActiveDrag(mySpawnedPrefab);
                    gameManager.ObjectMoving();
                    
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

    private bool CheckIfMyItemDidntMove()
    {
        if (GameObject.ReferenceEquals(gameManager.lastSpawnedItem, mySpawnedPrefab))
        {
            print(gameObject + "true");
            return true;
        }else{
            print(gameObject + "false");
            return false;
        }
    }

    private void CheckIfColorShouldGoBackToInactive()
    {
        if (CheckIfMyItemDidntMove())
        {
            spawnButton.GetComponent<Image>().color = new Color32(141, 141, 141, 255);
        }
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

}
