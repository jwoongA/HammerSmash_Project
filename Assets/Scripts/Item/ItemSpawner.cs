using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public float spawnInterval = 2f;

    // 스폰 위치 설정
    public float spawnX = 10f;
    public float minY = -2f;
    public float maxY = 2f;

    // 이동 속도
    public float itemMoveSpeed = 3f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 1f, spawnInterval);
    }

    private void SpawnItem()
    {
        Vector3 spawnPos = new Vector3(spawnX, Random.Range(minY, maxY), 0f);
        GameObject item = Instantiate(GetRandomItem(), spawnPos, Quaternion.identity);
        item.AddComponent<ObstacleMover>().speed = itemMoveSpeed;
    }

    private GameObject GetRandomItem()
    {
        int index = Random.Range(0, itemPrefabs.Length);
        return itemPrefabs[index];
    }
}
