using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public AudioSource audioS;
    public VideoView videoView;
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Instance = this;
    }

 
    internal void PlayAudio(AudioClip audioClip)
    {
        audioS.Stop();
        audioS.clip = audioClip;
        audioS.Play();
    }
    public void PlayVideo(Item item)
    {
        videoView.Play(item);
    }
}
