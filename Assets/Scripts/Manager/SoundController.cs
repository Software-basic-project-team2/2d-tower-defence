using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider volumeSlider;
    public Button muteButton;
    public AudioSource audioSource;

    private bool isMuted;

    void Start()
    {

        // 슬라이더의 값을 초기화합니다.
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // 음소거 버튼의 초기 상태를 설정합니다.
        isMuted = false;
        UpdateMuteButton();
        muteButton.onClick.AddListener(OnMuteButtonClick);
    }

    void OnSliderValueChanged(float value)
    {
        // 슬라이더의 값을 이용하여 소리 크기를 조절합니다.
        audioSource.volume = value;
    }

    void OnMuteButtonClick()
    {
        // 음소거 버튼을 클릭하면 음소거 상태를 변경합니다.
        isMuted = !isMuted;
        UpdateMuteButton();

        // 음소거 상태에 따라 소리를 설정합니다.
        audioSource.mute = isMuted;
    }

    void UpdateMuteButton()
    {
        // 음소거 버튼의 텍스트를 변경합니다.
       Text buttonText = muteButton.GetComponentInChildren<Text>();
        if (isMuted)
        {
            buttonText.text = "On";
        }
        else
        {
            buttonText.text = "Off";
        }
    }
}
