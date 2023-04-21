using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float downSpeed = 3;


    void Update()
    {
        transform.position += Vector3.down * downSpeed * Time.deltaTime;

        
        if(transform.position.y < -6 || transform.position.y > 600)
        {
            Destroy(gameObject);
        }
    }
}
