using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class VideoHandler : MonoBehaviour
{
    public VideoPlayer mVideoPlayer;
    public Slider audioVolume;
    public Button StartButton;
    public Button PauseButton;
    public Button SoundButton;
    public AudioSource Videoaudio;
    public Text currentMinutes;
    public Text currentSeconds;
    public Text totalMinutes;
    public Text totalSeconds;
    public bool isPlaying;


    void Start() //사전설정
    {
        mVideoPlayer = GetComponent<VideoPlayer>();
        isPlaying = true; //옮겨야 하는것
        PauseButton.gameObject.SetActive(true);//옮겨야 하는것
        StartButton.gameObject.SetActive(false);//옮겨야 하는것

    }

    private void Update()
    {
        AudioVolume();
        if(isPlaying)
        {
            SetTotalTimeUI(); //영상의 시간이 얼마나 지났는지 알려주는 Ui함수
            SetCurrentTimeUI();
        }
    }
    private void SetCurrentTimeUI()
    {
        string minutes = Mathf.Floor((int)mVideoPlayer.time / 60).ToString("00");
        string seconds = ((int)mVideoPlayer.time % 60).ToString("00");

        currentMinutes.text = minutes;
        currentSeconds.text = seconds;
    }
    private void SetTotalTimeUI() //영상의 시간이 얼마나 지났는지 알려주는 Ui함수
    {
        string minutes = Mathf.Floor((int)mVideoPlayer.clip.length / 60).ToString("00");
        string seconds = ((int)mVideoPlayer.clip.length % 60).ToString("00");

        totalMinutes.text = minutes;
        totalSeconds.text = seconds;
    }

    public void AudioVolume() //오디오 볼륨
    {
        Videoaudio.volume = audioVolume.value;
    }

    public void OnClickSoundButton() //사운드 버튼을 클릭했을때
    {
        if (audioVolume.gameObject.activeSelf)
        {
            audioVolume.gameObject.SetActive(false);
        }
        else
        {
            audioVolume.gameObject.SetActive(true);
        }
    }

    public void OnClickButtonSkip() //5초스킵
    {
        if (mVideoPlayer.time > 0.0f)
        {
            mVideoPlayer.time += 5.0f;
        }
    }

    public void OnClickButtonBack() //5초 뒤로
    {
        if (mVideoPlayer.time > 0.0f)
        {
            mVideoPlayer.time -= 5.0f;
        }
    }
    public void PlayVideo() // 비디오 재생
    {
        PauseButton.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
        mVideoPlayer.Play();
        isPlaying = true;
    }

    public void StopVideo()// 비디오 멈춤
    {        
        StartButton.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
        mVideoPlayer.Pause();
        isPlaying = false;
    }
}