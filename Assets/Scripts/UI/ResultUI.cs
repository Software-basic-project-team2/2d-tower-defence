using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public GameObject resultUI;
    public TMP_Text homeText;
    public TMP_Text restartText;
    public TMP_Text exitText;
    public TMP_Text result;
    private PlayerController player;

    private void Update()
    {

    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        ResultText();
    }

    public bool isPaused()
    {
        return resultUI.activeSelf;
    }

    public void ResumeGame()
    {
        Time.timeScale = GameManager.instance.GameSpeed;
        GameManager.instance.isPaused = false;
        resultUI.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameManager.instance.isPaused = true;
        resultUI.SetActive(true);
    }


    public void OnHomeButtonClicked()
    {
        ResumeGame();
        GameManager.instance.LoadMainScene();
    }

    public void OnRestartButtonClicked()
    {
        ResumeGame();
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

    private void ResultText()
    {
        if (player.currentHP <= 0)
        {
            result.text = "Game Over";
        }
        else
        {
            result.text = "Game Complete";
        }
    }
}
