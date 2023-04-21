using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 挂在在Explosion上

// 这个脚本同样也适用于子弹消失（设置成3秒后消失）


public class DelayDestroy : MonoBehaviour
{
    public float delayTime = 1;
    void Start()
    {
        // 开启携程
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);

        Destroy(gameObject);
    }
}
