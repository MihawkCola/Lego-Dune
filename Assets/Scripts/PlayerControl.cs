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

    private PlayerInput inputs;

    [SerializeField] private Camera cam;

    [SerializeField] private float firstJumpForce = 10;
    [SerializeField] private float secondJumpForce = 5;
    [SerializeField] private float movmentForce = 10.0f;
    [SerializeField] private float fallVelocity = 1.0f;

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
        inputs.Player.Enable();
    }

    

    private void OnDisable()
    {
        inputs.Player.Jump.started -= firstJump;
        inputs.Player.Jump.started -= secondJump;
        inputs.Player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.collider = GetComponent<Collider>();
        this.rb = GetComponent<Rigidbody>();
        colliderOffset = collider.bounds.extents.y;
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

        // movement Version 1
        this.forceDirection += cam.transform.right * (move.x * this.movmentForce);
        this.forceDirection += this.cameraForward() * (move.y * this.movmentForce);

        rb.AddForce(this.forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;



        // movement Version 2
        Vector3 movement = new Vector3(move.x, 0.0f, move.y);
        Vector3 movementVektor = transform.TransformDirection(movement) * movmentForce + rb.velocity.y * Vector3.up;
        //############### Bewegung des Carakter aus der sicht der Camera ###############
        //           (                  X                   ) (             Y            ) (            Z             )
        //rb.velocity = cam.transform.right * movementVektor.x + Vector3.up * rb.velocity.y + this.cameraForward() * movementVektor.z;

        //rb.velocity = new Vector3(movementVektor.x, rb.velocity.y, movementVektor.z);
        //rb.AddForce(movementVektor, ForceMode.VelocityChange);

        if (Vector3.Magnitude(rb.velocity) > 1) 
        {
            Vector3 rotation = rb.velocity;
            rotation.y = 0;
            this.rb.rotation = Quaternion.LookRotation(rotation.normalized);
        }
        

        //Beschleunigt das Runterfallen
        //Debug.Log( Physics.gravity.y * Time.fixedDeltaTime);
        if (rb.velocity.y < 0f) rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime * fallVelocity;


        this.rotiereMovement(move);

    }

    private void rotiereMovement(Vector2 move)
    {
        
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
        rb.velocity = Vector3.up * this.firstJumpForce;
        //this.forceDirection = Vector3.up * this.firstJumpForce;
        canDoubleJump = true;
        Debug.Log("JUMP");
    }
    private void secondJump(InputAction.CallbackContext obj)
    {
        if (!canDoubleJump || this.isGrounded()) return;

        rb.velocity = Vector3.up * this.secondJumpForce;
        //this.forceDirection = Vector3.up * this.secondJumpForce;
        canDoubleJump = false;
        Debug.Log("SECOND JUMP");
    }
    
    private bool isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, colliderOffset + 0.1f);
    }
}
