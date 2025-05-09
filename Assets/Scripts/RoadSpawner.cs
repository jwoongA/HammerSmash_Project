using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject tilePrefab;       // 생성할 길 프리팹
    public Transform spawnPoint;        // 길을 생성할 위치
    public float spawnInterval = 2f;    // 생성 간격(초)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnTile();
            timer = 0f;
        }
    }

    void SpawnTile()
    {
        // 프리팹 생성
        GameObject newTile = Instantiate(tilePrefab, spawnPoint.position, Quaternion.identity);

        // 프리팹의 가로 길이 구하기
        float tileWidth = GetTileWidth(newTile);

        // spawnPoint 위치를 프리팹의 길이만큼 오른쪽으로 이동
        spawnPoint.position += new Vector3(tileWidth, 0f, 0f);
    }

    float GetTileWidth(GameObject tile)
    {
        // Renderer로 가로 길이 계산 (프리팹에 SpriteRenderer나 MeshRenderer 있어야 함)
        Renderer renderer = tile.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size.x;
        }

        // 없으면 기본값
        return 10f; // 길 프리팹의 예상 가로 길이로 대체
    }
}