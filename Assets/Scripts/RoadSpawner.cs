using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject tilePrefab;       
    public Transform spawnPoint;


    [Header("스폰 간격 조절")]
    public float initialSpawnInterval = 3f;    // 초기 간격
    public float minSpawnInterval = 2f;        // 최소 간격
    public float intervalDecreaseDuration = 30f; // 몇 초 동안 간격을 줄일지

    private float currentSpawnInterval;
    private float timer = 0f;
    private float elapsedTime = 0f;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timer += Time.deltaTime;

       
        float t = Mathf.Clamp01(elapsedTime / intervalDecreaseDuration);
        currentSpawnInterval = Mathf.Lerp(initialSpawnInterval, minSpawnInterval, t);

        if (timer >= currentSpawnInterval)
        {
            SpawnTile();
            timer = 0f;
        }
    }


    void SpawnTile()
    {
        GameObject newTile = Instantiate(tilePrefab, spawnPoint.position, Quaternion.identity);

        float tileWidth = GetTileWidth(newTile);

        Destroy(newTile, 30f);

        spawnPoint.position += new Vector3(tileWidth, 0f, 0f);
    }

    float GetTileWidth(GameObject tile)
    {
       
        Renderer renderer = tile.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size.x;
        }

        return 30f; 
    }
}