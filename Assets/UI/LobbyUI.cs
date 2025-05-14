using runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LobbyUI : BaseUI
{

    protected override UIState GetUIState()
    {
        return UIState.Lobby; // 이게 있어야 상속후에 오버라이드
    }
    public Button RunButton;
    public Button exittButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (RunButton != null)
        {
            RunButton.onClick.AddListener(OnRunButtonClicked);
            exittButton.onClick.AddListener(OnExitButtonClicked);

        }
        else
        {
            Debug.LogWarning("RUN Button이 연결되지 않았습니다.");
        }

    }
    public void OnRunButtonClicked()
    {
        Debug.Log("버튼 클릭됨! → 게임으로 이동");
        GameManager.Instance.ChangeState(GameState.InGame);
    }//GameState.InGame
    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR //각 플렛폼 마다 다른 동작으로 끄기

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
