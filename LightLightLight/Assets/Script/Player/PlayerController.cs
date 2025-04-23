using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputControl;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;//代码变量
    public Vector2 inputDirection;//在player面板上显示输入

    public Light2D spotlight;

    [Header("基本参数")]
    public float speed;//人物移动速度
    public float jumpForce;//跳跃的力

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//获取组件
        physicsCheck = GetComponent<PhysicsCheck>();

        inputControl =new PlayerInputControl();//创建inputCpntrol的实例

        inputControl.Gameplay.Jump.started += Jump;//按下的那一刻执行Jump
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()//以固定频率进行更新
    {
        Move();
    }

    public void Move()//人物移动
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);//y轴保持原有下落速度

        int faceDir = (int)transform.localScale.x;//localScale为-1时人物翻转 

        if (inputDirection.x>0)
        {
            faceDir = 1;    
        }

        if (inputDirection.x < 0)
        {
            faceDir = -1;
        }

        //人物翻转
        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)//限制空中多次跳跃
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
