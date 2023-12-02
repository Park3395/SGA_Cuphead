using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornFly : EnemyController
{
    public GameObject acornDrop;

    bool ismoveX = false;
    bool ismoveY = true;

    Vector3 defpos;

    protected override void Start()
    {
        base.Start();

        AcornGenManager acornGen = GetComponent<AcornGenManager>();
        defpos = acornGen.transform.position;
    }

    protected override void Update()
    {
        base.Update();

        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dx = transform.position.x - player.transform.position.x;
            if (dx <= 0.1f)
            {
                rbody.velocity = new Vector2(0, 0);
                ismoveX = false;
                if (!ismoveY && !ismoveX)
                {
                    createAcorndrop();
                    Destroy(gameObject);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (RngManager.GameIsPaused)
        {
            rbody.velocity = new Vector2(0, 0);
        }
        else
        {
            if (ismoveY && !ismoveX)
            {
                rbody.velocity = new Vector2(rbody.velocity.x, speed);

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                float dy = transform.position.y - player.transform.position.y;
                if (dy >= 3.0f)
                {
                    rbody.velocity = new Vector2(rbody.velocity.x, 0);
                    ismoveX = true;
                    ismoveY = false;
                    if (dy >= 7.0f)
                    {
                        Destroy(gameObject);
                    }
                }
            }

            if (!ismoveY && ismoveX)
            {
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
