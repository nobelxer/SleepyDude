using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour {

    Rigidbody2D myRig;

    public GameObject[] ignore;
 
    void Start () {
        myRig = GetComponent<Rigidbody2D>();

        foreach(GameObject gameObject in ignore) {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }     
    }
}
