using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum GameState
{
    Start,
    Lobby,
    InGame,
    GameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    public GameObject gameOverUIPrefab; // �ν����Ϳ� ������ ���� ���� UI ������
    private GameObject currentGameOverUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
        
        

    //{
    //    if (Instance != null && Instance != this)
    //    {
    //        Debug.Log("�ߺ� GameManager �߰� �� ������");
    //        Destroy(gameObject);
    //        return;
    //    }

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //    Debug.Log("GameManager ���� + ���� ���");
    //}

    private void Start()
    {
        //ChangeState(GameState.Start);
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            ChangeState(GameState.Start);
        }
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
        string targetScene = "";

        switch (newState)
        {
            case GameState.Start:
                Debug.Log("StartScene���� �̵� ��");
                targetScene = "StartScene";
                break;
            case GameState.Lobby:
                Debug.Log("LobbyScene���� �̵� ��");
                targetScene = "LobbyScene";
                break;
            case GameState.InGame:
                Debug.Log("Loding1_Scene���� �̵� ��");
                targetScene = "Loding1_Scene"; // ���� Stage1_Scene �� ����
                break;
            case GameState.GameOver:
                Debug.Log("GameOverScene���� �̵� ��");
                targetScene = "GameOverScene";
                break;
        }
        Debug.Log($"{newState} �� {targetScene} �� �̵� ��");
        SceneManager.LoadScene(targetScene);
        //Stage1_Scene
    }

    public void GameOver()
    {
        Debug.Log("���� ����!");
        Time.timeScale = 0f; // ���� ����
        if (gameOverUIPrefab != null && currentGameOverUI == null)
        {
            currentGameOverUI = Instantiate(gameOverUIPrefab);
        }
        // ��: ���� ���� �ٽ� �ε� (��Ʈ����)
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }
}
