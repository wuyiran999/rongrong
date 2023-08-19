using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class VideoView : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    public Item item;
    public VideoPlayer vp;
    private float timer;
    public float time = 3f;
    private bool canClose;
    private int index;

    private float deltaY;
    private Button backBtn;
    // Start is called before the first frame update
    void Start()
    {
        backBtn = GetComponent<Button>();
        backBtn.onClick.AddListener(OnBack);
    }

    private void OnBack()
    {
        if(Mathf.Abs(deltaY) < 10f)
        {
            Stop();
        }
    }

    private void Update()
    {
        if (timer < time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            canClose = true;
        }
    }


    public void Play(Item _item)
    {
        gameObject.SetActive(true);

        item = _item;
        index = Random.Range(0, item.videos.Length);

        PlayVideo(index);
    }

    public void PlayVideo(int index)
    {
        gameObject.SetActive(true);

        vp.Stop();
        vp.clip = item.videos[index];
        vp.Play();
    }

    public void Stop()
    {
        if (canClose)
        {
            timer = 0;
            canClose = false;
            vp.Stop();
            gameObject.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        deltaY = eventData.position.y - deltaY;
        Debug.Log(deltaY);
        if (deltaY < -20f)
        {
            index--;
            index = Mathf.Clamp(index, 0, item.videos.Length - 1);
            PlayVideo(index);
        }
        else if (deltaY > 20f)
        {
            index++;
            index = Mathf.Clamp(index, 0, item.videos.Length - 1);
            PlayVideo(index);
        }
        else
        {
            //Stop();
        }
        deltaY = 0f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        deltaY = eventData.position.y;
    }
}
