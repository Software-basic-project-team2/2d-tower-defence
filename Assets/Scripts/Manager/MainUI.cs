using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//MainScene의 이벤트 클래스
public class MainUI : MonoBehaviour 
{
    public void OnEasyButtonClicked()
    {
        // 이지 모드를 선택하여 GameManager에 반영
        GameManager.instance.LoadPlayMap(PlayMap.Easy);
    }

    public void OnHardButtonClicked()
    {
        // 하드 모드를 선택하여 GameManager에 반영
        GameManager.instance.LoadPlayMap(PlayMap.Hard);
    }

    public void OnDesertButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Desert);
    }

    public void OnDungeonButtonClicked()
    {
        GameManager.instance.LoadPlayMap(PlayMap.Dungeon);
    }

    public void OnExitButtonClicked()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

}
