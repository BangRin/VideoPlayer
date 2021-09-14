using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class Track : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Slider TimeSlider;
    public VideoPlayer mVideoPlayer;
    private bool slide = false;

    // Start is called before the first frame update
    void Start()
    {
        TimeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Timeline();
    }

    public void OnPointerDown(PointerEventData a)
    {
        slide = true;
    }
    public void OnPointerUp(PointerEventData a)
    {
        float frame = (float)TimeSlider.value * (float)mVideoPlayer.frameCount;
        mVideoPlayer.frame = (long)frame;
        slide = false;
    }

    public void Timeline()
    {
        if(!slide)
        {
            TimeSlider.value = (float)mVideoPlayer.frame / (float)mVideoPlayer.frameCount;
        }
    }
}
