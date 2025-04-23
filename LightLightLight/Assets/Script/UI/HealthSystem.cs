using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f; // ���Ѫ��
    public float currentHealth;    // ��ǰѪ��
    public Image healthBar;        // Ѫ��Image
    public float knockbackForce; // ������

    private Rigidbody2D rb;        // ���2D����

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        UpdateHealthBar();
    }

    // ����Ѫ��UI
    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    // ��Ѫ����
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();
    }

    // �ָ�Ѫ��
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    // ������ҵķ���
    public void Knockback(Vector2 direction)
    {
        rb.velocity = Vector2.zero;  // �����ٶȣ���ֹ����Ч��
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse); // ��ӻ�����TODO�����޷����ˣ�����Ѫ��
    }
}

