using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    public GameObject[] ignore;

    void Awake()
    { 
        foreach (GameObject gameObject in ignore)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
