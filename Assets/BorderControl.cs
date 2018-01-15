using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour
{

    public GameObject borderControl;
    private SpriteRenderer imageRenderer;
    public float screenHeight;
    public float screenWidth;
    public Vector3 objectSize;
    public GameObject spawnedBorder;
   

    void Awake()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }
    void Start()
    {
        imageRenderer = borderControl.GetComponent<SpriteRenderer>();
        Vector3 mPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        objectSize = imageRenderer.bounds.size;
        mPos.z = 0;
        mPos.x -= imageRenderer.bounds.size.x/ 1.6f;
        mPos.y -= imageRenderer.bounds.size.y/ 2 - objectSize.y / 2;
        spawnedBorder = Instantiate(borderControl, Vector3.zero, Quaternion.identity);
        spawnedBorder.transform.position = mPos;
        mPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
        mPos.x += imageRenderer.bounds.size.x / 1.6f;
        spawnedBorder = Instantiate(borderControl, Vector3.zero, Quaternion.identity);
        spawnedBorder.transform.position = mPos;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PlaceScreenBorders()
    {

    }
}
