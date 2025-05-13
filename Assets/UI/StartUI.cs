using runner;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : BaseUI
{
    public Button startButton;
    public Button exittButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
            exittButton.onClick.AddListener(OnExitButtonClicked);
        }
        else
        {
            Debug.LogWarning("Start Button이 연결되지 않았습니다.");
        }

    }

    public void OnStartButtonClicked()
    {
        Debug.Log("버튼 클릭됨! → 로비로 이동");
        GameManager.Instance.ChangeState(GameState.Lobby);
    }

    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR //각 플렛폼 마다 다른 동작으로 끄기

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    protected override UIState GetUIState()
    {
        return UIState.Start;
    }
}
