using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondPlayerAi : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public float rangeMaxSpeed = 10;

    private PlayerControl control;

    public bool notWalk = false;



    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        control = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        disableAgent();
        rangeSpeed();
        if(agent.enabled) goToPlayer();
    }

    private void disableAgent()
    {
        bool enableAgent = !notWalk;
        if(this.distanceTarget() < 2)
            enableAgent = false;

        agent.enabled = enableAgent;
    }

    private void goToPlayer() {
        agent.SetDestination(target.position);
    }
    private void rangeSpeed() {
        float rangeToTarget = this.distanceTarget();

        if (rangeToTarget > rangeMaxSpeed) {
            agent.speed = control.maxSpeedRun;
            return;
        }

        agent.speed = control.maxSpeedNormal;
    }
    private void OnDisable()
    {
        agent.enabled = false;
    }
    private void OnEnable()
    {
        agent.enabled = true;
    }
    public float distanceTarget() {
        return Vector3.Distance(this.transform.position, target.position);
    }
}
