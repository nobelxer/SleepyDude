using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject activeDrag;
    public GameObject player;
    public GameObject playerSpawn;
    private GameObject playerInstance;

    public bool activeRotate;
    public bool activeMove;
    public bool mouseOverHUD;
    public bool stopPlayerMoving = true;

    public Text rotate;
    public Text move;

    public float touchSensitivityMultiplier;
    public float gravityScale;

    void Start()
    {  
       Screen.orientation = ScreenOrientation.Portrait;
        if (Application.platform == RuntimePlatform.Android)
        {
            touchSensitivityMultiplier = 0.3f;
        } else {
            touchSensitivityMultiplier = 0.1f;
        }

        mouseOverHUD = false;
        CreatePlayer();
    }


    void Update () {       
        rotate.text = activeRotate.ToString();
        move.text = activeMove.ToString();
    }

    // Set last clicked item to active for dragging
    public void SetActiveDrag(GameObject target)
    {
        activeRotate = false; // reset activeRotate value every time target changes
        activeDrag = target;  
    }

    public void CreatePlayer()
    {
        Destroy(playerInstance);
        playerInstance = Instantiate(player, playerSpawn.transform.position, playerSpawn.transform.rotation);
        playerInstance.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        print("creating new player");
        gravityScale = Random.Range(1, 5);
        stopPlayerMoving = true;
    }

    public void ObjectRotating()
    {
        activeMove = false;
        activeRotate = true;
    }

    public void ObjectMoving()
    {
        activeMove = true;
        activeRotate = false;
    }

    public void ObjectSwapControl()
    {
        if (activeMove)
        {
            activeMove = false;
            activeRotate = true;
        }else if (activeRotate)
        {
            activeMove = true;
            activeRotate = false;
        }
    }
}
