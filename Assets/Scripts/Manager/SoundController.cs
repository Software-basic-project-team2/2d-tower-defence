using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider volumeSlider;
    public Button muteButton;
    public AudioSource audioSource;

    private bool isMuted;
    private Sprite[] speaker;

    void Start()
    {
        // 슬라이더의 값을 초기화합니다.
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // 음소거 버튼의 초기 상태를 설정합니다.
        isMuted = false;
        speaker = new Sprite[4];
        for (int i = 0; i < speaker.Length; i++)
            speaker[i] = Resources.Load<Sprite>("UIImage\\Speaker_" + i);

        muteButton.onClick.AddListener(OnMuteButtonClick);
        UpdateMuteButton();
    }

    void OnSliderValueChanged(float value)
    {
        // 슬라이더의 값을 이용하여 소리 크기를 조절합니다.
        audioSource.volume = value;
        if (audioSource.mute) 
        {
            OnMuteButtonClick();
        }
        UpdateMuteButton();
    }

    void OnMuteButtonClick()
    {
        // 음소거 버튼을 클릭하면 음소거 상태를 변경합니다.
        isMuted = !isMuted;

        // 음소거 상태에 따라 소리를 설정합니다.
        audioSource.mute = isMuted;

        UpdateMuteButton();
    }

    void UpdateMuteButton()
    {
        // 음소거 버튼의 이미지를 변경합니다.
        Image buttonImage = muteButton.transform.GetChild(0).GetComponentInChildren<Image>();
        Image buttonBackground = muteButton.transform.GetComponent<Image>();


        if (isMuted)
        {
            buttonImage.sprite = speaker[0];
            buttonImage.color = new Color32(255, 201, 201, 255);
            buttonBackground.color = new Color32(58, 58, 58, 255);
            return;
        }
        buttonImage.color = new Color32(58, 58, 58, 255);
        buttonBackground.color = new Color32(255, 201, 201, 255);
        float vol = audioSource.volume;
        int idx = 0;
        if (0 < vol) idx = (int)(vol * 3 + 1);
        else
        {
            buttonImage.color = new Color32(255, 201, 201, 255);
            buttonBackground.color = new Color32(58, 58, 58, 255);
        }

        if (idx > 3) idx = 3;
        buttonImage.sprite = speaker[idx];

    }
}
