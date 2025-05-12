using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [Header("생성할 프리팹")]
    public GameObject tilePrefab;

    [Header("생성 주기")]
    public float spawnInterval = 10f;

    [Header("타일 삭제 거리")]
    public float destroyX = -25f;

    private float timer = 0f;
    private Vector3 nextSpawnPos;

    void Start()
    {

        SpriteRenderer renderer = tilePrefab.GetComponent<SpriteRenderer>();
        float tileWidth = 8.9f;
        spawnInterval = tileWidth / 5f; 

        float tileSpeed = 5f;
        float desiredSpawnDistance = 30f;
        spawnInterval = tileWidth / tileSpeed;
        nextSpawnPos = transform.position;


    }

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
        GameObject tile = Instantiate(tilePrefab, nextSpawnPos, Quaternion.identity);

        float tileWidth = GetTileWidth(tile);


        nextSpawnPos += new Vector3(8.9f, 0f, 0f);

    }


    float GetTileWidth(GameObject obj)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        if (renderer != null)
            return renderer.bounds.size.x;

        return 2.048f; //기본값
    }

    public void SetSpeed(float tileSpeed)
    {
        float tileWidth = GetTileWidth(tilePrefab);
        spawnInterval = tileWidth / tileSpeed;
    }

}