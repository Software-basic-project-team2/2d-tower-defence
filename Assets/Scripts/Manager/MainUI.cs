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
    private string PointerEnterText = "Play";
    public Color c = new Color32(255, 0, 0, 255);

    private void Start()
    {
        //BeginnerText.color = new Color32(255, 0, 0, 255);
    }

    private void ClearText()
    {
        BeginnerText.text = "";
        IntermediateText.text = "";
        AdvancedText.text = "";
        ExperText.text = "";
    }
    private void ResetText()
    {
        BeginnerText.text = "Beginner";
        BeginnerText.color = Color.white;
        IntermediateText.text = "Intermediate";
        IntermediateText.color = Color.white;
        AdvancedText.text = "Advanced";
        AdvancedText.color = Color.white;
        ExperText.text = "Expert";
        ExperText.color = Color.white;
    }
    public void OnButtonPointerExit()
    {
        ResetText();
    }

    public void OnBeginnerButtonClicked()
    {
        // 이지 모드를 선택하여 GameManager에 반영
        GameManager.instance.LoadPlayMap(PlayMap.Easy);
    }
    public void OnBeginnerButtonPointerEnter()
    {
        ClearText();
        BeginnerText.text = PointerEnterText;
        BeginnerText.color = new Color32(130, 163, 140, 255);
    }


    public void OnIntermediateButtonClicked()
    {
        // 하드 모드를 선택하여 GameManager에 반영
        GameManager.instance.LoadPlayMap(PlayMap.Hard);
    }
    public void OnIntermediateButtonPointerEnter()
    {
        ClearText();
        IntermediateText.text = PointerEnterText;
        IntermediateText.color = new Color32(255, 226, 165, 255);
    }


    public void OnAdvancedButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Desert);
    }
    public void OnAdvancedButtonPointerEnter()
    {
        ClearText();
        AdvancedText.text = PointerEnterText;
        AdvancedText.color = new Color32(239, 180, 255, 255);
    }


    public void OnExpertButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Dungeon);
    }
    public void OnExpertButtonPointerEnter()
    {
        ClearText();
        ExperText.text = PointerEnterText;
        ExperText.color = new Color32(136, 255, 205, 255);
    }
}
