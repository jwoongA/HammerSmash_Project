using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject tilePrefab;       // ������ �� ������
    public Transform spawnPoint;        // ���� ������ ��ġ
    public float spawnInterval = 2f;    // ���� ����(��)

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
        // ������ ����
        GameObject newTile = Instantiate(tilePrefab, spawnPoint.position, Quaternion.identity);

        // �������� ���� ���� ���ϱ�
        float tileWidth = GetTileWidth(newTile);

        // spawnPoint ��ġ�� �������� ���̸�ŭ ���������� �̵�
        spawnPoint.position += new Vector3(tileWidth, 0f, 0f);
    }

    float GetTileWidth(GameObject tile)
    {
        // Renderer�� ���� ���� ��� (�����տ� SpriteRenderer�� MeshRenderer �־�� ��)
        Renderer renderer = tile.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size.x;
        }

        // ������ �⺻��
        return 10f; // �� �������� ���� ���� ���̷� ��ü
    }
}