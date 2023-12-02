using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorndrop : EnemyController
{
    public GameObject acornProp;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (RngManager.GameIsPaused)
        {
            Vector2 nowPos= transform.position;
            transform.position= nowPos;
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            acornProp.transform.Translate(Vector3.up * speed * 1.5f * Time.deltaTime);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Dead();
        }
    }
}
