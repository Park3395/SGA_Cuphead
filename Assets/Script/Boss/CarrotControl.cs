using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotControl : BulletBase
{
    private int num;
    [SerializeField]
    float MaxHP;
    [SerializeField]
    float NowHP;

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0, 2);
        this.GetComponent<Animator>().SetInteger("endtype", num);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            this.NowHP--;
            this.GetComponent<Animator>().Play("onHit");
        }
    }

    private void Update()
    {
        if(this.NowHP>0)
            base.Update();
        if (this.NowHP <= 0)
        {
            this.GetComponent<Animator>().SetBool("isDead",true);
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
