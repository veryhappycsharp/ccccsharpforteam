using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiaoguai : MonoBehaviour
{
    public float  interval;
    public GameObject bulletPrefab;
    public GameObject shellPrefab;
    private Transform  shootp;
     private Transform  shellp;
     private GameObject  playerpos;
     private Vector2 direction;
     private float timer;
      private float flipY;




    // Start is called before the first frame update
    void Start()
    {
        shootp=transform.Find("shootp");
        shellp=transform.Find("shellp");
        playerpos=GameObject.Find("Player");
         flipY=transform.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {

        if (playerpos.transform.position.x<transform.position.x)
            transform.localScale=new Vector3(flipY,-flipY,1);
        else
            transform.localScale=new Vector3(flipY,flipY,1);
        attack();
    }
    void attack(){
        direction=(new Vector2(playerpos.transform.position.x,playerpos.transform.position.y)-new Vector2(transform.position.x,transform.position.y)).normalized;
        transform.right=direction;
         if(timer!=0){
            timer-=Time.deltaTime;
            if(timer<=0){
                timer=0;
            }
        }
         if(timer==0){
                Firer();
                timer=interval;
            }

    }

    void Firer(){
        GameObject bullet=Instantiate(bulletPrefab,shootp.position,Quaternion.identity);
        bullet.GetComponent<Bullet>().SetSpeed(direction);

        float angle= Random.Range(-5f,5f);
        Instantiate(shellPrefab,shellp.position,shellp.rotation);
        
    }
}
