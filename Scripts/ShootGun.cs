using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public GameObject beamPerfab;
    private float timer;
      public float  interval;
      
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       // Invoke("Fire",0.5f);
         
       //Fire();
       attack();
       
    }
    void attack(){
        
         if(timer!=0){
            timer-=1;
            if(timer<=0){
                timer=0;
            }
        }
         if(timer==0){
                Fire();
                timer=interval;
            }

    }

    void Fire(){

        Instantiate(beamPerfab,transform.position,Quaternion.identity);
       

    }
    
   
 
}


