using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    public GameObject dropMeat;
   private Rigidbody2D rb;
   private float Speed=3;
   private float upy,downy,leftx,rightx;
   public Transform uppoint,downpoint,leftpoint,rightpoint;
   private bool Faceup=true;
    private bool Faceleft=true;
    void Start()
    {
         rb=GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        upy=uppoint.position.y;
        downy=downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
         leftx=leftpoint.position.x;
        rightx=rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
         Move();
    }

    void Move(){
            if(Faceup){
                rb.velocity=new Vector2(rb.velocity.x,Speed);
                if(transform.position.y>upy){
                    
                    Faceup=false;
                }
            }else{
                rb.velocity=new Vector2(rb.velocity.x,-Speed);
                if(transform.position.y<downy){
            
                    Faceup=true;
                }
            }

             if(Faceleft){
                rb.velocity=new Vector2(-Speed,rb.velocity.y);
                if(transform.position.x<leftx){
                    transform.localScale=new Vector3(-1,1,1);
                    Faceleft=false;
                }
            }else{
                rb.velocity=new Vector2(Speed,rb.velocity.y);
                if(transform.position.x>rightx){
                    transform.localScale=new Vector3(1,1,1);
                    Faceleft=true;
                }
            }
    }
    public void JumpOn(){

       Vector3 Position=rb.transform.position;

       Instantiate(dropMeat,new Vector3(Position.x+1,Position.y,Position.z),Quaternion.identity);
        Destroy(gameObject);
        
        
    }
}
