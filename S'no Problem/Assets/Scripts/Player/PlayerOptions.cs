using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOptions : MonoBehaviour
{
    PlayerControls playerControls;
    bool restartPressed;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();
    }

    private void Update()
    {
        RestartLevel();
    }

    void RestartLevel()
    {
        if (playerControls.Player.Restart.ReadValue<float>() != 0 && !restartPressed)
        {
            restartPressed = true;
            GameManager.restartTransition?.Invoke();
        }
    }

    private void OnDestroy()
    {
        playerControls.Player.Disable();
    }
}
