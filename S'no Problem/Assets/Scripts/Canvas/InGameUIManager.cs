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

    private void Awake()
    {
        SnowballSize.growth += ChangeSnowballRadius;
    }

    private void Start()
    {
        level.text = SceneManager.GetActiveScene().name;

        snowballRadius = new float[radi.Length];

        ChangeSnowballRadius();
    }

    void ChangeSnowballRadius()
    {
        for (int i = 0; i < radi.Length; i++)
        {
            snowballRadius[i] = snowballGos[i].GetComponent<Collider2D>().bounds.size.y / 2;
            radi[i].text = Math.Round(snowballRadius[i], 2).ToString();
        }
    }

    private void OnDestroy()
    {
        SnowballSize.growth -= ChangeSnowballRadius;
    }
}
