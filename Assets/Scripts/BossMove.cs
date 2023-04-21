using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    // 枚举状态，定义在类之内
    enum State
    {
        Down,
        LeftRight,
    }

    
    State state = State.Down;  // 默认状态是向下飞行
    public float minY = 2.8f;
    public float minX = -2.3f;
    public float maxX = 2.3f;
    public float downSpeed = 3f;
    public float leftRightSpeed = 3f;

    

    // 每一帧都在两种状态里面切换
    void Update()
    {
        switch(state)
        {
            case State.Down:
                {
                    transform.position += Vector3.down * downSpeed * Time.deltaTime;
                    if(transform.position.y <= minY)
                    {
                        state = State.LeftRight;   // 向下状态切换为左右状态
                    }
                }
                break;
            case State.LeftRight:
                {
                    transform.position += Vector3.left * leftRightSpeed * Time.deltaTime;

                    // 保证在边缘区域不会出现鬼畜
                    if(transform.position.x < minX)
                    {
                        leftRightSpeed = -Mathf.Abs(leftRightSpeed);
                    }
                    if (transform.position.x > maxX)
                    {
                        leftRightSpeed = Mathf.Abs(leftRightSpeed);
                    }
                }
                break;
        }
    }
}
