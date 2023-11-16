using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public delegate void TogglePauseMenu();
    public static TogglePauseMenu togglePauseMenu;
    public static bool paused;
    [SerializeField] GameObject pauseMenu;

    private void Awake()
    {
        togglePauseMenu += Toggle;
    }

    public void Toggle()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            pauseMenu.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        togglePauseMenu -= Toggle;
    }
}
