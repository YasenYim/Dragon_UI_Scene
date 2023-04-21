using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // 获取玩家角色信息
    PlayerCha player;

    void Start()
    {
        player = GetComponent<PlayerCha>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(h, v, 0);  // 2d游戏z轴不需要

        // 去调用角色的移动函数
        player.Move(move);

        if(Input.GetButton("Fire1"))  // 如果按下鼠标左键，GetButton和GetButtonDown的区别是一个是按着一个是持续按着
        {
            player.Fire();
        }
    }
}
