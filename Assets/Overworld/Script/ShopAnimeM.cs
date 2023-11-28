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
        transform.localPosition = new Vector3(6.0f, 100.0f, 1.0f);
        Shop_anim.SetInteger("Shop_Idle", 1);
    }
}
