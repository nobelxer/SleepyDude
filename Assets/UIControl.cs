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

    public bool fadeResetCharacterArrow;

    public Image infoBoxCantPlaceItem;
    public Text infoBoxText;

    public Image resetCharacterArrow;
    public float arrowAlpha = 1;

    private GameManager gameManager;

    private bool fadeItem;
    private float alpha;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        infoBoxCantPlaceItem.gameObject.SetActive(false);
        resetCharacterArrow.gameObject.SetActive(false);
    }

    void Update()
    {
        // controls objects alphas
        // to do limit this or remove from update
        alpha -= Time.deltaTime / 2;
        arrowAlpha -= Time.deltaTime / 3;


        // remove Reset Player info box if Reset button clicked
        if (gameManager.gameInMotion == false)
        {
            if (gameManager.cantPlaceHere == false) {
                infoBoxCantPlaceItem.gameObject.SetActive(false);
                resetCharacterArrow.gameObject.SetActive(false);
            }
        }
          
        // fades UI elements
        if (fadeResetCharacterArrow)
        {
            FadeResetCharacterArrow();
        }

        if (fadeItem)
        {
            FadeObject();
        }

        // confrim button icon control
        if (!gameManager.cantPlaceHere)
        {
            confirmButton.GetComponent<Image>().sprite = confirmButtonGreen;
        }
        else
        {
            confirmButton.GetComponent<Image>().sprite = confirmButtonOrange;
        }

        // reset character button control
        if (gameManager.editMode == false)
        {
            confirmButton.GetComponent<Image>().sprite = confirmButtonGreen;
        }

        // grey outs buttons if there is no active item
        if (gameManager.activeItem == null)
        {
            GreyOutButtons();
        }
        else
        {
            GreyOutButtonsCancel();
        }
    }

    // buttons logic
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
        if (gameManager.cantPlaceHere == false)
        {
            if (characterReleased == false)
            {
                releaseCharacter.GetComponent<Image>().sprite = resetCharacter;
                gameManager.SpawnPlayer();
                gameManager.SpawnBed();
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
        else
        {
            print("info box gameManager.uiControl.ShowInfoBoxCantBePlacedHere();");
            gameManager.uiControl.ShowInfoBoxCantBePlacedHere();
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    // info box control
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
        ShowResetCharacterArrow();
        fadeItem = true;
        infoBoxText.text = "You need to reset the character first";
    }

    public void ShowResetCharacterArrow()
    {
        arrowAlpha = 1f;
        fadeResetCharacterArrow = true;
        resetCharacterArrow.gameObject.SetActive(true);
    }

    public void FadeObject()
    {
        infoBoxCantPlaceItem.color = new Color(255, 255, 255, alpha);
        infoBoxText.GetComponent<Text>().color = new Color(0, 0, 0, alpha);
        fadeResetCharacterArrow = true;
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

    void FadeResetCharacterArrow()
    {
        resetCharacterArrow.GetComponent<Image>().color = new Color(255, 255, 255, arrowAlpha);

        if (arrowAlpha < 0)
        {
            resetCharacterArrow.gameObject.SetActive(false);
            fadeResetCharacterArrow = false;
        }
    }
}
