using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public bool clicked = false;
    public float timer;
    private float timerReset;

    private void Start()
    {
        timerReset = timer;
    }

    private void Update() 
    {
        if(clicked)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = timerReset;
            animator.SetBool("Closed", false);
        }
    }

    public void CloseDoor()
    {
        clicked = true;
        animator.SetBool("Closed", true);
    }
}
