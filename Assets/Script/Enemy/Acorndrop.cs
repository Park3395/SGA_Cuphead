using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorndrop : EnemyController
{
    public GameObject acornProp;

    Rigidbody2D Propbody;

    protected override void Start()
    {
        Propbody = acornProp.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Propbody.velocity = new Vector2(Propbody.velocity.x, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Destroy(gameObject);
        }
    }
}
