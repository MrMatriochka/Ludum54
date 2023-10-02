using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNumberTask : MonoBehaviour
{
    AudioSource audio;
    public TaskPoint task;
    void Start()
    {
        audio = GetComponent<AudioSource>();
       
    }

    private void OnEnable()
    {
        audio = GetComponent<AudioSource>();
        foreach (GameObject obj in inputsObj)
        {
            obj.GetComponent<Renderer>().material = off;
        }
        inputNum = 0;

        StartCoroutine(SoundSequence());
    }
    public int bipNumMax;
    public int bipNumMin;
    int bipNum;
    int inputNum;
    public GameObject led;
    public GameObject[] inputsObj;
    public Material on;
    public Material off;
    IEnumerator SoundSequence()
    {
        bipNum = Random.Range(bipNumMin, bipNumMax);
        for (int i = 1; i <= bipNum; i++)
        {
            yield return new WaitForSeconds(2);
            audio.Play();
            led.SetActive(true);
            float waitTime = Random.Range(0.5f, 1);
            yield return new WaitForSeconds(waitTime/2);
            led.SetActive(false);
            yield return new WaitForSeconds(waitTime / 2);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddInput();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Confirm();
        }
    }

    public void AddInput()
    {
        if (inputNum > 4)
        {
            foreach (GameObject obj in inputsObj)
            {
                obj.GetComponent<Renderer>().material = off;
            }
            inputNum = 0;
        }

        inputsObj[inputNum].GetComponent<Renderer>().material = on;
        inputNum++;
    }

    public void Confirm()
    {
        if(inputNum == bipNum)
        {
            task.TaskComplete();

            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            print("Loose");
        }
    }
}
