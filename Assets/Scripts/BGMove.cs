using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    Material mat;
    public float backGroundSpeed;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;      // shareMaterial ��֤���������鱳�����ƶ��Ǻ�Quad���ƶ���ȫһ�µģ�������ִ���
    }

    void Update()
    {
        mat.mainTextureOffset += new Vector2(0, backGroundSpeed * Time.deltaTime); // ������2D��Ϸ����ֻ��ҪVector2
    }
}
