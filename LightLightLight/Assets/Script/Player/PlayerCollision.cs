using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private HealthSystem healthSystem;  // ����HealthSystem�ű�

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>(); // ��ȡHealthSystem���
    }

    // ������뾣��������ײʱ
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ����뾣������ײ
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Fly")) 
        {
            // �۳�10��Ѫ
            healthSystem.TakeDamage(10f);

            // ������˷������������ˮƽ�ᣨx�ᣩ������
            //Vector2 knockbackDirection = new Vector2(transform.position.x - collision.transform.position.x,0).normalized;

            // Debug.Log("Knockback Direction: " + knockbackDirection);  // ������˷���

            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;


            // ִ�л���
            healthSystem.Knockback(knockbackDirection);


        }
    }
}