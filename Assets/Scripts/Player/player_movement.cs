using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private InputActions_Controls input_actions;

    //player variables
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float moveSpeed = 5f, jumpForce = 2f;

    [SerializeField] private LayerMask groundLayer = 2;


    //private
    private Vector2 inputVector;


    private void Awake()
    {
        input_actions = new InputActions_Controls();
    }

    private void OnEnable()
    {
        input_actions.Player.Enable();

        input_actions.Player.Jump.performed += _ctx => Jump();
    }

    private void OnDisable()
    {
        input_actions.Player.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputVector = input_actions.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    // player movement calls

    private bool groundCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.6f, groundLayer);
    }

    private void Move()
    {
        Vector3 movementVector = inputVector * moveSpeed;

        rb.velocity = new Vector3(movementVector.x, rb.velocity.y, movementVector.y);
    }

    private void Jump()
    {
        if (!groundCheck()) return;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


}
