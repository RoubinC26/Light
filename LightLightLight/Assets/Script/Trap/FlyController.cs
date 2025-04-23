using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public GameObject flyTrapPrefab;  // �������Ԥ�����
    public float Interval;     // ���ɵ�ʱ����
    public float RangeX;      // ������������ɵ�X�᷶Χ
    public float RangeYLow;    // ������������ɵ�Y����͸߶�
    public float RangeYHigh;  // ������������ɵ�Y����߸߶�
    public int maxTraps;             // ͬʱ������������������

    private float timer;                 // ��ʱ�������ڿ�������Ƶ��
    private int currentTrapCount;    // ��ǰ�����еķ���������

    void Update()
    {
        // ÿ��һ��ʱ������һ��������
        timer += Time.deltaTime;
        if (timer >= Interval && currentTrapCount < maxTraps)
        {
            SpawnFlyingTrap();
            timer = 0f;  // ���ü�ʱ��
        }
    }

    void SpawnFlyingTrap()
    {
        // ���ѡ������������λ��
        float produceX = Random.Range(-RangeX, RangeX);
        float produceY = Random.Range(RangeYLow, RangeYHigh);
        Vector2 producePosition = new Vector2(produceX, produceY);

        // ��ָ��λ�����ɷ�����
        GameObject newTrap = Instantiate(flyTrapPrefab, producePosition, Quaternion.identity);
        currentTrapCount++;

        Destroy(newTrap, 30f);  // ���������30�������
    }

    // �ڷ���������ʱ���ٵ�ǰ���ɵķ���������
    public void DecreaseTrapCount()
    {
        currentTrapCount--;
    }
}
