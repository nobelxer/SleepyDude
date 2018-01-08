using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{

    private GameManager gameManager;
    private CapsuleCollider2D capsuleCollider2D;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (gameManager.editMode)
        {
            capsuleCollider2D.isTrigger = true;
        }
        else
        {
            capsuleCollider2D.isTrigger = false;
        }

    }
}
