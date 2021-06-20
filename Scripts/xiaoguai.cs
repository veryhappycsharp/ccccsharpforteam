using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class xiaoguai : MonoBehaviour
{
    public float  interval;
    public GameObject bulletPrefab;
    private Transform  shootp;
     private Transform  shellp;
     private GameObject  playerpos;
     private Vector2 direction;
     private float timer;
      private float flipY;
      float maxHealth=20;
     float health=20;
    GameObject healthBar = null;




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
         SetHealthBar();

        if (playerpos.transform.position.x<transform.position.x)
            transform.localScale=new Vector3(flipY,-flipY,1);
        else
            transform.localScale=new Vector3(flipY,flipY,1);
        attack();

        if(health<=0){
     Time.timeScale=0;
     
    
 }
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

    }
     private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.name=="Bullet(Clone)"){
           health--;
           }
           if(other.name=="Rocket(Clone)"){
           health--;
           health--;
           }
    }
   
 void SetHealthBar()
{
    if (healthBar == null)
    {
        healthBar = GameObject.Find("rivalblood");
    }
    healthBar.GetComponent<Image>().fillAmount = health / maxHealth;
}
}
