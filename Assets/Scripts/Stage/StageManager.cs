using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace runner
{
    public class StageManager : MonoBehaviour
    {
        [Header("�������� ���� ���� (��)")]
        public float stageDuration = 30f;

        private int currentStage = 0;
        private float stageTimer = 0f;

        [Header("������ ����")]
        public ObstacleSpawner obstacleSpawner;

        void Start()
        {
            // ���� ���� �� ù �������� ����
            obstacleSpawner.SpawnObstaclesForStage(currentStage);
        }

        void Update()
        {
            stageTimer += Time.deltaTime;

            if (stageTimer >= stageDuration)
            {
                currentStage++;
                stageTimer = 0f;

                // ���� �������� ��ֹ� ����
                obstacleSpawner.SpawnObstaclesForStage(currentStage);
            }
        }
    }
}