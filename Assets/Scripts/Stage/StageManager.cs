using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private bool isStageScene = false;

        void Start()
        {
            // ���� �� �̸� Ȯ��
            string sceneName = SceneManager.GetActiveScene().name;

            // �� �̸��� "Stage"�� ���ԵǾ� ������ Ȱ��ȭ
            if (sceneName.Contains("Stage"))
            {
                isStageScene = true;

                currentStage = 0;
                ApplyStageSettings(currentStage);
            }
            else
            {
                isStageScene = false;
                enabled = false; // �ƿ� Update �ߴ� (���� ����)
            }
        }
        void Update()
        {
            // ������ ���� �ٽ� �� �� üũ
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
