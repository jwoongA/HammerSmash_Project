using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // 질주 아이템 먹었을 때 필요한 값
    public static float globalSpeedMultiplier = 1f;

    void Update()
    {
        if (GameSpeedManager.Instance == null) return;

        float currentSpeed = GameSpeedManager.Instance.GetCurrentSpeed();
        transform.Translate(Vector2.left * currentSpeed * globalSpeedMultiplier * Time.deltaTime);
        if (transform.position.x < -50f)
            Destroy(gameObject);
        
    }
}
