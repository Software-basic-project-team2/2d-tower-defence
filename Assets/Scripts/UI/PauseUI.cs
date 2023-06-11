using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    public TMP_Text homeText;
    public TMP_Text restartText;
    public TMP_Text exitText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused()) 
                ResumeGame();
            else            
                PauseGame();
        }
    }

    public bool isPaused()
    {
        return pauseUI.activeSelf;
    }

    public void ResumeGame()
    {
        Time.timeScale = GameManager.instance.GameSpeed;
        GameManager.instance.isPaused = false;
        pauseUI.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameManager.instance.isPaused = true;
        pauseUI.SetActive(true);
    }

    public void OnXButtonClicked()
    {
        ResumeGame();
    }

    public void OnHomeButtonClicked()
    {
        OnXButtonClicked();
        GameManager.instance.LoadMainScene();
    }
        
    public void OnRestartButtonClicked()
    {
        OnXButtonClicked();
        GameManager.instance.ReloadCurrentPlayMap();
    }

    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnHomeButtonPointerEnter()
    {
        homeText.text = "Home";
    }

    public void OnRestartButtonPointerEnter()
    {
        restartText.text = "Restart";
    }

    public void OnExitButtonPointerEnter()
    {
        exitText.text = "Exit";
    }

    public void OnPointerExit()
    {
        homeText.text = "";
        restartText.text = "";
        exitText.text = "";
    }
}
