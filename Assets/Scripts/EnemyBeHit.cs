using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeHit : MonoBehaviour
{
    SpriteRenderer[] renders;

    public float redTime = 0.1f;     // 保持红色的时间，可调
    float changeColorTime;    // 变回白色的时间

    public float enemyHp = 10;
    public Transform prefabBoom;    // 爆炸动画

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

    // 敌人被攻击时变红的函数
    void SetColor(Color c)
    {
        // 如果renders的第一个颜色就等于我现在的颜色了就return不再改变了
        if(renders[0].color == c)
        {
            return;
        }

        foreach (var unknown in renders)
        {
            unknown.color = c;
        }
    }
    // 当敌人被子弹打中的时候，只有PlayerBullet可以打中敌人，当被打中的时候就会变红
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetColor(Color.red);
        changeColorTime = Time.time + redTime;  // 变成白色的时间应该是当前的时间加上保持红色时间的一个时间

        enemyHp -= 1;
        if(enemyHp <= 0)
        {
            // 死亡
            Destroy(gameObject);

            // 播放爆炸特效
            Instantiate(prefabBoom,transform.position,Quaternion.identity);
        }
    }
}
