using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using runner;

public class GameOverUI : BaseUI
{
    public Button restartButton;
    public Button lobbyButton;

    protected override UIState GetUIState()
    {
        return UIState.GameOver; // 너의 UI 상태 Enum에 따라 변경
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            lobbyButton.onClick.AddListener(OnLobbyButtonClicked);
        }
        else
        {
            Debug.LogWarning("Start Button이 연결되지 않았습니다.");
        }

    }
    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1f;
        Debug.Log("버튼 클릭됨! → 게임 재시작");
        GameManager.Instance.ChangeState(GameState.InGame);
    }
   
    public void OnLobbyButtonClicked()
    {
        Time.timeScale = 1f;
        Debug.Log("버튼 클릭됨! → 로비로 이동");
        GameManager.Instance.ChangeState(GameState.Lobby);
    }
   
}
