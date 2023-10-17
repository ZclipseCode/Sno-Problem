using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] float pullSpeed = 1;
    float distanceThreshold = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snowball"))
        {
            StopSnowball(collision.gameObject);

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            StartCoroutine(PullTowardsCenter(rb));
        }
    }

    IEnumerator PullTowardsCenter(Rigidbody2D rb)
    {
        float startY = rb.transform.position.y;

        while (Vector2.Distance(new Vector2(rb.position.x, startY), new Vector2(center.position.x, startY)) > distanceThreshold)
        {
            float xDirection = center.transform.position.x - rb.transform.position.x;
            rb.MovePosition(rb.transform.position + new Vector3(xDirection * pullSpeed * Time.fixedDeltaTime, 0, 0));

            yield return null;
        }
    }

    void StopSnowball(GameObject snowball)
    {
        snowball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        snowball.GetComponent<Rigidbody2D>().gravityScale = 0;
        snowball.GetComponent<Collider2D>().enabled = false;
    }
}
