using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCha : MonoBehaviour
{
    SpriteRenderer[] renders;
    public Transform prefabBullet;
    public float dragonSpeed = 3;
    public float dragonHp = 5;
    public float redTime = 0.1f;         // ���ֺ�ɫ��ʱ��
    float changeColorTime;               // ��ذ�ɫ��ʱ��
    public float playerHp = 10;          // ���Ѫ��
    public Transform prefabBoom;         // ��ը����
    public float fireCD = 0.2f;          // CD��ָ�ӵ�����ȴʱ�䣬CD��ȫ����Cool Down����CD����˼���ǲ���Ҫ��ȴ����cf��CDָ���ǻ��ӵ���ʱ�䣬��CDָ���ӵ�����Ҫʱ��  // �����0.2��˼��һ���ӿ������5���ӵ�
    float lastFireTime;
    public Border moveBorder;            // �ƶ��ı߽緶Χ

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

    // ��ɫ�ƶ�����
    public void Move(Vector3 input)
    {
        Vector3 pos = transform.position + input * dragonSpeed * Time.deltaTime;

        // Clamp:�޶���Χ
        pos.x = Mathf.Clamp(pos.x,moveBorder.left,moveBorder.right);
        pos.y = Mathf.Clamp(pos.y, moveBorder.bottom, moveBorder.top);


        transform.position = pos;
    }

    // ��������
    public void Fire()
    {
        // �����ǰ��ʱ�仹û�е���һ�η����ʱ������ӵ���ȴ��ʱ����ô�Ͳ������ȥreturn
        // �����ӵ������Ƶ�ʣ�֮���Բ���Invoke����Ϊ���Ĺ�����򵥵ķ�ʽ�Ƕ�ʱ��ļӼ���
        if(Time.time < lastFireTime + fireCD)
        {
            return;
        }

        Vector3 pos = transform.position + new Vector3(0, 0.8f, 0); // ����ҵ�ǰ�����
        Transform bullet = Instantiate(prefabBullet,pos,Quaternion.identity);   // �����ӵ�
        lastFireTime = Time.time;     // �ɹ����һ���ӵ��Ժ󣬵�ǰ��ʱ�������һ���ӵ������ʱ�䣨���������2023��1��29�Ų���ͨ��
    }

    // ��ײ��ɫ����
    void SetColor(Color c)
    {
        if(renders[0].color == c)
        {
            return;
        }

        foreach (var unknown in renders)
        {
            unknown.color = c;
        }
    }

    // ��ɫ��ײ�Ժ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��ײ�Ժ�����Ϊ��ɫ
        SetColor(Color.red);
        changeColorTime = Time.time + redTime;  // ��ɰ�ɫ��ʱ��Ӧ���ǵ�ǰ��ʱ����ϱ��ֺ�ɫʱ���һ��ʱ��

        playerHp -= 1;
        if(playerHp <= 0)
        {
            // ����
            Destroy(gameObject);

            // ���ű�ը��Ч
            Instantiate(prefabBoom, transform.position, Quaternion.identity);

            // ��ɫ����
            Debug.Log("��ɫ����");

            // ������������
            SceneManager.LoadScene("Dead");
        }

    }
}
