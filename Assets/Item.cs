using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Item : MonoBehaviour
{
    public VideoClip[] videos;
    Button playBtn;
    public AudioClip audioClip;

    float time = 2;
    float timer;
    bool canClose;

    void Start()
    {
        playBtn = GetComponent<Button>();
        playBtn.onClick.AddListener(PlayVideo);
    }
    
    void PlayVideo()
    {
        if (videos.Length > 0)
        {
            GameManager.Instance.PlayVideo(this);
        }

        if(audioClip != null)
        {
            GameManager.Instance.PlayAudio(audioClip);
        }
    }
}
