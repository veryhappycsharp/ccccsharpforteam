using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float speed;
    // 对player的伤害值
    public int damage;
    public float destroyDis;
    private Rigidbody2D rb;
    //发射位置
    private Vector3 startPos;
    public int direction;
    public int flag;
    void Start()
    {
       
        rb=GetComponent<Rigidbody2D>();
        if(flag==0){
         rb.velocity=new Vector2(direction*speed,rb.velocity.y);}
         else if(flag==1){
             rb.velocity=new Vector2(rb.velocity.x,direction*speed);
         }
        startPos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance=(transform.position-startPos).sqrMagnitude;
        if(distance>destroyDis){
            Destroy(gameObject);
        }
        
    }
}
