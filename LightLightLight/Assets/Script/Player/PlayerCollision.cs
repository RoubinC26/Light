using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private HealthSystem healthSystem;  // 引用HealthSystem脚本

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>(); // 获取HealthSystem组件
    }

    // 当玩家与荆棘发生碰撞时
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测与荆棘的碰撞
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Fly")) 
        {
            // 扣除10点血
            healthSystem.TakeDamage(10f);

            // 计算击退方向，让玩家沿着水平轴（x轴）被击退
            //Vector2 knockbackDirection = new Vector2(transform.position.x - collision.transform.position.x,0).normalized;

            // Debug.Log("Knockback Direction: " + knockbackDirection);  // 输出击退方向

            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;


            // 执行击退
            healthSystem.Knockback(knockbackDirection);


        }
    }
}