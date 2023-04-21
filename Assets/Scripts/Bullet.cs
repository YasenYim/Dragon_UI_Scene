using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ����ӵ�����ײ���������ͨ��unityϵͳ�Դ�������ϵͳ����ˣ����layer�㣬��Project Settings�����Physics 2D�����Layer Collision Matrix��ѡ��Ҫ��ײ�Ĳ��֣�ȡ������Ҫ������ײ�Ĳ���

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6;
    public Transform prefabExplosion;      // ��ըͼ��Ԥ����
   

    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime; // Vector3.up����˼��2d��Ϸ���ϣ����Կ���ֱ��ʹ��Vector3.up(Vector.up����˼���ǣ�0��1��0����
    }

    // �ӵ����������Ժ��Լ������Լ������������ӵ��Ժ��Լ������Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);   // �����Ժ��Լ���ʧ
        // ������ըͼ
        if(prefabExplosion) // �������ָ�����壬���������
        {
            // �ӵ���С�������
            Transform expl = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        }
    }
}
