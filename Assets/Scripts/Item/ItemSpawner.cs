using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("아이템 목록")]
    // 스폰할 아이템 설정
    public GameObject[] itemPrefabs;
    // 아이템 스폰 주기 (2초마다 1번)
    public float spawnInterval = 2f;

    [Header("장애물 레이어")]
    // 겹침 방지 설정
    public LayerMask obstacleLayer;

    [Header("장애물 스폰 위치")]
    // 스폰 위치 설정
    public float spawnX = 10f;
    public float minY = -2f;
    public float maxY = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 1f, spawnInterval);
    }

    private void SpawnItem()
    {
        Vector3 spawnPos = new Vector3(spawnX, Random.Range(minY, maxY), 0f);

        // 해당 위치에 장애물이 있는지 검사
        Collider2D[] hits = Physics2D.OverlapCircleAll(spawnPos, 0.5f, obstacleLayer);

        // 겹치면 스폰 취소
        if (hits.Length > 0)
        {
            Debug.Log("장애물과 겹쳐서 스폰 취소");
            return;
        }

        // 스폰 진행
        GameObject item = Instantiate(GetRandomItem(), spawnPos, Quaternion.identity);

        ObstacleMover mover = item.AddComponent<ObstacleMover>();
    }

    private GameObject GetRandomItem()
    {
        int index = Random.Range(0, itemPrefabs.Length);
        return itemPrefabs[index];
    }
}
