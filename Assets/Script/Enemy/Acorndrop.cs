using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorndrop : EnemyController
{
    public GameObject acornProp;

    private void FixedUpdate()
    {
        if (acornProp)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            speed = 0.0f;
            hp = 0;

            Dead();
        }
    }
}
