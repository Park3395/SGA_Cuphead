using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    [SerializeField]
    private int NowHP;
    [SerializeField]
    private int MaxHP;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("!");
            this.NowHP--;
            this.GetComponent<Animator>().Play("onHit");
        }
    }

    protected virtual void runDead() { }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.NowHP == 0)
        {
            runDead();
        }
    }
}
