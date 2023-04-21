using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ������Explosion��

// ����ű�ͬ��Ҳ�������ӵ���ʧ�����ó�3�����ʧ��


public class DelayDestroy : MonoBehaviour
{
    public float delayTime = 1;
    void Start()
    {
        // ����Я��
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);

        Destroy(gameObject);
    }
}
