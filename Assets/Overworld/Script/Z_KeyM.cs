using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_KeyM : MonoBehaviour
{
    Animator Z_anim;
    // Start is called before the first frame update
    void Start()
    {
        Z_anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame

    public void ZkeyOffTrue()
    {
        Z_anim.SetBool("Z_KeyOff", true);
    }
    public void ZkeyOffFalse()
    {
        Z_anim.SetBool("Z_KeyOff", false);
    }
}
