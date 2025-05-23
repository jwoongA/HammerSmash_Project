using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using runner;
using TMPro;

public class GameOverUI : BaseUI
{
    
    public Button lobbyButton;


    protected override UIState GetUIState()
    {
        return UIState.GameOver; 
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (lobbyButton != null)
        {
           //restartButton.onClick.AddListener(OnRestartButtonClicked);
            lobbyButton.onClick.AddListener(OnLobbyButtonClicked);
        }
        else
        {
            Debug.LogWarning("Start Button이 연결되지 않았습니다.");
        }

    }

    public void OnRestartButtonClicked()
    {
        Debug.Log("버튼 클릭됨! → 게임 재시작");
        Time.timeScale = 1f;
        GameManager.Instance.ChangeState(GameState.InGame);
    }
   
    public void OnLobbyButtonClicked()
    {
        Debug.Log("버튼 클릭됨! 로비로");
        if (GameManager.Instance == null)
        {
            SceneManager.LoadScene("LobbyScene");
            Debug.LogError("GameManager 인스턴스가 존재하지 않습니다!");
        }
        else
        {
            Time.timeScale = 1f;
            GameManager.Instance.ChangeState(GameState.Lobby);
        }
    }
   
}
