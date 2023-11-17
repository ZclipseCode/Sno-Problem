using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    bool lossSfxActivated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.isMining && (collision.CompareTag("Player")))
        {
            SfxManager.iceHit?.Invoke();

            if (!lossSfxActivated)
            {
                SfxManager.levelFailed?.Invoke();
                lossSfxActivated = true;
            }

            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Snowball"))
        {
            SfxManager.iceHit?.Invoke();

            if (!lossSfxActivated)
            {
                SfxManager.levelFailed?.Invoke();
                lossSfxActivated = true;
            }

            Destroy(collision.gameObject);
        }
    }
}
