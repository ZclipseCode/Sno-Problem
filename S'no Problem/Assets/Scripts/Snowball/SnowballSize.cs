using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSize : MonoBehaviour
{
    [SerializeField] float growthRate = 1;
    [SerializeField] LayerMask ground;
    [SerializeField] float restartWaitTime = 0.5f;
    float groundedRange;
    Rigidbody2D rb;
    float stoppingSpeed = 0.1f;
    float rangeAdjustment = 5.5f;

    public delegate void GrowthDelegate();
    public static GrowthDelegate growth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AdjustGroundedRange();
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
        AdjustGroundedRange();

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

    void AdjustGroundedRange()
    {
        groundedRange = transform.localScale.y / rangeAdjustment;
    }

    private void OnDestroy()
    {
        GameManager.restartTransition?.Invoke(restartWaitTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + Vector2.down * groundedRange);
    }
}
