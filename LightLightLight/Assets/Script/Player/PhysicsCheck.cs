using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public Vector2 centerOffset;//λ�Ʋ�ֵ
    public float checkRadius;
    public LayerMask groundLayer;//��ײ��
    public bool isGround;

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        //��������Ƿ��ڵ���
        isGround=Physics2D.OverlapCircle((Vector2)transform.position+centerOffset, checkRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + centerOffset, checkRadius);
    }
}
