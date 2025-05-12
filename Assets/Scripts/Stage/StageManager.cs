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

        [Header("타일 스포너들")]
        public List<TileSpawner> tileSpawners;


        void Start()
        {
            currentStage = 0;
            ApplyStageSettings(currentStage);
        }

        void Update()
        {
            stageTimer += Time.deltaTime;

            if (stageTimer >= stageDuration)
            {
                currentStage++;
                stageTimer = 0f;

                ApplyStageSettings(currentStage);
            }
        }

        void ApplyStageSettings(int stage)
        {
            float newInterval = Mathf.Max(0.5f, 2f - 0.3f * stage);
            float newSpeed = Mathf.Min(10f, 5f + stage);

            obstacleSpawner.SetStageParameters(newInterval, newSpeed);
            TileMover.SetSpeed(newSpeed); //타일 이동 속도 static 방식

            foreach (TileSpawner spawner in tileSpawners)
            {
                if (spawner != null)
                    spawner.SetSpeed(newSpeed); //각 타일 스포너의 생성 속도
            }
        }
    }
}
