using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//MainScene의 이벤트 클래스
public class MainUI : MonoBehaviour 
{
<<<<<<< Updated upstream
    public void OnEasyButtonClicked()
=======
    public TMP_Text BeginnerText;
    public TMP_Text IntermediateText;
    public TMP_Text AdvancedText;
    public TMP_Text ExpertText;
    public GameObject triangle1;
    public GameObject triangle2;
    public GameObject triangle3;
    public GameObject triangle4;

    private void Start()
    {
    }

    public void OnButtonPointerExit()
    {
        BeginnerText.color = Color.white;
        IntermediateText.color = Color.white;
        AdvancedText.color = Color.white;
        ExpertText.color = Color.white;
    }

    public void OnBeginnerButtonClicked()
>>>>>>> Stashed changes
    {
        GameManager.instance.LoadPlayMap(PlayMap.Easy);
    }
<<<<<<< Updated upstream
=======

    public void OnBeginnerButtonPointerEnter()
    {
        BeginnerText.color = new Color32(130, 163, 140, 255);
    }
>>>>>>> Stashed changes

    public void OnHardButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Hard);
    }
<<<<<<< Updated upstream
=======
    public void OnIntermediateButtonPointerEnter()
    {
        IntermediateText.color = new Color32(255, 226, 165, 255);
    }
>>>>>>> Stashed changes

    public void OnDesertButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Desert);
    }
<<<<<<< Updated upstream
=======
    public void OnAdvancedButtonPointerEnter()
    {
        AdvancedText.color = new Color32(239, 180, 255, 255);
    }
>>>>>>> Stashed changes

    public void OnDungeonButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Dungeon);
    }

    public void OnExitButtonClicked()
    {
<<<<<<< Updated upstream
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
=======
        ExpertText.color = new Color32(136, 255, 205, 255);
>>>>>>> Stashed changes
    }

}
