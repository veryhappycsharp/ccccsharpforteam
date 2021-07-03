using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyPlaneController : MonoBehaviour
{
    //敌军飞船生命量
    public int Health = 100;
    //敌军飞船速度
    public float Speed = 1.0f;
    //保证飞船在上下左右移动
    public Vector3 MinMaxX = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            //Mathf.PingPong(A,B)其中A是个变化的值，B是取值所要的区间
            //随着A的变化，函数的取值再0到B之间变化，从0升到B，再从B降到0，反复循环。
            MinMaxX.x + Mathf.PingPong(Time.time * Speed, 1.0f) *
            3,
            //MinMaxX.y + Mathf.PingPong(Time.time * Speed, 2.0f) *
            //(MinMaxX.y - MinMaxX.x),
            MinMaxX.y + Mathf.PingPong(Time.time * Speed, 2.0f) *
            4,
            transform.position.z
            );
    }
    //触发器的入口
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}

