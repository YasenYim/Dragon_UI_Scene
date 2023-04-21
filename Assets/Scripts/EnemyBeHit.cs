using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeHit : MonoBehaviour
{
    SpriteRenderer[] renders;

    public float redTime = 0.1f;     // ���ֺ�ɫ��ʱ�䣬�ɵ�
    float changeColorTime;    // ��ذ�ɫ��ʱ��

    public float enemyHp = 10;
    public Transform prefabBoom;    // ��ը����

    void Start()
    {
        renders = GetComponentsInChildren<SpriteRenderer>();
    }

    // �������
    void Update()
    {
        if(Time.time >= changeColorTime)
        {
            SetColor(Color.white);
        }
    }

    // ���˱�����ʱ���ĺ���
    void SetColor(Color c)
    {
        // ���renders�ĵ�һ����ɫ�͵��������ڵ���ɫ�˾�return���ٸı���
        if(renders[0].color == c)
        {
            return;
        }

        foreach (var unknown in renders)
        {
            unknown.color = c;
        }
    }
    // �����˱��ӵ����е�ʱ��ֻ��PlayerBullet���Դ��е��ˣ��������е�ʱ��ͻ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetColor(Color.red);
        changeColorTime = Time.time + redTime;  // ��ɰ�ɫ��ʱ��Ӧ���ǵ�ǰ��ʱ����ϱ��ֺ�ɫʱ���һ��ʱ��

        enemyHp -= 1;
        if(enemyHp <= 0)
        {
            // ����
            Destroy(gameObject);

            // ���ű�ը��Ч
            Instantiate(prefabBoom,transform.position,Quaternion.identity);
        }
    }
}
