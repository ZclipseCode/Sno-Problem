using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void ActivateTransitionDelegate();
    public static ActivateTransitionDelegate activateTransition;
    public delegate void NextSceneDelegate();
    public static NextSceneDelegate nextScene;

    public static bool isMining;

    private void Awake()
    {
        nextScene += NextScene;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDestroy()
    {
        nextScene -= NextScene;
    }
}
