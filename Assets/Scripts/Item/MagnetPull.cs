using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPull : MonoBehaviour
{
    private Transform player;

    [Header("자석 효과 설정")]
    [SerializeField] private float magentSpeed = 8f;
    [SerializeField] private float magentRange = 7f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        PlayerEffect effect = player.GetComponent<PlayerEffect>();
        if (effect != null && effect.isMagnetActive)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= magentRange)
            {
                // 플레이어 방향으로 이동
                transform.position = Vector3.MoveTowards(transform.position, player.position, magentSpeed * Time.deltaTime);
            }
        }
    }
}
