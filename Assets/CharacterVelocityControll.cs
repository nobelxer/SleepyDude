using UnityEngine;

public class CharacterVelocityControll : MonoBehaviour {

    public GameManager gameManager;
    public Vector3 myPosition;
    public Vector3 myPreviousPosition;
    public float checkEvery;
    public float distanceTraveled;
    public float acceptableDistance;

	void Start () {
        gameManager = GetComponent<GameManager>();     
	}

	void Update () {
        checkEvery += Time.deltaTime;
        myPosition = transform.position;
        SavePreviousPosition();
        distanceTraveled = Vector3.Distance(myPreviousPosition, myPosition);
    }

    void SavePreviousPosition()
    {
        if (checkEvery > 3)
        {
            myPreviousPosition = transform.position;
            CheckIfImMoving();
            checkEvery = 0;
        }
    }

    void CheckIfImMoving()
    {
        if (distanceTraveled < acceptableDistance)
        {
            print("Character is not moving");
        }
    }
}
