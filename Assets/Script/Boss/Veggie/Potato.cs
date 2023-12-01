using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : BossBase
{
    private Animator anim;
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
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        idleTime += Time.deltaTime;
        Debug.Log(idleTime);
        if(NowHP == 0)
            this.anim.Play(DeadAnim);
        
        if(idleTime >= 3f)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if(shootCount < 3)
        {
            Instantiate(defaultBullet,shoot_fx.transform.position,new Quaternion());
            shoot_fx.GetComponent<Animator>().Play(EffectAnims[0]);
            this.shootCount++;

            if (NowHP / MaxHP > 0.5f)
                yield return new WaitForSeconds(2.0f);
            else
                yield return new WaitForSeconds(1.0f);
        }
        else
        {
            Instantiate (pinkBullet, shoot_fx.transform.position, new Quaternion());
            shoot_fx.GetComponent<Animator>().Play(EffectAnims[0]);
            this.shootCount = 0;
            idleTime = 0;

            yield break;
        }
    }
}
