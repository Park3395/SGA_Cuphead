using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpM : MonoBehaviour
{
    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void HP1Anim_True()
    {
        Anim.SetBool("isChange", true);
    }
    public void HP1Anim_False()
    {
        Anim.SetBool("isChange", false);
    }
}
