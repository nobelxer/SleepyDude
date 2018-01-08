using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{

    public Button inventoryButton;
    public bool panelSlidOut;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void SlideInAndOut()
    {
        if (panelSlidOut == false)
        {
            animator.SetBool("SlideOut", true);
            animator.SetBool("SlideIn", false);
            panelSlidOut = true;
        }
        else
        {
            animator.SetBool("SlideOut", false);
            animator.SetBool("SlideIn", true);
            panelSlidOut = false;
        }
    }
}
