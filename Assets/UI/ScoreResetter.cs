using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreResetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "LobbyScene")
        {
            ScoreDataBuffer.CurrentScore = 0;
            ScoreDataBuffer.CurrentTime = 0f;
            Debug.Log("[ScoreResetter] �κ� ���� �� ������ �ð� �ʱ�ȭ �Ϸ�");
        }
    }
}
