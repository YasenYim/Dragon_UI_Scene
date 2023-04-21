using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 玩家子弹的碰撞问题最后是通过unity系统自带的物理系统解决了，添加layer层，在Project Settings里面的Physics 2D里面的Layer Collision Matrix勾选需要碰撞的部分，取消不需要互相碰撞的部分

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6;
    public Transform prefabExplosion;      // 爆炸图的预制体
   

    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime; // Vector3.up的意思是2d游戏朝上，所以可以直接使用Vector3.up(Vector.up的意思就是（0，1，0））
    }

    // 子弹碰到怪物以后自己处理自己，怪物碰到子弹以后自己处理自己
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);   // 碰到以后自己消失
        // 创建爆炸图
        if(prefabExplosion) // 代表变量指向物体，且物体存在
        {
            // 子弹大小可以随机
            Transform expl = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        }
    }
}
