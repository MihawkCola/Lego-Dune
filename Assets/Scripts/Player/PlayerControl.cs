using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

//inspiriert Quelle: https://www.youtube.com/watch?v=WIl6ysorTE0&t=128s&ab_channel=OneWheelStudio
public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Collider coll;
    private Animator animator;

    private PlayerInput inputs;
    private bool movEnable = false;

    [SerializeField] private Camera cam;

    [SerializeField] private float firstJumpForce = 10;
    [SerializeField] private float secondJumpForce = 5;
    [SerializeField] private float movmentForce = 10.0f;
    [SerializeField] private float fallVelocity = 1.0f;
    public float maxSpeedNormal = 5f;

    [SerializeField] private float maxSpeedSneaking = 5f;
    public float maxSpeedRun = 5f;
    [SerializeField] private float groundDetection = 0.2f;

    private AudioSource[] sounds;
    AudioSource jumpSound;
    AudioSource attackSound;

    private Vector3 forceDirection = Vector3.zero;

    private bool canDoubleJump = false;
    private float maxSpeed;
    private float colliderOffset;

    private NavMeshAgent agent;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        maxSpeed = maxSpeedNormal;
        agent = GetComponent<NavMeshAgent>();
    }

    public void InputOn() {
        inputs.Player.Jump.started += firstJump;
        inputs.Player.Jump.started += secondJump;
        inputs.Player.Running.started += isRunning;
        inputs.Player.Running.canceled += isRunning;
        inputs.Player.Sneaking.started += isSneaking;
        inputs.Player.Sneaking.canceled += isSneaking;
        inputs.Player.Attack.started += isAttacking;
        movEnable = true;
        agent.enabled = false;
    }
    public void InputOff()
    {
        inputs.Player.Jump.started -= firstJump;
        inputs.Player.Jump.started -= secondJump;
        inputs.Player.Running.started -= isRunning;
        inputs.Player.Running.canceled -= isRunning;
        inputs.Player.Sneaking.started -= isSneaking;
        inputs.Player.Sneaking.canceled -= isSneaking;
        inputs.Player.Attack.started -= isAttacking;
        movEnable = false;
        agent.enabled = true;
    }

    public bool IsInputsSet()
    {
        return inputs != null;
    }

    // Start is called before the first frame update
    void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        this.coll = GetComponent<Collider>();
        this.rb = GetComponent<Rigidbody>();
        colliderOffset = coll.bounds.extents.y;
        this.animator = GetComponentInChildren<Animator>(true);

        sounds = GetComponents<AudioSource>();
        jumpSound = sounds[2];
        attackSound = sounds[3];
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, Vector3.down * (distGrounded + 0.1f), Color.yellow);
        /*Vector3 rotation = rb.velocity;
        rotation.y = 0;
        this.rb.rotation = Quaternion.LookRotation(rotation.normalized);*/

        //if(move.x != 0 || move.y != 0) rb.velocity = Vector3.right * move.x * 10 + Vector3.forward * move.y * 10 +Vector3.up * rb.velocity.y ;
        //rb.AddForce(Vector3.right * move.x* 1.0f + Vector3.forward * move.y * 1.0f, ForceMode.Impulse);
        //this.transform.position += (Vector3.right * move.x  + Vector3.forward * move.y);

    }
    private void FixedUpdate()
    {
        animator.SetBool("isGround", this.isGrounded());
        if(this.movEnable) this.movementUpdate();

        this.rotiereMovement();
        this.setMovmentAnimation();
        this.velocityDown();
    }

    private void movementUpdate() {

        Vector2 move = inputs.Player.Movment.ReadValue<Vector2>();
        //Debug.Log(move);

        // movement
        this.forceDirection += cam.transform.right * (move.x * this.movmentForce);
        this.forceDirection += this.cameraForward() * (move.y * this.movmentForce);

        rb.AddForce(this.forceDirection, ForceMode.Impulse);
        //Debug.Log(rb.velocity);
        forceDirection = Vector3.zero;

        // Speed limit;
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.magnitude > maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;



        //Debug.Log(rb.velocity.magnitude);
    }
    private void velocityDown() {
        if (rb.velocity.y < -0.1f) rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime * fallVelocity;
    }
    private void setMovmentAnimation()
    {
        Vector3 horizontalVelocity = rb.velocity;

        if (agent != null)
        {
            if (agent.enabled)
                horizontalVelocity = agent.velocity;
        }
        horizontalVelocity.y = 0;
        animator.SetFloat("speed", horizontalVelocity.magnitude);
    }

    private void rotiereMovement()
    {   
        Vector3 rotation = rb.velocity;
        rotation.y = 0;
        if (rotation.magnitude > 0.3)
        {
            this.rb.rotation = Quaternion.LookRotation(rotation.normalized);
        }

    }

    //extra da wir bei Forward den Y wert raus nehmen m�ssen
    private Vector3 cameraForward() 
    {
        Vector3 forward = cam.transform.forward;
        //Reset/Ignore y axis
        forward.y = 0;
        forward.Normalize();
        return forward;
    }
    //###############    Jump    ###############
    private void firstJump(InputAction.CallbackContext obj)
    {
        if (!this.isGrounded()) return;
        jumpSound.Play();
        this.forceDirection = Vector3.up * this.firstJumpForce;
        canDoubleJump = true;
        Debug.Log("JUMP");
    }
    private void secondJump(InputAction.CallbackContext obj)
    {
        if (!canDoubleJump || this.isGrounded()) return;
        this.forceDirection = Vector3.up * this.secondJumpForce;
        canDoubleJump = false;
        Debug.Log("SECOND JUMP");
    }

    private void isRunning(InputAction.CallbackContext obj)
    {
        //if (animator.GetBool("isSneaking")) return;
        

        animator.SetBool("isRun", !animator.GetBool("isRun"));
        if (animator.GetBool("isRun")) {
            maxSpeed = this.maxSpeedRun;
        }
        else
        {
            maxSpeed = this.maxSpeedNormal;
        }
    }
    private void isSneaking(InputAction.CallbackContext obj)
    {
        //if (animator.GetBool("isRun")) return;

        animator.SetBool("isSneak", !animator.GetBool("isSneak"));
        if (animator.GetBool("isSneak"))
        {
            maxSpeed = this.maxSpeedSneaking;
        }
        else
        {
            maxSpeed = this.maxSpeedNormal;
        }
    }

    private void isAttacking(InputAction.CallbackContext obj)
    {
        attackSound.Play();
        animator.SetTrigger("Attack");
    }
    private bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, colliderOffset + groundDetection);
    }
    public void setCam(Camera camera) {
        this.cam = camera;
    }
}
