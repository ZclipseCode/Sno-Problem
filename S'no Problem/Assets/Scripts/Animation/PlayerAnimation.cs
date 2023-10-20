using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    readonly string IS_WALKING = "isWalking";
    Animator animator;
    PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float input = playerControls.Player.Movement.ReadValue<float>();
        
        if (Mathf.Abs(input) > 0)
        {
            animator.SetBool(IS_WALKING, true);
        }
        else
        {
            animator.SetBool(IS_WALKING, false);
        }
    }

    private void OnDestroy()
    {
        playerControls.Player.Disable();
    }
}
