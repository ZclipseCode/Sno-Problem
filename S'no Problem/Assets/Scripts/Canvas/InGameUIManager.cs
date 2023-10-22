using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI[] radi = new TextMeshProUGUI[2];
    [SerializeField] GameObject[] snowballGos = new GameObject[2];
    float[] snowballRadius;

    [SerializeField] RectTransform transition;
    [SerializeField] float transitionSpeed = 15;

    private void Awake()
    {
        SnowballSize.growth += ChangeSnowballRadius;
        GameManager.activateTransition += ActivateTransition;
    }

    private void Start()
    {
        LevelStart();

        level.text = SceneManager.GetActiveScene().name;

        snowballRadius = new float[radi.Length];

        ChangeSnowballRadius();
    }

    void ChangeSnowballRadius()
    {
        for (int i = 0; i < radi.Length; i++)
        {
            snowballRadius[i] = snowballGos[i].GetComponent<Collider2D>().bounds.size.y / 2;
            radi[i].text = snowballRadius[i].ToString("F2");
        }
    }

    void ActivateTransition()
    {
        StartCoroutine(WinTime());
    }

    IEnumerator TransitionOut()
    {
        float targetScale = 10;
        float increment = transitionSpeed * Time.deltaTime;

        while (transition.localScale.x < targetScale)
        {
            transition.localScale += new Vector3(increment, increment, 0);

            yield return null;
        }

        GameManager.nextScene();
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

    IEnumerator WinTime()
    {
        float winTime = 1.5f;

        yield return new WaitForSeconds(winTime);

        StartCoroutine(TransitionOut());
    }

    void LevelStart()
    {
        transition.localScale = new Vector3(10, 10, 0);
        StartCoroutine(TransitionIn());
    }

    private void OnDestroy()
    {
        SnowballSize.growth -= ChangeSnowballRadius;
        GameManager.activateTransition -= ActivateTransition;
    }
}
