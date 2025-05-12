using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // 질주 아이템 먹었을 때 필요한 값
    public static float globalSpeedMultiplier = 1f;
    [Header("Road 속도 조절")]
    public float baseSpeed = 5f;
    public float targetSpeed = 7f;//최종 속도

    private float elapsedTime = 0f;
    public float maxTime = 60f; // 30초 동안 점점 빨라짐

    void Update()
    {
        elapsedTime += Time.deltaTime;
 
        float t = Mathf.Clamp01(elapsedTime / maxTime); 
        float currentSpeed = Mathf.Lerp(baseSpeed, targetSpeed, t);

        transform.Translate(Vector2.left * currentSpeed * globalSpeedMultiplier * Time.deltaTime);
        if (transform.position.x < -40f)
            Destroy(gameObject);
    }
}
