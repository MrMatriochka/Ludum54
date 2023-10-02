using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPoint : MonoBehaviour
{
    public GameObject taskObj;
    void Start()
    {
        StartCoroutine(WaitForBroke());
    }
    [HideInInspector] public bool fixing;
    [HideInInspector] public bool fixNeeded;

    public float minBrokeDelay;
    public float maxBrokeDelay;
    public Material broken;
    public Material repairing;
    public Material fix;
    void Update()
    {
        if (!fixNeeded)
        {
            GetComponent<Renderer>().material = fix;
        }
    }

    public IEnumerator WaitForBroke()
    {
        float timeBeforeNextBroke = Random.Range(minBrokeDelay, maxBrokeDelay);
        yield return new WaitForSeconds(timeBeforeNextBroke);
        fixNeeded = true;
        GetComponent<Renderer>().material = broken;
        yield return null;
    }

    BaseIA ia;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ia = other.GetComponent<BaseIA>();

            if (fixNeeded && !fixing && !ia.goToTask)
            {
                GetComponent<Renderer>().material = repairing;
                fixing = true;

                ia.navMeshAgent.SetDestination(transform.position);
                ia.isWandering = false;
                ia.goToTask = true;
                ia.task = GetComponent<TaskPoint>();
            }
        }
        
    }

    public void TaskComplete()
    {
        fixing = false;
        fixNeeded = false;
        StartCoroutine("WaitForBroke");

        ia.WanderAround();
        ia.isWandering = true;
    }
}
