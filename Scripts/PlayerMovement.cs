﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BulletHell
{
    public class PlayerMovement : MonoBehaviour
    {
        public GameObject[] guns;
        public float speed;
        private Vector2 input;
        private Vector2 mousePos;
        //private Animator animator;
        private Rigidbody2D rigidbody;
        private int gunNum;
        float playerlife=10;
        float maxplayerlife=10;
        GameObject healthBar = null;
        void Start()
        {
            //animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
            guns[0].SetActive(true);
        }

        void Update()
        {
            SetHealthBar();
            SwitchGun();
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            rigidbody.velocity = input.normalized * speed;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

            if(playerlife<=0){
     Time.timeScale=0;
 }

            //if (input != Vector2.zero)
            //    animator.SetBool("isMoving", true);
           // else
            //    animator.SetBool("isMoving", false);
        }

        void SwitchGun()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                guns[gunNum].SetActive(false);
                if (--gunNum < 0)
                {
                    gunNum = guns.Length - 1;
                }
                guns[gunNum].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                guns[gunNum].SetActive(false);
                if (++gunNum > guns.Length - 1)
                {
                    gunNum = 0;
                }
                guns[gunNum].SetActive(true);
            }
        }
         private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.name=="Bulletr(Clone)"){
           playerlife--;
           }
           if(other.name=="rival"){
           playerlife--;
           playerlife--;
           }
          
    }
    void SetHealthBar()
{
    if (healthBar == null)
    {
        healthBar = GameObject.Find("playerblood");
    }
    healthBar.GetComponent<Image>().fillAmount = playerlife / maxplayerlife;
}


    }
}