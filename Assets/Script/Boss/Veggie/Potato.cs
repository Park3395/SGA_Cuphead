using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : BossBase
{
    private int shootCount = 0;

    [SerializeField]
    private GameObject defaultBullet;
    [SerializeField]
    private GameObject pinkBullet;
    [SerializeField]
    private GameObject shoot_fx;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        idleTime += Time.deltaTime;
        if (NowHP <= 0)
        {
            this.GetComponent<Animator>().Play(DeadAnim);
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            explode.SetActive(true);
        }
        else if (NowHP / MaxHP < 0.5f)
        {
            this.GetComponent<Animator>().speed = 1.5f;
            if (idleTime >= 2.0f)
            {
                shoot();
            }
        }
        else
            if (idleTime >= 3.0f)
            {
                shoot();
            }
    }
    private void initBullet()
    {
        if(shootCount < 3)
        {
            Instantiate(defaultBullet, shoot_fx.transform.position, new Quaternion());
            this.shootCount++;
        }
        else
        {
            Instantiate(pinkBullet, shoot_fx.transform.position, new Quaternion());
            this.shootCount = 0;
        }

        shoot_fx.GetComponent<Animator>().Play(EffectAnims[0]);
    }
    private void shoot()
    {
        if(shootTime == 0f)
        {
            if (shootCount < 3)
            {
                this.GetComponent<Animator>().Play("veggie_potato_shoot");
            }
            else
            {
                this.GetComponent<Animator>().Play("veggie_potato_shoot");
                idleTime = 0;
            }
        }

        shootTime += Time.deltaTime;

        if (NowHP / MaxHP > 0.5f)
        {
            if (shootTime > 2f)
                shootTime = 0f;
        }
        else
        {
            if (shootTime > 1.5f)
            {
                shootTime = 0f;
            }
        }
    }
}
