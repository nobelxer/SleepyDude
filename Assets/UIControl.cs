using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public GameObject movementPanel;
    public GameObject inventoryPanel;

    public Button confirmButton;
    public Sprite confirmButtonGreen;
    public Sprite confirmButtonOrange;
    public Button rotateButton;
    public Button moveButton;
    public Button releaseCharacter;
    public Sprite playButton;
    public Sprite resetCharacter;
    private bool characterReleased;

    public Image infoBoxCantPlaceItem;
    public Text infoBoxText;

    private GameManager gameManager;

    private bool fadeItem;
    private float alpha;
    
    void Start()
    {
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

        if (gameManager.editMode == false)
        {
            confirmButton.GetComponent<Image>().sprite = confirmButtonGreen;
        }

        if (gameManager.activeItem == null)
        {
            GreyOutButtons();
        }
        else
        {
            GreyOutButtonsCancel();
        }
    }

    public void Rotate()
    {
        gameManager.ObjectRotating();
        print("Rotate Clicked");
    }

    public void Move()
    {
        gameManager.ObjectMoving();
        print("Move clicked");
    }

    public void Confirm()
    {
        gameManager.ConfirmButtonPressed();
    }

    public void Release()
    {
        if (characterReleased == false)
        {
            releaseCharacter.GetComponent<Image>().sprite = resetCharacter;
            gameManager.CreatePlayer();
            gameManager.ReleaseButtonPressed();
            gameManager.timeMachine.slowTimeDown = false;
            characterReleased = true;
        }
        else
        {
            gameManager.DestroyExistingCharacter();
            characterReleased = false;
            gameManager.gameInMotion = false;
            gameManager.blockMovement = false;
            gameManager.timeMachine.slowTimeDown = false;
            releaseCharacter.GetComponent<Image>().sprite = playButton;
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void ShowInfoBoxCantBePlacedHere()
    {
        alpha = 1f;
        infoBoxCantPlaceItem.gameObject.SetActive(true);
        fadeItem = true;
        infoBoxText.text = "This item can't be placed here";
    }

    public void ShowInfoBoxPleaseResetTheCharacter()
    {
        alpha = 1f;
        infoBoxCantPlaceItem.gameObject.SetActive(true);
        fadeItem = true;
        infoBoxText.text = "You need to reset the character first";
    }

    public void FadeObject()
    {
        infoBoxCantPlaceItem.color = new Color(255, 255, 255, alpha);
        infoBoxText.GetComponent<Text>().color = new Color(0, 0, 0, alpha);
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
