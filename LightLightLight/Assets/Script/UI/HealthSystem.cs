using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f; // 最大血量
    public float currentHealth;    // 当前血量
    public Image healthBar;        // 血条Image
    public float knockbackForce; // 击退力

    private Rigidbody2D rb;        // 玩家2D刚体

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        UpdateHealthBar();
    }

    // 更新血条UI
    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    // 扣血方法
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();
    }

    // 恢复血量
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    // 击退玩家的方法
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero;  // 重置速度，防止叠加效果
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse); // 添加击退力TODO：（无法击退，但扣血）
    }
}

