using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using runner;


namespace runner
{

    public enum GameState
    {
        Start,
        Lobby,
        InGame,
        GameOver
    }
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameState CurrentState { get; private set; }

        public GameObject gameOverUIPrefab; // �ν����Ϳ� ������ ���� ���� UI ������
        private GameObject currentGameOverUI;

        private void Awake()
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

        private void Start()
        {
            ChangeState(GameState.Start);
        }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;

            switch (newState)
            {
                case GameState.Start:
                    Debug.Log("StartScene���� �̵� ��");
                    SceneManager.LoadScene("StartScene");
                    break;
                case GameState.Lobby:
                    Debug.Log("LobbyScene���� �̵� ��");
                    SceneManager.LoadScene("LobbyScene");
                    break;
                case GameState.InGame:
                    Debug.Log("Stage1_Scene���� �̵� ��");
                    SceneManager.LoadScene("Stage1_Scene");
                    break;
                case GameState.GameOver:
                    Debug.Log("GameOverScene���� �̵� ��");
                    SceneManager.LoadScene("GameOverScene");
                    break;
            }
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
}
