using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcsign : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enterDialog;
     private void OnTriggerEnter2D(Collider2D other) {
         if(other.tag=="Player"){
            enterDialog.SetActive(true);
         }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"){
            enterDialog.SetActive(false);
         }
    }
}
