using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnowballRotate : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RotateSnowball();
    }

    void RotateSnowball()
    {
        transform.Rotate(0, 0, -rb.velocity.x);
    }
}
