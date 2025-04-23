using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    // �ƹ����
    private Light2D light2D;

    // �ƹ�����������Χ��ʣ��ʱ��
    public float maxLightRange = 10f; // ���������Χ
    public float maxTime = 180f; // �������ʱ�䣨3���ӣ�

    public  float currentTime; // ��ǰʣ��ʱ��
    public  float currentRange; // ��ǰ������Χ

    void Start()
    {
        // ��ȡLight2D���
        light2D = GetComponent<Light2D>();

        // ��ʼ��ʣ��ʱ��
        currentTime = maxTime;
        currentRange = maxLightRange;
    }

    void Update()
    {
        // ʣ��ʱ��ݼ�
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            // ����ʣ��ʱ����㵱ǰ������Χ
            currentRange = Mathf.Lerp(0, maxLightRange, currentTime / maxTime);

            // ����Light2D��������Χ
            light2D.pointLightOuterRadius = currentRange;
        }
        else
        {
            // ȷ��������ΧΪ0
            light2D.pointLightOuterRadius = 0;
        }
    }

    // ���ô˷���������ʣ��ʱ��
    public void ResetLightTime()
    {
        currentTime = maxTime;
    }
}