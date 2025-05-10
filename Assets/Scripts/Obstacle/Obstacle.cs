using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObstacleType
{
    Overhead,      // ��� ��ֹ� (�����̵����� ���ϱ�)
    Ground,        // �ϴ� ��ֹ� (�����ؼ� ���ϱ�)
    FallHole,      // �������� ���� ��ֹ� (�����ؼ� ���ϱ�)

}

namespace runner
{
    public class Obstacle : MonoBehaviour
    {
        [Header("��ֹ� ����")]
        public ObstacleType obstacleType;


        [Tooltip("��ֹ� �� ���� ����")]
        [SerializeField] private float minSpacing = 2f; //��ֹ� �ּ� ����
        [SerializeField] private float maxSpacing = 10f; //��ֹ� �ִ� ����

        [Header("���� ��ġ ����")]
        [SerializeField] private Vector3[] fixedPositions;

        [Header("�ǰ� ���� ����")]
        [SerializeField] private float damage = 10f;

        [SerializeField] private int spawnIndex = 0; //��ֹ� ������ġ �ε���

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

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                //Player player = other.GetComponent<Player>();
                //if (player != null)
                //{
                //        player.OnHit(damage); //�÷��̾�� ������

                //    //�÷��̾ ��ġ ������ ��� ���̸� ��ֹ� �ı�
                //    if (player.hasHammer)
                //    {
                //        Destroy(gameObject); //��ֹ� �ı�
                //        return;
                //    }
                //}
            }
        }


        public void SetSpawnIndex(int index)
        {
            spawnIndex = index;
        }

    }
}
