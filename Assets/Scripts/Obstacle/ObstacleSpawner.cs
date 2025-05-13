using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace runner
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("장애물 프리팹들 (순서 중요)")]
        public GameObject[] obstaclePrefabs; //Overhead, Ground, Fallhole 순서

        [Header("장애물 생성 위치 (순서 중요)")]
        public Transform[] spawnPositions; //개별 스폰포인트 연결

        [Header("이동 속도")]
        public float obstacleSpeed = 5f;

        [Header("장애물 부모 컨테이너")]
        public Transform obstacleContainer;

        private int spawnIndex = 0;
        private float currentSpawnInterval;

        void Start()
        {
            spawnIndex = 0;


            currentSpawnInterval = 1f / obstacleSpeed;
            InvokeRepeating(nameof(SpawnObstacle), 0f, currentSpawnInterval);
        }

        void Update()
        {
            CleanUpObstacles();
        }

        void SpawnObstacle()
        {
            if (spawnIndex >= obstaclePrefabs.Length || spawnIndex >= spawnPositions.Length)
            {
                spawnIndex = 0; //반복을 위한 인덱스 리셋
            }

            GameObject prefab = obstaclePrefabs[spawnIndex];
            Transform spawnPoint = spawnPositions[spawnIndex];

            if (prefab == null || spawnPoint == null) return;

            GameObject obstacle = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            obstacle.transform.SetParent(obstacleContainer); //컨테이너 하위로 배치

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
            }

            foreach (Transform obstacle in toRemove)
            {
                Destroy(obstacle.gameObject);
            }
        }

        public void SetStageParameters(float interval, float speed)
        {
            obstacleSpeed = speed;
            currentSpawnInterval = interval;
            CancelInvoke(nameof(SpawnObstacle));
            InvokeRepeating(nameof(SpawnObstacle), 0f, currentSpawnInterval);
        }
    }
}
