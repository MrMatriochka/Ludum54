using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    [HideInInspector] public BaseIA bouf;
    bool pressed;
    void Start()
    {
        
    }
    public Material mat1;
    public Material mat2;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Buttonfunction();
        }

        //if (pressed)
        //{
        //    GetComponent<Renderer>().material = mat1;
        //}else GetComponent<Renderer>().material = mat2;

    }

    void Buttonfunction()
    {
        if (pressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                if (hit.collider.CompareTag("Screen"))
                {
                    bouf.StopMoving();
                    bouf.MoveTo(hit.collider.GetComponent<MoveRoom>().desination.position);
                    
                }
            }
        }

        if (!pressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20))
            {
                pressed = false;
                if (hit.collider.gameObject == gameObject)
                {
                    pressed = true;
                }
            }
        }
        else
        {
            pressed = false;
        }
    }
}
