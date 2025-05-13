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

            // ���� �������� ���� ����
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
            TileMover.SetSpeed(newSpeed); //Ÿ�� �̵� �ӵ� static ���

            foreach (TileSpawner spawner in tileSpawners)
            {
                if (spawner != null)
                    spawner.SetSpeed(newSpeed); //�� Ÿ�� �������� ���� �ӵ�
            }
        }
        void GameOver()
        {
            Time.timeScale = 0f;
            //TODO: ���ӿ��� UI ����, �� ��ȯ �� �߰� ����
        }

    }
}
