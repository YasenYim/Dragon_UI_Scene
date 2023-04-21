using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Border不是一个脚本组件，而是一个普通的类，不是需要挂载才能用
[Serializable] 
public class Border
{
    // 定义上下左右
    public float top = 2.2f;
    public float bottom = -4.8f;
    public float left = -2.3f;
    public float right = 2.3f;
   
}
