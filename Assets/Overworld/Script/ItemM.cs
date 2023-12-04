using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemM : MonoBehaviour

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
        Item_anim.SetBool("isChange", true);
        //transform.position = new Vector3(transform.position.x, transform.position.y+1.5f, transform.position.z);
    }
    public void Item_UnSellect()
    {
        Item_anim.SetBool("isChange", false);
        //transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
    }
}

