using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//MainScene의 이벤트 클래스
public class StartManager : MonoBehaviour 
{
    //Easy Button Event
    public void StartEasyMode()
    {
        // 이지 모드를 선택하여 GameManager에 반영
        GameManager.instance.LoadGameScene(GameMode.Easy);
    }

    //Hard Button Event
    public void StartHardMode()
    {
        // 하드 모드를 선택하여 GameManager에 반영
        GameManager.instance.LoadGameScene(GameMode.Hard);
    }

    //Exit Button Event
    public void Exit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

}
