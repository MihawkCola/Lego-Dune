using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyAI : MonoBehaviour, EnemyInterface
{
    public Transform target;
    private NavMeshAgent agent;

    private Animator animator;
    private Rigidbody rb;

    public float attackCooldown = 2f;
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
        setMovmentAnimation();
        if (!agent.enabled || target == null) return;

        rotationToPlayer();
        attackPlayer();
        //animator.SetTrigger("Attack");
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
        if (Time.time < nextAttackTime) return;


        if (agent.stoppingDistance >= this.distanceTarget()) { 
            animator.SetTrigger("Attack"); 
            nextAttackTime = Time.time + attackCooldown;
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

    public void setTarget(Transform target)
    {
        this.target = target;
    }
}
