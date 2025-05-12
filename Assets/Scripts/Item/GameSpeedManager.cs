using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    public static GameSpeedManager Instance;

    public float elapsedTime = 0f;
    public float maxTime = 30f; // 최대 속도 도달 시간
    public float baseSpeed = 5f;
    public float targetSpeed = 10f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public float GetCurrentSpeed()
    {
        float t = Mathf.Clamp01(elapsedTime / maxTime);
        return Mathf.Lerp(baseSpeed, targetSpeed, t);
    }

    public void ResetSpeed()
    {
        elapsedTime = 0f;
    }
}
