using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] float bounceForce = 1;
    float horizontalBounceForce;

    private void Start()
    {
        horizontalBounceForce = bounceForce / 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snowball"))
        {
            Bounce(collision.GetComponent<Rigidbody2D>());
        }
    }

    void Bounce(Rigidbody2D rb)
    {
        float horizontalDirection = rb.velocity.x / Mathf.Abs(rb.velocity.x);

        rb.AddForce(new Vector2(horizontalBounceForce * horizontalDirection, bounceForce));
    }
}
