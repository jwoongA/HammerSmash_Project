using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearUI : BaseUI
{
    
    public Button lobbyButton;
    protected override UIState GetUIState()
    {
        return UIState.Stage1ClearUI;
    }
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (lobbyButton != null)
        {
           // nextButton.onClick.AddListener(OnNextButtonClicked);
            lobbyButton.onClick.AddListener(OnLobbyButtonClicked);
        }
        else
        {
            Debug.LogWarning("Start Button이 연결되지 않았습니다.");
        }

    }
    //public void OnNextButtonClicked()
    //{
    //    Debug.Log("버튼 클릭됨! → 다음 스테이지로");
    //    Time.timeScale = 1f;
    //    GameManager.Instance.ChangeState(GameState.Stage1Clear);
    //}

    public void OnLobbyButtonClicked()
    {
        Debug.Log("버튼 클릭됨! 로비로");
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager 인스턴스가 존재하지 않습니다!");
        }
        else
        {
            Time.timeScale = 1f;
            GameManager.Instance.ChangeState(GameState.Lobby);
        }
    }

}
