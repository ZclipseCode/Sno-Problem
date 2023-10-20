using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSize : MonoBehaviour
{
    [SerializeField] float growthRate = 1;
    [SerializeField] float groundedRange = 0.01f;
    [SerializeField] LayerMask ground;
    Rigidbody2D rb;
    float stoppingSpeed = 0.1f;

    public delegate void GrowthDelegate();
    public static GrowthDelegate growth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) > stoppingSpeed && IsGrounded())
        {
            Grow();
        }
    }

    void Grow()
    {
        float growthAdjustment = Time.deltaTime * 0.1f;

        transform.localScale = transform.localScale + new Vector3(growthRate * growthAdjustment, growthRate * growthAdjustment, 0);
        groundedRange += growthRate * growthAdjustment;

        growth?.Invoke();
    }

    bool IsGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, groundedRange, ground))
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + Vector2.down * groundedRange);
    }

    private void OnDestroy()
    {
        //growth -= Grow;
    }
}
