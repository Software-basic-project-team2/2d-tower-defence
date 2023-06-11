using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//MainScene의 이벤트 클래스
public class MainUI : MonoBehaviour 
{
    public TMP_Text BeginnerText;
    public TMP_Text IntermediateText;
    public TMP_Text AdvancedText;
    public TMP_Text ExperText;

    public void OnXButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnButtonPointerExit()
    {
        BeginnerText.color = Color.white;
        IntermediateText.color = Color.white;
        AdvancedText.color = Color.white;
        ExperText.color = Color.white;
    }

    public void OnBeginnerButtonClicked()
    {
        // 이지 모드를 선택하여 GameManager에 반영
        GameManager.instance.LoadPlayMap(PlayMap.Easy);
    }
    public void OnBeginnerButtonPointerEnter()
    {
        BeginnerText.color = new Color32(130, 163, 140, 255);
    }


    public void OnIntermediateButtonClicked()
    {
        // 하드 모드를 선택하여 GameManager에 반영
        GameManager.instance.LoadPlayMap(PlayMap.Hard);
    }
    public void OnIntermediateButtonPointerEnter()
    {
        IntermediateText.color = new Color32(255, 226, 165, 255);
    }


    public void OnAdvancedButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Desert);
    }
    public void OnAdvancedButtonPointerEnter()
    {
        AdvancedText.color = new Color32(239, 180, 255, 255);
    }


    public void OnExpertButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Dungeon);
    }
    public void OnExpertButtonPointerEnter()
    {
        ExperText.color = new Color32(136, 255, 205, 255);
    }
}
