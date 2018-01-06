using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    public GameObject movementPanel;
    public GameObject inventoryPanel;
    private bool inventoryPanelON = true;

    public Button confirmButton;
    public Sprite confirmButtonGreen;
    public Sprite confirmButtonOrange;
    public Button rotateButton;
    public Button moveButton;

    public Image infoBoxCantPlaceItem;

    private GameManager gameManager;

    private bool fadeItem;
    private float alpha;

    void Start () {
        gameManager = FindObjectOfType<GameManager>();
        infoBoxCantPlaceItem.gameObject.SetActive(false);   
    }

    void Update()
    {
        alpha -= Time.deltaTime / 2;  

        if (fadeItem)
        {
            FadeObject();
        }

        if (!gameManager.cantPlaceHere)
        {
            confirmButton.GetComponent<Image>().sprite = confirmButtonGreen;
        }
        else
        {
            confirmButton.GetComponent<Image>().sprite = confirmButtonOrange;
        }

        if(gameManager.editMode == false)
        {
            confirmButton.GetComponent<Image>().sprite = confirmButtonGreen;
        }

        if (gameManager.activeDrag == null)
        {
            GreyOutButtons();
        }else
        {
            GreyOutButtonsCancel();
        }       
    }


    public void SwitchPanels()
    {
        print("Button Clicked");
        if (inventoryPanelON == true)
        {
            movementPanel.SetActive(true);
            inventoryPanel.SetActive(false);
            inventoryPanelON = false;
        }
        else
        {
            movementPanel.SetActive(false);
            inventoryPanel.SetActive(true);
            inventoryPanelON = true;
        }
    }

    public void Rotate() {
        gameManager.ObjectRotating();
        print("Rotate Clicked");
    }

    public void Move() {
        gameManager.ObjectMoving();
        print("Move clicked");
    }

    public void Confirm() {
        gameManager.ConfirmButtonPressed();
    }

    public void Release() {
        gameManager.ReleaseButtonPressed();
    }

    public void ResetCharacter() {
        gameManager.CreatePlayer();
    }

    public void ResetLevel() {
        SceneManager.LoadScene("MainLevel");
    }

    public void ShowInfoBoxCantBePlacedHere()
    {
        alpha = 1.5f;
        infoBoxCantPlaceItem.gameObject.SetActive(true);
        fadeItem = true;
        print("ShowInfoBoxCantBePlacedHere()");
    }

    public void FadeObject()
    {
        infoBoxCantPlaceItem.color = new Color(255, 255, 255, alpha);
        infoBoxCantPlaceItem.gameObject.transform.Find("CantPlace").GetComponent<Text>().color = new Color(0, 0, 0, alpha);
        if (alpha < 0)
        {
            infoBoxCantPlaceItem.gameObject.SetActive(false);
            fadeItem = false;
        }
    }

    void GreyOutButtons()
    {
        confirmButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
        rotateButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
        moveButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.2f);
    }

    void GreyOutButtonsCancel()
    {
        confirmButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        rotateButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        moveButton.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
    }

}
