using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Frog : MonoBehaviour
{  public GameObject dropMeat;
   public Rigidbody2D rb;
   public float Speed=4;
   private float leftx,rightx;
   public Transform leftpoint,rightpoint;
   private bool Faceleft=true;
   
    
    private Animator Anim;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        transform.DetachChildren();
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

    void Die(){
        Anim.SetTrigger("death");
    }
    public void JumpOn(){

       
      
     // Invoke("NewMeat",0.5f);
      Vector3 Position=rb.transform.position;
    Instantiate(dropMeat,new Vector3(Position.x+1,Position.y,Position.z),Quaternion.identity);
       Destroy(gameObject);
         
        
        
    }




}
