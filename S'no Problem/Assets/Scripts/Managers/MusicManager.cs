using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] string[] titleScenes;
    [SerializeField] AudioClip title;
    [SerializeField] AudioClip inGame;
    public static MusicManager instance;
    AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (audioSource.clip == title)
        {
            for (int i = 0; i < titleScenes.Length; i++)
            {
                if (scene.name == titleScenes[i])
                {
                    return;
                }
            }
            
            audioSource.clip = inGame;
            audioSource.Play();
        }
        else if (audioSource.clip == inGame)
        {
            for (int i = 0; i < titleScenes.Length; i++)
            {
                if (scene.name == titleScenes[i])
                {
                    audioSource.clip = title;
                    audioSource.Play();

                    return;
                }
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
