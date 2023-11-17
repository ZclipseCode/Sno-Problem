using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Icicle"))
        {
            SfxManager.icicleShatter?.Invoke();

            Destroy(collision.gameObject);
        }
    }
}
