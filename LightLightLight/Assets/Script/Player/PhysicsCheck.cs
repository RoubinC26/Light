using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public Vector2 centerOffset;//位移差值
    public float checkRadius;
    public LayerMask groundLayer;//碰撞层
    public bool isGround;

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        //检测人物是否在地面
        isGround=Physics2D.OverlapCircle((Vector2)transform.position+centerOffset, checkRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + centerOffset, checkRadius);
    }
}
