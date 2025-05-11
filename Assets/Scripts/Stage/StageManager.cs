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
            // ��: ���������� �ö󰥼��� ������, �ּ� ���� 0.5��
            float newInterval = Mathf.Max(0.5f, 2f - 0.3f * stage);
            float newSpeed = Mathf.Min(10f, 5f + stage); // �ӵ��� �ִ� 10���� ����

            obstacleSpawner.SetStageParameters(newInterval, newSpeed);
        }
    }
}
