using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1 : MonoBehaviour
{
    float health=10;
    GameObject r =null;
    GameObject a =null;
    GameObject b =null;
    GameObject c =null;
    GameObject d =null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0){
      r = GameObject.Find("wall_3");
      a = GameObject.Find("xiaoguai (3)");
      b = GameObject.Find("xiaoguai (4)");
      c = GameObject.Find("xiaoguai (5)");
      d = GameObject.Find("xiaoguai (6)");
      r.SetActive(false);
      a.SetActive(false);
      b.SetActive(false);
      c.SetActive(false);
      d.SetActive(false);

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
}
