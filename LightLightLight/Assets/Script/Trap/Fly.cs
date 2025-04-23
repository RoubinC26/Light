using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float highAltitude = 10f;  // �߿շ��еĸ߶�
    public float lowAltitude = 2f;    // �Ϳշ��еĸ߶�
    public float maxSpeed = 5f;       // ����ٶ�
    public float minSpeed = 1f;       // ��С�ٶ�
    public Transform endpoint;        // �յ�λ��
    public bool isHighAltitude = true; // �Ƿ�Ϊ�߿շ���ģʽ

    private Vector2 targetPosition;   // ������Ŀ��λ��
    private float speed;              // ��ǰ�����ٶ�
    private FlyController controller;

    void Start()
    {
        // ��ȡ����������������
        controller = FindObjectOfType<FlyController>();

        // ���ѡ�����ģʽ
        isHighAltitude = Random.Range(0, 2) == 0;
        targetPosition = endpoint.position;

        // ���ѡ�������ĳ�ʼλ��
        float xPos = Random.Range(-40f, 40f);  // �����������ֵĺ����귶Χ
        float yPos = isHighAltitude ? highAltitude : lowAltitude;  // ����ģʽ�趨���и߶�
        transform.position = new Vector2(xPos, yPos);
    }

    void Update()
    {
        // �������յ�ľ�����������ٶ�
        float distanceToEndpoint = Vector2.Distance(transform.position, targetPosition);
        speed = Mathf.Lerp(minSpeed, maxSpeed, distanceToEndpoint / 20f); // ���Ը����������20f���ֵ

        // �����ﳯĿ��λ�÷���
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ����Ƿ��������ײ
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��ȡ��ҵĸ���������л���
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // �������
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * 30f, ForceMode2D.Impulse); // ���Ե�����������

                // �۳����Ѫ��
                HealthSystem playerHealth = collision.gameObject.GetComponent<HealthSystem>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(10f); // �۳�10��Ѫ
                }
            }

            // ���ٷ������֪ͨ���������ټ���
            if (controller != null)
            {
                controller.DecreaseTrapCount();
            }
            Destroy(gameObject);
        }
    }
}
