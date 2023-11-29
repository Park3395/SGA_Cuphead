using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornFly : EnemyController
{
    public GameObject acornDrop;

    public float UpPos;

    bool isUp = false;

    Vector3 defpos;

    protected override void Start()
    {
        base.Start();

        AcornGenManager acornGen = GetComponent<AcornGenManager>();
        defpos = acornGen.transform.position;

        isUp = true;
    }

    protected override void Update()
    {
        base.Update();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dx = player.transform.position.x - transform.position.x;
            if (dx == 0.0f)
            {
                createAcorndrop();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isUp)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, UpPos);
            if (direction1 == "right")
            {
                rbody.velocity = new Vector2(speed, rbody.velocity.y);
                if (direction2 == "left")
                {
                    spriteRenderer.flipX = true;
                    direction2 = "right";
                }
            }
            else
            {
                rbody.velocity = new Vector2(-speed, rbody.velocity.y);
                if (direction2 == "right")
                {
                    spriteRenderer.flipX = false;
                    direction2 = "left";
                }
            }
            if (!isUp)
            {
                
            }
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    private void createAcorndrop()
    {
        Vector2 pos = transform.position;

        Instantiate(acornDrop, pos, Quaternion.identity);
    }
}
