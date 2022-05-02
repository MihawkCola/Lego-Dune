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
    [SerializeField] private float maxSpeed = 5f;

    private Vector3 forceDirection = Vector3.zero;

    private bool canDoubleJump = false;
    private float colliderOffset;


    Vector3 vertical, horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputs = new PlayerInput(); 
    }
    private void OnEnable()
    {
        inputs.Player.Jump.started += firstJump;
        inputs.Player.Jump.started += secondJump;
        inputs.Player.Sneaking.started += sneaking;
        inputs.Player.Enable();
    }


    private void OnDisable()
    {
        inputs.Player.Jump.started -= firstJump;
        inputs.Player.Jump.started -= secondJump;
        inputs.Player.Sneaking.started -= sneaking;
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
        this.movementUpdate();
    }

    private void movementUpdate() {

        Vector2 move = inputs.Player.Movment.ReadValue<Vector2>();
        //Debug.Log(move);

        movementAnimation(move);

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

        this.rotiereMovement();
    }

    private void movementAnimation(Vector2 move)
    {
        if (move.x >= 0.7f || move.y >= 0.7f) 
        {
            // rennen Animation;
        }

        //todo schleichen und normal laufen
    }

    private void rotiereMovement()
    {
        if (Vector3.Magnitude(rb.velocity) > 1)
        {
            Vector3 rotation = rb.velocity;
            rotation.y = 0;
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

    private void sneaking(InputAction.CallbackContext obj)
    {
        animator.SetBool("isWalking", true);
        Debug.Log("test");
    }

    private bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, colliderOffset + 0.1f);
    }
}
