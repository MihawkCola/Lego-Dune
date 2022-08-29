using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StartScreenPath : MonoBehaviour, EnemyInterface
{
    public Transform spawn;
    public Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rb;

    public float startDelay = 0f;

    private float nextAttackTime;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        nextAttackTime = Time.time;
    }

    void Update()
    {
        if (startDelay >= Time.time) return;
        setMovmentAnimation();
        if (!agent.enabled || target == null) return;

        rotationToPlayer();
        attackPlayer();
        this.goToPlayer();
    }

    private void rotationToPlayer()
    {
        Vector3 localPosToPlay = target.transform.position - this.transform.position;
        localPosToPlay.y = 0;

        this.rb.rotation = Quaternion.LookRotation(localPosToPlay.normalized);
    }

    private void attackPlayer()
    {
        if (agent.stoppingDistance >= this.distanceTarget()) {
            this.transform.position = new Vector3(spawn.position[0], spawn.position[1], spawn.position[2]);
        }
    }
    private void OnDisable()
    {
        agent.enabled = false;
    }
    private void OnEnable()
    {
        agent.enabled = true;
    }
    private void goToPlayer()
    {
        if (target == null) {
            agent.SetDestination(this.transform.position);
            return;
        }

        agent.SetDestination(target.position);
    }
    public float distanceTarget()
    {
        return Vector3.Distance(this.transform.position, target.position);
    }

    private void setMovmentAnimation()
    {
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        if (agent.velocity.magnitude > 0.1)
        {
            if (agent.enabled)
            {
                horizontalVelocity = agent.velocity;
                horizontalVelocity.y = 0;
            }
        }

        animator.SetFloat("speed", horizontalVelocity.magnitude);
    }

    public void setSpawn(Transform spawn)
    {
        this.spawn = spawn;
    }

    public void setTarget(Transform target)
    {
        this.target = target;
    }

    public void setDeath()
    {
        throw new NotImplementedException();
    }
}
