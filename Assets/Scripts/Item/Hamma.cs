using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamma : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.right * 1f * Time.deltaTime); // 이동이 없으면 충돌이 없어서 넣은 코드 의미x
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}
