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
    public float redTime = 0.1f;         // 保持红色的时间
    float changeColorTime;               // 变回白色的时间
    public float playerHp = 10;          // 玩家血量
    public Transform prefabBoom;         // 爆炸动画
    public float fireCD = 0.2f;          // CD是指子弹的冷却时间，CD的全称是Cool Down，无CD的意思就是不需要冷却，在cf中CD指的是换子弹的时间，无CD指换子弹不需要时间  // 这里的0.2意思是一秒钟可以射出5颗子弹
    float lastFireTime;
    public Border moveBorder;            // 移动的边界范围

    void Start()
    {
        renders = GetComponentsInChildren<SpriteRenderer>();
    }

    // 持续检测
    void Update()
    {
        if(Time.time >= changeColorTime)
        {
            SetColor(Color.white);
        }
    }

    // 角色移动函数
    public void Move(Vector3 input)
    {
        Vector3 pos = transform.position + input * dragonSpeed * Time.deltaTime;

        // Clamp:限定范围
        pos.x = Mathf.Clamp(pos.x,moveBorder.left,moveBorder.right);
        pos.y = Mathf.Clamp(pos.y, moveBorder.bottom, moveBorder.top);


        transform.position = pos;
    }

    // 攻击函数
    public void Fire()
    {
        // 如果当前的时间还没有到上一次发射的时间加上子弹冷却的时间那么就不发射出去return
        // 控制子弹的射击频率，之所以不用Invoke是因为消耗过大，最简单的方式是对时间的加减法
        if(Time.time < lastFireTime + fireCD)
        {
            return;
        }

        Vector3 pos = transform.position + new Vector3(0, 0.8f, 0); // 从玩家的前方射出
        Transform bullet = Instantiate(prefabBullet,pos,Quaternion.identity);   // 创建子弹
        lastFireTime = Time.time;     // 成功射出一颗子弹以后，当前的时间就是上一次子弹射出的时间（这个问题我2023年1月29号才想通）
    }

    // 碰撞变色函数
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

    // 角色碰撞以后
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 碰撞以后设置为红色
        SetColor(Color.red);
        changeColorTime = Time.time + redTime;  // 变成白色的时间应该是当前的时间加上保持红色时间的一个时间

        playerHp -= 1;
        if(playerHp <= 0)
        {
            // 死亡
            Destroy(gameObject);

            // 播放爆炸特效
            Instantiate(prefabBoom, transform.position, Quaternion.identity);

            // 角色死亡
            Debug.Log("角色死亡");

            // 加载死亡场景
            SceneManager.LoadScene("Dead");
        }

    }
}
