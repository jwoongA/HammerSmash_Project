using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsspwan : MonoBehaviour
{
 
        public GameObject[] obstaclePrefabs;
        public Transform[] obstacleSpawnPoints;
        public float obstacleSpawnChance = 0.6f;

    void Start()
        {
            InvokeRepeating("SpawnObstacle", 1f, obstacleSpawnChance);
        }

        void SpawnObstacle()
        {
            int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
            int pointIndex = Random.Range(0, obstacleSpawnPoints.Length);

            Instantiate(
                obstaclePrefabs[prefabIndex],
                obstacleSpawnPoints[pointIndex].position,
                Quaternion.identity
            );
        }
}
