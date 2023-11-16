using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float maxSpeed = 1;
    [SerializeField] bool facingRight;
    [SerializeField] float restartWaitTime = 0.5f;
    Rigidbody2D rb;
    PlayerControls playerControls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerControls = new PlayerControls();
        playerControls.Player.Enable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float input = playerControls.Player.Movement.ReadValue<float>();

        if (Mathf.Abs(input) > 0 && Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(new Vector2(input * speed, 0));
        }
        else if (Mathf.Abs(rb.velocity.x) >= maxSpeed)
        {
            rb.AddForce(new Vector2(rb.velocity.x - rb.velocity.x * maxSpeed, 0));
        }
        else if (input == 0 && Mathf.Abs(rb.velocity.x) > 0)
        {
            rb.AddForce(new Vector2(-rb.velocity.x * speed, 0));
        }

        if ((input > 0 && !facingRight) || (input < 0 && facingRight))
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void OnDestroy()
    {
        GameManager.restartTransition?.Invoke(restartWaitTime);

        playerControls.Player.Disable();
    }
}
