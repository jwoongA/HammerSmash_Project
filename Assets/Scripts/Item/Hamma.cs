using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamma : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.right * 1f * Time.deltaTime); // �̵��� ������ �浹�� ��� ���� �ڵ� �ǹ�x
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}
