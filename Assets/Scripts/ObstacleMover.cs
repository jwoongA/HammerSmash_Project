using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // 질주 아이템 먹었을 때 필요한 값
    public static float globalSpeedMultiplier = 1f;
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * globalSpeedMultiplier * Time.deltaTime);
        if (transform.position.x < -20f)
            Destroy(gameObject);
    }
}
