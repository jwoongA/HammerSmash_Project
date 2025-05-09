using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace runner
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("��ֹ� �����յ�")]
        public GameObject[] obstaclePrefabs;

        [Header("��ֹ� ���� ��ġ")]
        public Vector3[] spawnPositions;

        private int currentStage = 0; //�������� Ȯ�� �ε���

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
                //��ֹ� Ÿ���� �ڵ����� ������� �ٲ�
                ObstacleType type = (ObstacleType)(i % System.Enum.GetNames(typeof(ObstacleType)).Length);

                GameObject prefab = obstaclePrefabs[(int)type]; //��ֹ� Ÿ�Կ� �´� ������ ����
                GameObject obj = Instantiate(prefab, spawnPositions[i], Quaternion.identity); //������ ��ġ�� ��ֹ� ����

                Obstacle obstacle = obj.GetComponent<Obstacle>(); 
                if (obstacle != null)
                {
                    obstacle.obstacleType = type; //��ֹ� Ÿ�� ����
                    obstacle.SetSpawnIndex(i); //���° ��ֹ����� ����
                }
            }
        }
    }
}
