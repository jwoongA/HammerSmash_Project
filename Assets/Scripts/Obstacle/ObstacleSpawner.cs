using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace runner
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("��ֹ� �����յ� (���� �߿�)")]
        public GameObject[] obstaclePrefabs; //Overhead, Ground, Fallhole ����

        [Header("��ֹ� ���� ��ġ (���� �߿�)")]
        public Transform[] spawnPositions; //���� ��������Ʈ ����

        [Header("���� ���� & �̵� �ӵ�")]
        public float spawnInterval = 2f;
        public float obstacleSpeed = 5f;

        [Header("��ֹ� �θ� �����̳�")]
        public Transform obstacleContainer;

        private int spawnIndex = 0;

        void Start()
        {
            spawnIndex = 0;
            InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
        }

        void Update()
        {
            CleanUpObstacles();
        }

        void SpawnObstacle()
        {
            if (spawnIndex >= obstaclePrefabs.Length || spawnIndex >= spawnPositions.Length)
            {
                spawnIndex = 0; //�ݺ��� ���� �ε��� ����
            }

            GameObject prefab = obstaclePrefabs[spawnIndex];
            Transform spawnPoint = spawnPositions[spawnIndex];

            if (prefab == null || spawnPoint == null) return;

            GameObject obstacle = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            obstacle.transform.SetParent(obstacleContainer); //�����̳� ������ ��ġ

            spawnIndex++;
        }

        void CleanUpObstacles()
        {
            List<Transform> toRemove = new List<Transform>();

            foreach (Transform child in obstacleContainer)
            {
                if (child.position.x < -20f)
                {
                    toRemove.Add(child);
                }
                else
                {
                    child.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
                }
            }

            foreach (Transform obstacle in toRemove)
            {
                Destroy(obstacle.gameObject);
            }
        }

        public void SetStageParameters(float interval, float speed)
        {
            CancelInvoke(nameof(SpawnObstacle));
            spawnInterval = interval;
            obstacleSpeed = speed;
            InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
        }
    }
}
