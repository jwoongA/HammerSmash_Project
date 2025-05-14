using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager2 : MonoBehaviour
{
    public string nextSceneName = "Stage2_Scene"; // �̵��� ��¥ ���� ��
    public float waitSeconds = 2f;

    void Start()
    {
        Debug.Log($"[ScoreUI - �ε�2] ���� �� CurrentScore: {ScoreDataBuffer.CurrentScore}");
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(nextSceneName);
    }
}
