using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyAI : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    private void OnDisable()
    {
        agent.enabled = false;
    }
    private void OnEnable()
    {
        agent.enabled = true;
    }
    public float distanceTarget()
    {
        return Vector3.Distance(this.transform.position, target.position);
    }
}
