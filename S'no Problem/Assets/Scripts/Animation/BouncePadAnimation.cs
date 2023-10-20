using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadAnimation : MonoBehaviour
{
    [SerializeField] float springTime = 1;
    readonly string IS_SPRUNG = "isSprung";
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snowball"))
        {
            StartCoroutine(Bounce());
        }
    }

    IEnumerator Bounce()
    {
        animator.SetBool(IS_SPRUNG, true);

        yield return new WaitForSeconds(springTime);

        animator.SetBool(IS_SPRUNG, false);
    }
}
