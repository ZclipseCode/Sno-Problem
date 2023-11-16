using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform transition;
    [SerializeField] float transitionSpeed = 15;
    [SerializeField] GameObject title;
    [SerializeField] GameObject play;
    [SerializeField] GameObject howToPlay;
    [SerializeField] GameObject credits;

    //private void Awake()
    //{
    //    GameManager.activateTransition += ActivateTransition;
    //}

    private void Start()
    {
        LevelStart();
    }

    public void ActivateTransition(string scene)
    {
        StartCoroutine(TransitionOut(0, scene));
    }

    IEnumerator TransitionOut(float time, string scene)
    {
        yield return new WaitForSeconds(time);

        float targetScale = 10;
        float increment = transitionSpeed * Time.deltaTime;

        while (transition.localScale.x < targetScale)
        {
            transition.localScale += new Vector3(increment, increment, 0);

            yield return null;
        }

        // different!
        //GameManager.nextScene();
        GoToScene(scene);
    }

    IEnumerator TransitionIn()
    {
        float targetScale = 0;
        float decrement = transitionSpeed * Time.deltaTime;

        while (transition.localScale.x > targetScale)
        {
            transition.localScale -= new Vector3(decrement, decrement, 0);

            yield return null;
        }

        transition.localScale = Vector3.zero;
    }

    void LevelStart()
    {
        transition.localScale = new Vector3(10, 10, 0);
        StartCoroutine(TransitionIn());
    }

    public void OpenTitle()
    {
        title.SetActive(true);

        play.SetActive(false);
        howToPlay.SetActive(false);
    }

    public void OpenPlay()
    {
        play.SetActive(true);

        title.SetActive(false);
        howToPlay.SetActive(false);
        credits.SetActive(false);
    }

    public void OpenHowToPlay()
    {
        howToPlay.SetActive(true);

        title.SetActive(false);
        play.SetActive(false);
        credits.SetActive(false);
    }

    public void OpenCredits()
    {
        if (credits.activeSelf)
        {
            credits.SetActive(false);
        }
        else
        {
            credits.SetActive(true);
        }
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //private void OnDestroy()
    //{
    //    GameManager.activateTransition -= ActivateTransition;
    //}
}
