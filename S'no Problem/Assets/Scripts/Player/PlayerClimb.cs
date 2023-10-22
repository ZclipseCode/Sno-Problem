using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Rigidbody2D rb;
    PlayerControls playerControls;
    float gravityScale;

    bool hasInteracted;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        playerControls = new PlayerControls();
        playerControls.Player.Enable();

        gravityScale = rb.gravityScale;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float input = playerControls.Player.Climb.ReadValue<float>();

        if (Mathf.Abs(input) > 0)
        {
            hasInteracted = true;
        }

        if (collision.CompareTag("Ladder") && hasInteracted)
        {
            Climb();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            ClimbEnd();
        }
    }

    void Climb()
    {
        float input = playerControls.Player.Climb.ReadValue<float>();
        rb.gravityScale = 0;
        rb.velocity = new Vector2(rb.velocity.x, input * speed);
    }

    void ClimbEnd()
    {
        rb.gravityScale = gravityScale;

        hasInteracted = false;
    }

    private void OnDestroy()
    {
        playerControls.Player.Disable();
    }
}
