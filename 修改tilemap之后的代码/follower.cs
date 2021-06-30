using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class follower : MonoBehaviour
{
    public Image blood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bloodpos=Camera.main.WorldToScreenPoint(this.transform.position);
        blood.transform.position=bloodpos;
    }
}
