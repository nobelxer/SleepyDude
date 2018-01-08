using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject activeDrag;
    public GameObject player;
    public GameObject playerSpawn;
    public UIControl uiControl;
    public TimeSlowDown timeMachine;
    private GameObject playerInstance;

    public bool activeRotate;
    public bool activeMove;
    public bool blockMovement;
    public bool stopPlayerMoving = true;
    public bool editMode;
    public bool cantPlaceHere;
    public bool canChangeItem = true;
    public bool gameInMotion;

    public float touchSensitivityMultiplier;
    public float gravityScale;

    void Start()
    {

        timeMachine = GetComponent<TimeSlowDown>();
        uiControl = GetComponent<UIControl>();

        Screen.orientation = ScreenOrientation.Portrait;
        if (Application.platform == RuntimePlatform.Android)
        {
            touchSensitivityMultiplier = 0.3f;
        }
        else
        {
            touchSensitivityMultiplier = 0.1f;
        }

        blockMovement = false;
        CreatePlayer();
    }

    void Update()
    {

        if (activeDrag != null)
        {
            editMode = true;
        }
        else
        {
            editMode = false;
        }

        if (gameInMotion)
        {
            editMode = false;
            blockMovement = true;
            activeMove = false;
            activeRotate = false;
            canChangeItem = false;
        }
    }

    // Set last clicked item to active for dragging
    public void SetActiveDrag(GameObject target)
    {

        activeRotate = false; // reset activeRotate value every time target changes
        activeDrag = target;
    }

    public void CreatePlayer()
    {

        DestroyExistingCharacter();
        playerInstance = Instantiate(player, playerSpawn.transform.position, playerSpawn.transform.rotation);
        playerInstance.transform.eulerAngles = new Vector3(0, 0, Random.Range(-47, 154));
        gravityScale = Random.Range(1, 5);
        stopPlayerMoving = true;
    }

    public void DestroyExistingCharacter()
    {
        Destroy(playerInstance);
    }

    public void ObjectRotating()
    {

        blockMovement = true;
        activeMove = false;
        activeRotate = true;
        Invoke("ReleaseMovement", 0.1f);
    }

    public void ObjectMoving()
    {
        blockMovement = true;
        activeMove = true;
        activeRotate = false;
        Invoke("ReleaseMovement", 0.1f);
    }

    public void ObjectSwapControl()
    {
        if (activeMove)
        {
            ObjectRotating();
        }
        else if (activeRotate)
        {
            ObjectMoving();
        }
    }

    public void ReleaseMovement()
    {
        blockMovement = false;
    }

    public void ConfirmButtonPressed()
    {
        if (CheckIfActiveItemCanBeChanged())
        {
            activeDrag = null;
            ObjectMoving();
        }
    }

    public void ReleaseButtonPressed()
    {
        if (CheckIfActiveItemCanBeChanged())
        {
            gameInMotion = true;
            activeDrag = null;
            stopPlayerMoving = false; // set to false to release hingeJoint2D
            gravityScale = 1;
        }
    }

    public bool CheckIfActiveItemCanBeChanged()
    {
        if (cantPlaceHere != true)
        {
            return canChangeItem = true;
        }
        else
        {
            uiControl.ShowInfoBoxCantBePlacedHere();
            return canChangeItem = false;
        }
    }

    public bool CheckIfActiveItemCanBeMoved()
    {
        if (gameInMotion != true)
        {
            return canChangeItem = true;
        }
        else
        {
            uiControl.ShowInfoBoxPleaseResetTheCharacter();
            return canChangeItem = false;
        }
    }

    public void SlowTimeDown()
    {
        timeMachine.DoSlowMotion();
    }
}
