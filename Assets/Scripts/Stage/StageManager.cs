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

        [Header("Ÿ�� �����ʵ�")]
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
            TileMover.SetSpeed(newSpeed); //Ÿ�� �̵� �ӵ� static ���

            foreach (TileSpawner spawner in tileSpawners)
            {
                if (spawner != null)
                    spawner.SetSpeed(newSpeed); //�� Ÿ�� �������� ���� �ӵ�
            }
        }
    }
}
