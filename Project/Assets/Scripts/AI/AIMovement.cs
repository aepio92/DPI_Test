using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent AiAgent;
    private Animator AiAnimator;
    private Vector3 Destination;
    private float NextTimeToFindDestination;
    [SerializeField] private float MovementRadius = 4;

    void Start()
    {
        AiAgent = GetComponent<NavMeshAgent>();
        AiAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        SetAgentDestination();
    }

    //Getting Random position on the nav mesh
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    void SetAgentDestination()
    {
        if(Time.time>=NextTimeToFindDestination)
        {
            NextTimeToFindDestination = Time.time + 5;
            Destination = RandomNavmeshLocation(MovementRadius);
        }
        //setting the random position as the destination
        AiAgent.SetDestination(Destination);
        AiAnimator.SetFloat("Speed", AiAgent.velocity.magnitude);
    }
}
