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

        public float gameDuration = 30f;
        private float gameTimer = 0f;

        void Start()
        {
            currentStage = 0;
            ApplyStageSettings(currentStage);
        }

        void Update()
        {
            gameTimer += Time.deltaTime;

            if (gameTimer >= gameDuration)
            {
                GameOver();
                return;
            }

            // 기존 스테이지 로직 유지
            stageTimer += Time.deltaTime;

            if (stageTimer >= stageDuration)
            {
                stageTimer = 0f;
                currentStage++;
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
        void GameOver()
        {
            Time.timeScale = 0f;
            //TODO: 게임오버 UI 띄우기, 씬 전환 등 추가 가능
        }

    }
}
