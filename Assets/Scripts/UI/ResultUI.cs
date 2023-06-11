using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public GameObject resultCanvas;
    public TMP_Text homeText;
    public TMP_Text restartText;
    public TMP_Text exitText;
    public TMP_Text result;

    public void ShowResult(bool cleared)
    {
        resultCanvas.SetActive(true);
        UpdateResultText(cleared);
    }

    public void ResumeGame()
    {
        Time.timeScale = GameManager.instance.GameSpeed;
        GameManager.instance.isPaused = false;
        resultCanvas.SetActive(false);
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

    private void UpdateResultText(bool cleared)
    {
        if (!cleared)
        {
            result.text = "Game Over";
        }
        else
        {
            result.text = "Game Complete";
        }
    }
}
