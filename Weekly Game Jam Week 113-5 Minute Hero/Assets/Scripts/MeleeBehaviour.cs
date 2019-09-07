using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeBehaviour : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    bool playerNearby = false;

    // Start is called before the first frame update
    void Start()
    {
        // agent = GetComponent<NavMeshAgent>();
        agent = transform.parent.GetComponent<NavMeshAgent>(); // This works, however I still can't shoot it while within the area
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearby)
        {
            agent.isStopped = false; // restarts agent if it were stopped
            agent.SetDestination(target.position);
        }
        Debug.DrawLine(agent.destination, new Vector3(agent.destination.x, agent.destination.y + 1f, agent.destination.z), Color.red);
    }

    // Detects if player have entered its range
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            target = other.transform;
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            playerNearby = false;
            agent.isStopped = true; // Stops agent
        }
    }
}
