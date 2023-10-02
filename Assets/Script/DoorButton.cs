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

    public Material open;
    public Material close;
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
            GetComponent<Renderer>().material = open;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    CloseDoor();
                }
            }
        }
    }

    public void CloseDoor()
    {
        clicked = true;
        GetComponent<Renderer>().material = close;
        animator.SetBool("Closed", true);
    }
}
