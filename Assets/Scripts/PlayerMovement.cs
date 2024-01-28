using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 32f;

     public float moveSpeed = 5f;
    private Vector2 movementInput;

    private bool isPaused = false;

    void Start()
    {
        ControladorJuego.Instance.setPlayer(this.gameObject);    
        ControladorJuego.Instance.setRespawnPosition(transform.position);    
    }

    private void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(movementInput.x, movementInput.y);
        Vector2 moveVelocity = movement.normalized * moveSpeed;
        transform.Translate(moveVelocity * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void HandlePause(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            ControladorJuego.Instance.HandlePause();
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
