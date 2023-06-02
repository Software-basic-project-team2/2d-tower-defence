using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    GameManager manager = GameManager.instance;

    public void StartEasyMode()
    {
        // 이지 모드를 선택하여 GameManager에 반영
        manager.Mode = GameMode.Easy;
        LoadGameScene();
    }

    public void StartHardMode()
    {
        // 하드 모드를 선택하여 GameManager에 반영
        manager.Mode = GameMode.Hard;
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        // 게임 씬으로 전환
        SceneManager.LoadScene("GameScene");
        Destroy(gameObject);

    }

    public void Exit()
    {

    }
}
