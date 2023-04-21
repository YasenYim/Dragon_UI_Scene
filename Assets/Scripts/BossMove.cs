using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    // ö��״̬����������֮��
    enum State
    {
        Down,
        LeftRight,
    }

    
    State state = State.Down;  // Ĭ��״̬�����·���
    public float minY = 2.8f;
    public float minX = -2.3f;
    public float maxX = 2.3f;
    public float downSpeed = 3f;
    public float leftRightSpeed = 3f;

    

    // ÿһ֡��������״̬�����л�
    void Update()
    {
        switch(state)
        {
            case State.Down:
                {
                    transform.position += Vector3.down * downSpeed * Time.deltaTime;
                    if(transform.position.y <= minY)
                    {
                        state = State.LeftRight;   // ����״̬�л�Ϊ����״̬
                    }
                }
                break;
            case State.LeftRight:
                {
                    transform.position += Vector3.left * leftRightSpeed * Time.deltaTime;

                    // ��֤�ڱ�Ե���򲻻���ֹ���
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
