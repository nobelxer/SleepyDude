using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPositionArrowControl : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private float alpha;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        alpha = Mathf.Clamp(1, 0f, 1f);
    }	

	void Update ()
    {
        Invoke("MakeTheArrowDisappear", 2f); 
    }

    private void MakeTheArrowDisappear()
    {
        alpha -= Time.deltaTime;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
    }
}
