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


    void Start() //��������
    {
        mVideoPlayer = GetComponent<VideoPlayer>();
        isPlaying = true; //�Űܾ� �ϴ°�
        PauseButton.gameObject.SetActive(true);//�Űܾ� �ϴ°�
        StartButton.gameObject.SetActive(false);//�Űܾ� �ϴ°�

    }

    private void Update()
    {
        AudioVolume();
        if(isPlaying)
        {
            SetTotalTimeUI(); //������ �ð��� �󸶳� �������� �˷��ִ� Ui�Լ�
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
    private void SetTotalTimeUI() //������ �ð��� �󸶳� �������� �˷��ִ� Ui�Լ�
    {
        string minutes = Mathf.Floor((int)mVideoPlayer.clip.length / 60).ToString("00");
        string seconds = ((int)mVideoPlayer.clip.length % 60).ToString("00");

        totalMinutes.text = minutes;
        totalSeconds.text = seconds;
    }

    public void AudioVolume() //����� ����
    {
        Videoaudio.volume = audioVolume.value;
    }

    public void OnClickSoundButton() //���� ��ư�� Ŭ��������
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

    public void OnClickButtonSkip() //5�ʽ�ŵ
    {
        if (mVideoPlayer.time > 0.0f)
        {
            mVideoPlayer.time += 5.0f;
        }
    }

    public void OnClickButtonBack() //5�� �ڷ�
    {
        if (mVideoPlayer.time > 0.0f)
        {
            mVideoPlayer.time -= 5.0f;
        }
    }
    public void PlayVideo() // ���� ���
    {
        PauseButton.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
        mVideoPlayer.Play();
        isPlaying = true;
    }

    public void StopVideo()// ���� ����
    {        
        StartButton.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
        mVideoPlayer.Pause();
        isPlaying = false;
    }
}