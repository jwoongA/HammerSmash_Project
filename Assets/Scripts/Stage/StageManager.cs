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
            // 예: 스테이지가 올라갈수록 빠르게, 최소 간격 0.5초
            float newInterval = Mathf.Max(0.5f, 2f - 0.3f * stage);
            float newSpeed = Mathf.Min(10f, 5f + stage); // 속도는 최대 10까지 증가

            obstacleSpawner.SetStageParameters(newInterval, newSpeed);
        }
    }
}
