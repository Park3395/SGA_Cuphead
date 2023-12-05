using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearControl : BulletBase
{
    private int num;

    // Start is called before the first frame update

    void Start()
    {
        num = Random.Range(0, 5);
        this.GetComponent<Animator>().SetInteger("type", num);
        num = Random.Range(0, 3);
        this.GetComponent<Animator>().SetInteger("endtype", num);
    }
}
