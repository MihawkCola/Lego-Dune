using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;

    private PlayerInput inputs;

    [SerializeField] private float firstJumpSpeed = 10;
    [SerializeField] private float secondJumpSpeed = 5;
    [SerializeField] private float movmentSpeed = 10.0f;

    private bool canDoubleJump = false;
    private bool isGround = true;
    private float distGrounded;


    Vector3 vertical, horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputs = new PlayerInput(); 
    }
    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.collider = GetComponent<Collider>();
        this.rb = GetComponent<Rigidbody>();
        distGrounded = collider.bounds.extents.y;
    }
    // Update is called once per frame
    void Update()
    {
        this.checkGrounded();

        Vector2 move = inputs.Player.Movment.ReadValue<Vector2>();
        Debug.Log(move);
        // movement Version 1
        Vector3 movement = new Vector3(move.x, 0.0f, move.y);
        Vector3 movementVektor = transform.TransformDirection(movement) * movmentSpeed;

        rb.velocity = new Vector3(movementVektor.x, rb.velocity.y, movementVektor.z);

        //if(move.x != 0 || move.y != 0) rb.velocity = Vector3.right * move.x * 10 + Vector3.forward * move.y * 10 +Vector3.up * rb.velocity.y ;
        //rb.AddForce(Vector3.right * move.x* 7.5f + Vector3.forward * move.y * 7.5f);
        //this.transform.position += (Vector3.right * move.x  + Vector3.forward * move.y);


        //###############    Jump    ###############
        if (inputs.Player.Jump.triggered && isGround)
        {
            this.firstjump();
        }
        else if (inputs.Player.Jump.triggered && canDoubleJump)
        {
            this.secondjump();
        }

        }
    private void FixedUpdate()
    {
       
    }
    void firstjump() {
        //rb.AddForce(Vector3.up * jumpSpeed);
        rb.velocity = Vector3.up * this.firstJumpSpeed;
        canDoubleJump = true;
        Debug.Log("JUMP");
    }
    void secondjump()
    {
        //rb.AddForce(Vector3.up * this.secondJumpSpeed);
        rb.velocity = Vector3.up * this.secondJumpSpeed;
        canDoubleJump = false;
        Debug.Log("SECOND JUMP");
    }
    void checkGrounded() {
        isGround = Physics.Raycast(transform.position, -Vector3.up, distGrounded + 0.1f);
    }
}
