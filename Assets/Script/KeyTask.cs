using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTask : MonoBehaviour
{
    Vector3 basePos;
    Quaternion baseRot;
    [HideInInspector] public bool grabbed;
    [HideInInspector] public bool inKeyHole;
    void Start()
    {
        basePos = transform.position;
        baseRot = transform.rotation;
    }
    void FixedUpdate()
    {
        if (!inKeyHole)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 20))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        grabbed = true;

                    }
                }
            }
            else grabbed = false;

            if (grabbed)
            {
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                transform.position = basePos;
                transform.rotation = baseRot;
            }
        }
        

        

    }
}
