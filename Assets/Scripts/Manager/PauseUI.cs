﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPaused = false;
    public TMP_Text homeText;
    public TMP_Text restartText;
    public TMP_Text exitText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        isPaused = false;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        isPaused = true;
    }

    public void OnXButtonClicked()
    {
        ResumeGame();
    }

    public void OnHomeButtonClicked()
    {
        GameObject.Find("EnemiesSpawner").GetComponent<EnemySpawner>().ResetSpawner();
        GameManager.instance.LoadMainScene();
    }
        
    public void OnRestartButtonClicked()
    {
        GameObject.Find("EnemiesSpawner").GetComponent<EnemySpawner>().ResetSpawner();
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
