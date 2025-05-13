using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public Button stopButton;
    public TextMeshProUGUI buttonText;

    private bool isPaused = false;

    void Start()
    {
        stopButton.onClick.AddListener(TogglePause);
        UpdateButtonText();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("gamestoped");

            // 에디터 멈추지 않음
           
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("gamerestarted");

            
        }


        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (buttonText != null)
            buttonText.text = isPaused ? "restart" : "stop";
    }
}
