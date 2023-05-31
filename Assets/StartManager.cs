using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEasyMode()
    {
        // 이지 모드를 선택하여 GameManager에 반영
        GameManager.instance.easyMode = true;

        // 게임 씬으로 전환
        SceneManager.LoadScene("GameScene");
        Destroy(gameObject);
    }

    public void StartHardMode()
    {
        // 이지 모드를 선택하여 GameManager에 반영
        GameManager.instance.hardMode = true;

        // 게임 씬으로 전환
        SceneManager.LoadScene("GameScene");
        Destroy(gameObject);
    }

    public void Exit()
    {

    }
}
