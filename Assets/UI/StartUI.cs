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
            Debug.LogWarning("Start Button�� ������� �ʾҽ��ϴ�.");
        }

    }

    public void OnStartButtonClicked()
    {
        Debug.Log("��ư Ŭ����! �� �κ�� �̵�");
        GameManager.Instance.ChangeState(GameState.Lobby);
    }

    public void OnExitButtonClicked()
    {
#if UNITY_EDITOR //�� �÷��� ���� �ٸ� �������� ����

        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    protected override UIState GetUIState()
    {
        return UIState.Start;
    }
}
