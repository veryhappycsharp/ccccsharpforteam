using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{

    public static int CurrentMeatNum;
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 void OnTriggerEnter2D(Collider2D other) {
     
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D"){
            CurrentMeatNum+=1;
            Destroy(gameObject);
        }
    }
}
