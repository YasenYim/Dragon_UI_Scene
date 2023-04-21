using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    // 动画帧事件销毁的办法，当到达最后一帧的时候可以调用销毁的脚本
    // 预制体里面也有脚本，但是要记得override
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
