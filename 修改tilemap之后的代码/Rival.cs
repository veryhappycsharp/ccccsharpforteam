using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class Rival : MonoBehaviour
 {
     
     float vel_x, vel_y;//速度
     /// <summary>
     /// 最大、最小飞行界限
     /// </summary>
     float maxPos_x = 9;
     float maxPos_y = 6;
     float minPos_x = -9;
     float minPos_y = -4;   
     float maxHealth=20;
     float health=20;
    GameObject rhealthBar = null;
    GameObject r =null;
    
     void Start()
     {
         Change();
     }
     // Update is called once per frame
     void Update()
     {
        SetHealthBar();
        transform.Translate(vel_x, vel_y, 0, Space.Self);
        
         Check();
 if(health<=0){
     Time.timeScale=0;
      r = GameObject.Find("rival");
     r.SetActive(false);
      vel_x =0f;
      vel_y = 0f;
 }
 

 
        

     }
     //对参数赋值
     void Change()
     {
         
         vel_x = Random.Range(0.01f,0.05f);
         vel_y = Random.Range(0.01f,0.05f);
       
     }
     //判断是否达到边界，达到边界则将速度改为负的
     void Check()
     {
         //如果到达预设的界限位置值，调换速度方向并让它当前的坐标位置等于这个临界边的位置值
         if (transform.localPosition.x > maxPos_x)
         {
             vel_x = -vel_x;
             transform.localPosition = new Vector3(maxPos_x, transform.localPosition.y, 0);
         }
         if (transform.localPosition.x < minPos_x)
         {
             vel_x = -vel_x;
             transform.localPosition = new Vector3(minPos_x, transform.localPosition.y, 0);
         }
         if (transform.localPosition.y > maxPos_y)
         {
             vel_y = -vel_y;
             transform.localPosition = new Vector3(transform.localPosition.x, maxPos_y, 0);
         }
         if (transform.localPosition.y < minPos_y)
         {
             vel_y = -vel_y;
             transform.localPosition = new Vector3(transform.localPosition.x, minPos_y, 0);
         }
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
    if (rhealthBar == null)
    {
        rhealthBar = GameObject.Find("Fill");
    }
    rhealthBar.GetComponent<Image>().fillAmount = health / maxHealth;
}
   
 
 
 }
