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
    private PhysicsCheck physicsCheck;//�������
    public Vector2 inputDirection;//��player�������ʾ����

    public Light2D spotlight;

    [Header("��������")]
    public float speed;//�����ƶ��ٶ�
    public float jumpForce;//��Ծ����

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//��ȡ���
        physicsCheck = GetComponent<PhysicsCheck>();

        inputControl =new PlayerInputControl();//����inputCpntrol��ʵ��

        inputControl.Gameplay.Jump.started += Jump;//���µ���һ��ִ��Jump
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

    private void FixedUpdate()//�Թ̶�Ƶ�ʽ��и���
    {
        Move();
    }

    public void Move()//�����ƶ�
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);//y�ᱣ��ԭ�������ٶ�

        int faceDir = (int)transform.localScale.x;//localScaleΪ-1ʱ���﷭ת 

        if (inputDirection.x>0)
        {
            faceDir = 1;    
        }

        if (inputDirection.x < 0)
        {
            faceDir = -1;
        }

        //���﷭ת
        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)//���ƿ��ж����Ծ
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
