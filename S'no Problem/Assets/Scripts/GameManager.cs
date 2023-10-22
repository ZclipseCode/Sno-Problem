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

    [SerializeField] string goalScene = "Level 1";
    public static bool isMining;

    private void Awake()
    {
        nextScene += NextScene;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(goalScene);
    }

    private void OnDestroy()
    {
        nextScene -= NextScene;
    }
}
