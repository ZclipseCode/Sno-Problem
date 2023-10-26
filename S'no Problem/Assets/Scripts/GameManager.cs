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

    public delegate void RestartTransitionDelegate();
    public static RestartTransitionDelegate restartTransition;
    public delegate void GoToSceneDelegate(string scene);
    public static GoToSceneDelegate goToScene;

    [SerializeField] string goalScene = "Level 1";
    public static bool isMining;

    private void Awake()
    {
        nextScene += NextScene;
        goToScene += GoToScene;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(goalScene);
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OnDestroy()
    {
        nextScene -= NextScene;
        goToScene -= GoToScene;
    }
}
