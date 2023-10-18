using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.isMining && (collision.CompareTag("Player")))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Snowball"))
        {
            Destroy(collision.gameObject);
        }
    }
}
