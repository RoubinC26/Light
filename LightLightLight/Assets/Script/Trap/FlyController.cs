using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public GameObject flyTrapPrefab;  // 飞行物的预设对象
    public float Interval;     // 生成的时间间隔
    public float RangeX;      // 飞行物随机生成的X轴范围
    public float RangeYLow;    // 飞行物随机生成的Y轴最低高度
    public float RangeYHigh;  // 飞行物随机生成的Y轴最高高度
    public int maxTraps;             // 同时场景中最大飞行物数量

    private float timer;                 // 计时器，用于控制生成频率
    private int currentTrapCount;    // 当前场景中的飞行物数量

    void Update()
    {
        // 每隔一定时间生成一个飞行物
        timer += Time.deltaTime;
        if (timer >= Interval && currentTrapCount < maxTraps)
        {
            SpawnFlyingTrap();
            timer = 0f;  // 重置计时器
        }
    }

    void SpawnFlyingTrap()
    {
        // 随机选择飞行物的生成位置
        float produceX = Random.Range(-RangeX, RangeX);
        float produceY = Random.Range(RangeYLow, RangeYHigh);
        Vector2 producePosition = new Vector2(produceX, produceY);

        // 在指定位置生成飞行物
        GameObject newTrap = Instantiate(flyTrapPrefab, producePosition, Quaternion.identity);
        currentTrapCount++;

        Destroy(newTrap, 30f);  // 飞行物存在30秒后销毁
    }

    // 在飞行物销毁时减少当前生成的飞行物数量
    public void DecreaseTrapCount()
    {
        currentTrapCount--;
    }
}
