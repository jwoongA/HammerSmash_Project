using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private bool isStageScene = false;

        void Start()
        {
            // 현재 씬 이름 확인
            string sceneName = SceneManager.GetActiveScene().name;

            // 씬 이름에 "Stage"가 포함되어 있으면 활성화
            if (sceneName.Contains("Stage"))
            {
                isStageScene = true;

                currentStage = 0;
                ApplyStageSettings(currentStage);
            }
            else
            {
                isStageScene = false;
                enabled = false; // 아예 Update 중단 (성능 최적)
            }
        }
        void Update()
        {
            // 안전을 위해 다시 한 번 체크
            if (!isStageScene || obstacleSpawner == null) return;

            stageTimer += Time.deltaTime;

            if (stageTimer >= stageDuration)
            {
                currentStage++;
                stageTimer = 0f;

                if (currentStage == 1)
                {
                    ApplyStageSettings(currentStage);
                }
            }
        }
        void ApplyStageSettings(int stage)
        {
            float newInterval = Mathf.Max(0.5f, 2f - 0.3f * stage);
            float newSpeed = Mathf.Min(10f, 5f + stage);

            if (obstacleSpawner != null)
            {
                obstacleSpawner.SetStageParameters(newInterval, newSpeed);
            }
        }
    }
}
