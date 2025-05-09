using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObstacleType
{
    Overhead,      // ��� ��ֹ� (�����̵����� ���ϱ�)
    Ground,        // �ϴ� ��ֹ� (�����ؼ� ���ϱ�)
    FallHole,      // �������� ���� ��ֹ� (�����ؼ� ���ϱ�)
    Destructible   // ��ġ�� �μ� �� �ִ� ��ֹ�
}

namespace runner
{
    public class Obstacle : MonoBehaviour
    {
        [Header("��ֹ� ����")]
        public ObstacleType obstacleType;

        [Header("��ֹ� �Ӽ� ����")]
        [SerializeField] private float minHeight = 1f; //��ֹ� �ּ� ����
        [SerializeField] private float maxHeight = 3f; //��ֹ� �ִ� ����
        [SerializeField] private float minWidth = 1f; //��ֹ� �ּ� �ʺ�
        [SerializeField] private float maxWidth = 3f; //��ֹ� �ִ� �ʺ�

        [Tooltip("��ֹ� �� ���� ����")]
        [SerializeField] private float minSpacing = 2f; //��ֹ� �ּ� ����
        [SerializeField] private float maxSpacing = 10f; //��ֹ� �ִ� ����

        [Header("���� ��ġ ����")]
        [SerializeField] private Vector3[] fixedPositions;

        [Header("�ǰ� ���� ����")]
        [SerializeField] private float damage = 10f;

        private int spawnIndex = 0; //��ֹ� ������ġ �ε���

        void Start()
        {
            //������ �� ��ֹ� ��ġ�� ũ�⸦ ����
            SetupObstacleShape();
        }

        void Update()
        {
            //��ֹ� �̵� �ӵ� (�÷��̾�� �ٰ����� ����)
            transform.Translate(Vector3.left * Time.deltaTime * 5f);

            //ȭ�� ������ ������ ����
            if (transform.position.x < -20f)
                Destroy(gameObject);
        }

        private void SetupObstacleShape()
        {
            // ���� ��ġ���� ���� ��ֹ��� ��ġ�� ����
            if (spawnIndex < fixedPositions.Length)
                transform.position = fixedPositions[spawnIndex];

            // ��ֹ� ������ ���� ��ġ/ũ�� �ٸ��� ����
            switch (obstacleType)
            {
                case ObstacleType.Overhead:
                    // ȭ�� ���ʿ� ������ ���̷� ��ġ
                    transform.position = new Vector3(transform.position.x, 3f, 0);
                    transform.localScale = new Vector3(1, Random.Range(minHeight, maxHeight), 1);
                    break;

                case ObstacleType.Ground:
                    // �ٴڿ� �پ� �ִ� ��ֹ�
                    transform.position = new Vector3(transform.position.x, 0f, 0);
                    transform.localScale = new Vector3(1, Random.Range(minHeight, maxHeight), 1);
                    break;

                case ObstacleType.FallHole:
                    // ���� ���� ���� (�ʺ� ����)
                    transform.position = new Vector3(transform.position.x, 0f, 0);
                    float holeWidth = Random.Range(minWidth, maxWidth);
                    transform.localScale = new Vector3(holeWidth, 1, 1);
                    break;

                case ObstacleType.Destructible:
                    // �⺻ ���̷� ��ġ, �÷��̾ �μ��� ���
                    transform.position = new Vector3(transform.position.x, 0f, 0);
                    transform.localScale = new Vector3(1, 1, 1);
                    break;
            }
        }

    }
}
