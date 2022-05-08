using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//inspiriert Quelle: https://www.youtube.com/watch?v=WIl6ysorTE0&t=128s&ab_channel=OneWheelStudio
public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;
    private Animator animator;

    private PlayerInput inputs;

    [SerializeField] private Camera cam;

    [SerializeField] private float firstJumpForce = 10;
    [SerializeField] private float secondJumpForce = 5;
    [SerializeField] private float movmentForce = 10.0f;
    [SerializeField] private float fallVelocity = 1.0f;
    [SerializeField] private float maxSpeedNormal = 5f;

    [SerializeField] private float maxSpeedSneaking = 5f;
    [SerializeField] private float maxSpeedRun = 5f;
    [SerializeField] private float groundDetection = 0.2f;

    private Vector3 forceDirection = Vector3.zero;

    private bool canDoubleJump = false;
    private float maxSpeed;
    private float colliderOffset;


    Vector3 vertical, horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputs = new PlayerInput();
        maxSpeed = maxSpeedNormal;
    }
    private void OnEnable()
    {
        inputs.Player.Jump.started += firstJump;
        inputs.Player.Jump.started += secondJump;
        inputs.Player.Running.started += isRunning;
        inputs.Player.Running.canceled += isRunning;
        inputs.Player.Sneaking.started += isSneaking;
        inputs.Player.Sneaking.canceled += isSneaking;
        inputs.Player.Enable();
    }


    private void OnDisable()
    {
        inputs.Player.Jump.started -= firstJump;
        inputs.Player.Jump.started -= secondJump;
        inputs.Player.Running.started -= isRunning;
        inputs.Player.Running.canceled -= isRunning;
        inputs.Player.Sneaking.started -= isSneaking;
        inputs.Player.Sneaking.canceled -= isSneaking;
        inputs.Player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.collider = GetComponent<Collider>();
        this.rb = GetComponent<Rigidbody>();
        colliderOffset = collider.bounds.extents.y;
        this.animator = GetComponentInChildren<Animator>(true);
        
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
        this.movementUpdate();
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

        // Beschleunigt das Runterfallen
        if (rb.velocity.y < -0.1f) rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime * fallVelocity;


        // Speed limit;
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.magnitude > maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;



        //Debug.Log(rb.velocity.magnitude);
        this.rotiereMovement();
        this.setMovmentAnimation();
    }

    private void setMovmentAnimation()
    {
        Vector3 horizontalVelocity = rb.velocity;
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

    private bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, colliderOffset + groundDetection);
    }
}