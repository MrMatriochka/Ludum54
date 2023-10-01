using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseIA : MonoBehaviour
{
	public NavMeshAgent navMeshAgent;
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
			if (navMeshAgent.remainingDistance <= 0.1f || !navMeshAgent.hasPath)
			{
				WanderAround();
			}
		}
        
		if(goToTask && navMeshAgent.remainingDistance <= 0.1f)
        {
			goToTask = false;

			task.fixing = false;
			task.fixNeeded = false;
			task.StartCoroutine("WaitForBroke");
			WanderAround();
			isWandering = true;
		}
    }

	[SerializeField] float distance = 10f;

	Vector3 aiWanderGoal = Vector3.zero;

	void WanderAround()
	{
		Vector3 randomDirection = Random.insideUnitSphere * distance;
		randomDirection += centerOfShip.transform.position;

		NavMeshHit navHit;
		NavMesh.SamplePosition(randomDirection, out navHit, distance, NavMesh.AllAreas);

		MoveTo(navHit.position);
	}

	void MoveTo(Vector3 location)
	{
		navMeshAgent.SetDestination(location);
	}
}