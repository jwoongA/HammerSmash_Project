using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager2 : MonoBehaviour
{
    public string nextSceneName = "Stage2_Scene"; // �̵��� ��¥ ���� ��
    public float waitSeconds = 1.5f;

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(nextSceneName);
    }
}
