using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    // 灯光组件
    private Light2D light2D;

    // 灯光的最大照明范围和剩余时间
    public float maxLightRange = 10f; // 最大照明范围
    public float maxTime = 180f; // 最大照明时间（3分钟）

    public  float currentTime; // 当前剩余时间
    public  float currentRange; // 当前照明范围

    void Start()
    {
        // 获取Light2D组件
        light2D = GetComponent<Light2D>();

        // 初始化剩余时间
        currentTime = maxTime;
        currentRange = maxLightRange;
    }

    void Update()
    {
        // 剩余时间递减
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            // 根据剩余时间计算当前照明范围
            currentRange = Mathf.Lerp(0, maxLightRange, currentTime / maxTime);

            // 更新Light2D的照明范围
            light2D.pointLightOuterRadius = currentRange;
        }
        else
        {
            // 确保照明范围为0
            light2D.pointLightOuterRadius = 0;
        }
    }

    // 调用此方法来重置剩余时间
    public void ResetLightTime()
    {
        currentTime = maxTime;
    }
}