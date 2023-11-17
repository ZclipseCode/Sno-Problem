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
        if (collision.CompareTag("Snowball") && !collision.isTrigger)
        {
            SfxManager.bouncePadActivated?.Invoke();

            Bounce(collision.GetComponent<Rigidbody2D>());
        }
    }

    void Bounce(Rigidbody2D rb)
    {
        float horizontalDirection;

        if (rb.velocity.x != 0)
        {
            horizontalDirection = rb.velocity.x / Mathf.Abs(rb.velocity.x);
        }
        else
        {
            horizontalDirection = 0;
        }

        rb.AddForce(transform.right * horizontalBounceForce * horizontalDirection + transform.up * bounceForce);
    }
}
