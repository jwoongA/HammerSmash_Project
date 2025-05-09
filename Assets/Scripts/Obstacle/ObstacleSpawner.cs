using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace runner
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("장애물 프리팹들")]
        public GameObject[] obstaclePrefabs;

        [Header("장애물 생성 위치")]
        public Vector3[] spawnPositions;

        private int currentStage = 0; //스테이지 확장 인덱스

        void Start()
        {
            InvokeRepeating("SpawnObstaclesPeriodically", 3f, 5f);
           
        }
        void SpawnObstaclesPeriodically()
        {
            SpawnObstaclesForStage(currentStage);
        }

        public void SpawnObstaclesForStage(int stageNum)
        {
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                //장애물 타입을 자동으로 순서대로 바뀜
                ObstacleType type = (ObstacleType)(i % System.Enum.GetNames(typeof(ObstacleType)).Length);

                GameObject prefab = obstaclePrefabs[(int)type]; //장애물 타입에 맞는 프리팹 선택
                GameObject obj = Instantiate(prefab, spawnPositions[i], Quaternion.identity); //지정된 위치에 장애물 생성

                Obstacle obstacle = obj.GetComponent<Obstacle>(); 
                if (obstacle != null)
                {
                    obstacle.obstacleType = type; //장애물 타입 설정
                    obstacle.SetSpawnIndex(i); //몇번째 장애물인지 설정
                }
            }
        }
    }
}
