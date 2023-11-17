using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public delegate void PickaxeCollectedDelegeate();
    public static PickaxeCollectedDelegeate pickaxeCollected;
    [SerializeField] AudioClip pickaxeCollectedClip;
    public delegate void BouncePadActivatedDelegate();
    public static BouncePadActivatedDelegate bouncePadActivated;
    [SerializeField] AudioClip bouncePadActivatedClip;
    public delegate void IcicleShatterDelegate();
    public static IcicleShatterDelegate icicleShatter;
    [SerializeField] AudioClip icicleShatterClip;
    public delegate void GoalAchievedDelegate();
    public static GoalAchievedDelegate goalAchieved;
    [SerializeField] AudioClip goalAchievedClip;
    public delegate void LevelFailedDelegate();
    public static LevelFailedDelegate levelFailed;
    [SerializeField] AudioClip levelFailedClip;
    //public delegate void ClimbLadderDelegate();
    //public static ClimbLadderDelegate climbLadder;
    //[SerializeField] AudioClip climbLadderClip;
    public delegate void IceHitDelegate();
    public static IceHitDelegate iceHit;
    [SerializeField] AudioClip iceHitClip;

    AudioSource audioSource;

    private void Awake()
    {
        pickaxeCollected += PickaxeCollected;
        bouncePadActivated += BouncePadActivated;
        icicleShatter += IcicleShatter;
        goalAchieved += GoalAchieved;
        levelFailed += LevelFailed;
        //climbLadder += ClimbLadder;
        iceHit += IceHit;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PickaxeCollected()
    {
        audioSource.PlayOneShot(pickaxeCollectedClip);
    }

    public void BouncePadActivated()
    {
        audioSource.PlayOneShot(bouncePadActivatedClip);
    }

    public void IcicleShatter()
    {
        audioSource.PlayOneShot(icicleShatterClip);
    }

    public void GoalAchieved()
    {
        audioSource.PlayOneShot(goalAchievedClip);
    }

    public void LevelFailed()
    {
        audioSource.PlayOneShot(levelFailedClip);
    }

    //public void ClimbLadder()
    //{
    //    audioSource.PlayOneShot(climbLadderClip);
    //}

    public void IceHit()
    {
        audioSource.PlayOneShot(iceHitClip);
    }

    private void OnDestroy()
    {
        pickaxeCollected -= PickaxeCollected;
        bouncePadActivated -= BouncePadActivated;
        icicleShatter -= IcicleShatter;
        goalAchieved -= GoalAchieved;
        levelFailed -= LevelFailed;
        //climbLadder -= ClimbLadder;
        iceHit -= IceHit;
    }
}
