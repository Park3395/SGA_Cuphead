using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHigh : MonoBehaviour
{
    Animator Item_anim;
    // Start is called before the first frame update
    void Start()
    {
        Item_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
     
    public void Item_Sellect()
    {
        //Animation_Up();
        Item_anim.SetBool("OnHigh", true);
        //transform.position = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z);
    }
}
