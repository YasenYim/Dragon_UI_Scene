using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    // ����֡�¼����ٵİ취�����������һ֡��ʱ����Ե������ٵĽű�
    // Ԥ��������Ҳ�нű�������Ҫ�ǵ�override
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
