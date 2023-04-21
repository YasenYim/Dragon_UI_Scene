using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    Material mat;
    public float backGroundSpeed;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;      // shareMaterial 保证了上下两块背景的移动是和Quad的移动完全一致的，不会出现穿帮
    }

    void Update()
    {
        mat.mainTextureOffset += new Vector2(0, backGroundSpeed * Time.deltaTime); // 这里是2D游戏所以只需要Vector2
    }
}
