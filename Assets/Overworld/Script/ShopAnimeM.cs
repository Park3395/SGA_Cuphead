using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimeM : MonoBehaviour
{
    Animator Shop_anim;
    // Start is called before the first frame update
    void Start()
    {
        Shop_anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void Shop_Idle()
    {
        Shop_anim.SetInteger("Shop_Idle", 1);
        transform.localPosition = new Vector3(37.0f, 256.0f, 1.0f);
    }
    public void Shop_Exit()
    {
        Shop_anim.SetBool("Shop_Exit", true);
        //transform.localPosition = new Vector3(37.0f, 256.0f, 1.0f);
    }
}
