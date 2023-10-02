using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    bool keyOn;
    public GameObject key;
    private void OnTriggerStay(Collider other)
    {

            if (other.CompareTag("Player"))
            {
                keyOn = true;
        }
            else keyOn = false;
        
    }
    private void OnTriggerExit(Collider other)
    {
        keyOn = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && keyOn)
        {
            key.GetComponent<KeyTask>().grabbed = false;
            key.GetComponent<KeyTask>().inKeyHole = true;
            key.transform.position = transform.position;
        }

    }
}
