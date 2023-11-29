using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ΩÃ±€≈Ê ∆–≈œ
public class ChangeLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.instance.downJump == true)
        {
            
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("ReturnLayer", 1.2f);
 
        }
       
    }
    void ReturnLayer()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    
}
