using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject activeDrag;
    public GameObject player;
    public GameObject playerSpawn;
    public UIControl uiControl;
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
        uiControl = GetComponent<UIControl>();

       Screen.orientation = ScreenOrientation.Portrait;
        if (Application.platform == RuntimePlatform.Android)
        {
            touchSensitivityMultiplier = 0.3f;
        } else {
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
    }

    // Set last clicked item to active for dragging
    public void SetActiveDrag(GameObject target) {

        activeRotate = false; // reset activeRotate value every time target changes
        activeDrag = target;
    }

    public void CreatePlayer() {

        Destroy(playerInstance);
        playerInstance = Instantiate(player, playerSpawn.transform.position, playerSpawn.transform.rotation);
        playerInstance.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        print("creating new player");
        gravityScale = Random.Range(1, 5);
        stopPlayerMoving = true;
    }

    public void ObjectRotating() {

        blockMovement = true;
        activeMove = false;
        activeRotate = true;
        Invoke("ReleaseMovement", 0.1f);
    }

    public void ObjectMoving() {
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
        stopPlayerMoving = false; // set to false to release hingeJoint2D
        gravityScale = 1;
    }

    public bool CheckIfActiveItemCanBeChanged()
    {
        if (cantPlaceHere != true) {
            return canChangeItem = true;
        }
        else
        {
            uiControl.ShowInfoBoxCantBePlacedHere();
            return canChangeItem = false;            
        }
    }
}
