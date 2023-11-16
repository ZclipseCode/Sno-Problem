using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickLoadScene : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        PauseManager.paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
