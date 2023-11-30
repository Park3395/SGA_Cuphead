using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : BossBase
{
    private Animator anim;

    protected override void runDead()
    {
        this.anim.Play("");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
