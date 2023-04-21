using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // ��ȡ��ҽ�ɫ��Ϣ
    PlayerCha player;

    void Start()
    {
        player = GetComponent<PlayerCha>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(h, v, 0);  // 2d��Ϸz�᲻��Ҫ

        // ȥ���ý�ɫ���ƶ�����
        player.Move(move);

        if(Input.GetButton("Fire1"))  // ���������������GetButton��GetButtonDown��������һ���ǰ���һ���ǳ�������
        {
            player.Fire();
        }
    }
}
