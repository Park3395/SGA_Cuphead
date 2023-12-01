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

    private bool idle = false;
    protected float idleTime = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("!");
            this.NowHP--;
            this.GetComponent<Animator>().Play("onHit");
        }
    }

    protected void Dead()
    { 
        Destroy(this.gameObject);
    }

    protected void idling()
    {
        this.idle = true;
    }
    protected void acting()
    {
        this.idle = false;
        idleTime = 0;
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
