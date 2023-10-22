using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] float pullSpeed = 1;
    [SerializeField] int targetSnowballs = 2;
    float distanceThreshold = 0.01f;
    float previousSnowballHeight = 0;
    float snowmanIntersection = 0.08f;
    int sortingOrder = 0;
    int totalSnowballs;

    List<float> snowballRadi;

    private void Start()
    {
        snowballRadi = new List<float>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snowball"))
        {
            IncreaseSnowballs(collision.bounds.size.y / 2);

            sortingOrder++;
            SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
            sr.sortingOrder = sortingOrder;

            StopSnowball(collision.gameObject);

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            previousSnowballHeight = previousSnowballHeight * 2 + collision.bounds.size.y / 2 - snowmanIntersection;

            StartCoroutine(PullTowards(rb, new Vector3(center.position.x, previousSnowballHeight + center.position.y, 0)));
        }
    }

    IEnumerator PullTowards(Rigidbody2D rb, Vector3 destination)
    {
        while (Vector2.Distance(rb.position, destination) > distanceThreshold)
        {
            float xDirection = destination.x - rb.transform.position.x;
            float yDirection = destination.y - rb.transform.position.y;

            rb.MovePosition(rb.transform.position + new Vector3(xDirection, yDirection, 0) * pullSpeed * Time.fixedDeltaTime);

            yield return null;
        }
    }

    void StopSnowball(GameObject snowball)
    {
        snowball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        snowball.GetComponent<Rigidbody2D>().gravityScale = 0;
        snowball.GetComponent<Collider2D>().isTrigger = true;
    }

    void IncreaseSnowballs(float snowballRadius)
    {
        totalSnowballs++;
        snowballRadi.Add(snowballRadius);

        if (totalSnowballs >= targetSnowballs && snowballRadi[0] >= snowballRadi[1])
        {
            Debug.Log("Win");
        }
        else if (totalSnowballs >= targetSnowballs && snowballRadi[0] < snowballRadi[1])
        {
            Debug.Log("Lose");
        }
    }
}
