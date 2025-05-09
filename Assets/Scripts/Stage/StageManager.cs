using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace runner
{
    public class StageManager : MonoBehaviour
    {
        [Header("스테이지 변경 간격 (초)")]
        public float stageDuration = 30f;

        private int currentStage = 0;
        private float stageTimer = 0f;

        [Header("스포너 연결")]
        public ObstacleSpawner obstacleSpawner;

        void Start()
        {
            // 게임 시작 시 첫 스테이지 스폰
            obstacleSpawner.SpawnObstaclesForStage(currentStage);
        }

        void Update()
        {
            stageTimer += Time.deltaTime;

            if (stageTimer >= stageDuration)
            {
                currentStage++;
                stageTimer = 0f;

                // 다음 스테이지 장애물 스폰
                obstacleSpawner.SpawnObstaclesForStage(currentStage);
            }
        }
    }
}