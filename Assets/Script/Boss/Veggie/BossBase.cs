using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    [SerializeField]
    protected int NowHP;
    [SerializeField]
    protected int MaxHP;
    [SerializeField]
    protected string DeadAnim;
    [SerializeField]
    protected string[] EffectAnims;
    [SerializeField]
    protected GameObject bossController;
    [SerializeField]
    protected GameObject explode;

    protected float idleTime = 0;
    protected float shootTime = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            this.NowHP--;
            this.GetComponent<Animator>().Play("onHit");
        }
    }
    protected void Dead()
    {
        this.gameObject.SetActive(false);
        bossController.GetComponent<BossControl>().endAnim();
    }

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
    }
}
