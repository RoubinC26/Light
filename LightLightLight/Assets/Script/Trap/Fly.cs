using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float highAltitude = 10f;  // 高空飞行的高度
    public float lowAltitude = 2f;    // 低空飞行的高度
    public float maxSpeed = 5f;       // 最大速度
    public float minSpeed = 1f;       // 最小速度
    public Transform endpoint;        // 终点位置
    public bool isHighAltitude = true; // 是否为高空飞行模式

    private Vector2 targetPosition;   // 飞行物目标位置
    private float speed;              // 当前飞行速度
    private FlyController controller;

    void Start()
    {
        // 获取飞行物生成器引用
        controller = FindObjectOfType<FlyController>();

        // 随机选择飞行模式
        isHighAltitude = Random.Range(0, 2) == 0;
        targetPosition = endpoint.position;

        // 随机选择飞行物的初始位置
        float xPos = Random.Range(-40f, 40f);  // 假设飞行物出现的横坐标范围
        float yPos = isHighAltitude ? highAltitude : lowAltitude;  // 根据模式设定飞行高度
        transform.position = new Vector2(xPos, yPos);
    }

    void Update()
    {
        // 根据与终点的距离调整飞行速度
        float distanceToEndpoint = Vector2.Distance(transform.position, targetPosition);
        speed = Mathf.Lerp(minSpeed, maxSpeed, distanceToEndpoint / 20f); // 可以根据需求调整20f这个值

        // 飞行物朝目标位置飞行
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查是否与玩家碰撞
        if (collision.gameObject.CompareTag("Player"))
        {
            // 获取玩家的刚体组件进行击退
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // 击退玩家
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * 30f, ForceMode2D.Impulse); // 可以调整击退力度

                // 扣除玩家血量
                HealthSystem playerHealth = collision.gameObject.GetComponent<HealthSystem>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(10f); // 扣除10滴血
                }
            }

            // 销毁飞行物，并通知生成器减少计数
            if (controller != null)
            {
                controller.DecreaseTrapCount();
            }
            Destroy(gameObject);
        }
    }
}
