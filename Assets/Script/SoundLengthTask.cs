using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLengthTask : MonoBehaviour
{
    AudioSource audio;
    public TaskPoint task;
    public GameManager manager;
    public float timer = 60;
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(SoundSequence());
        StartCoroutine(Timer());
    }

    public GameObject led;
    public float bipNumMax;
    public float bipNumMin; 
    IEnumerator SoundSequence()
    {
        float waitTime = Random.Range(bipNumMin, bipNumMax);
        yield return new WaitForSeconds(waitTime);
        audio.Play();
        led.SetActive(true);
        waitTime = Random.Range(bipNumMin, bipNumMax);
        yield return new WaitForSeconds(waitTime);
        led.SetActive(false);
        audio.Stop();
        yield return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Confirm();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        manager.TaskFailed();

        task.TaskComplete();

        transform.parent.gameObject.SetActive(false);
        yield return null;
    }
    public void Confirm()
    {
        if (audio.isPlaying)
        {
            task.TaskComplete();
        }
        else
        {
            manager.TaskFailed();

            task.TaskComplete();

            transform.parent.gameObject.SetActive(false);
        }    

    }
}
