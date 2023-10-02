using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseIA : MonoBehaviour
{
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public bool isWandering;
	[HideInInspector] public bool isRepairing;
	[HideInInspector] public bool goToTask;
	public GameObject centerOfShip;
	public TaskPoint task;
	void Start()
    {
		navMeshAgent = GetComponent<NavMeshAgent>();
		isWandering = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering)
        {
			if (navMeshAgent.remainingDistance <= 1f || !navMeshAgent.hasPath)
			{
				WanderAround();
			}
		}
        
		if(goToTask && navMeshAgent.remainingDistance <= 0.1f)
        {
			task.taskObj.SetActive(true);
			goToTask = false;			
		}
    }

	[SerializeField] float distance = 10f;

	public void WanderAround()
	{
		Vector3 randomDirection = Random.insideUnitSphere * distance;
		randomDirection += centerOfShip.transform.position;

		NavMeshHit navHit;
		NavMesh.SamplePosition(randomDirection, out navHit, distance, NavMesh.AllAreas);

		MoveTo(navHit.position);
	}
    public void StopMoving()
    {
		goToTask = false;
		isWandering = false;
    }
    public void MoveTo(Vector3 location)
	{
		navMeshAgent.SetDestination(location);
	}
}
