using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobmelt : EnemyController
{
    Vector3 defPos;                         // ���� ��ġ
    public float reviveDelay = 0.0f;        // ��Ȱ ������

    protected override void Start()
    {
        base.Start();

        defPos = transform.position;
    }

    protected override void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dist = Vector2.Distance(transform.position, player.transform.position);   //���Ϳ� �÷��̾� �Ÿ� ���
            if (dist < reactionDistance)
            {
                animator.SetBool("revive", true);

                if (animator.GetBool("revive") == true && animator.GetBool("dead") == false)
                {
                    animator.SetBool("run", true);
                }
            }
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    private void FixedUpdate()
    {
        if (direction1 == "right")
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y);
            if (direction2 == "left")
            {
                animator.SetBool("turn", true);
            }
        }
        else
        {
            rbody.velocity = new Vector2(-speed, rbody.velocity.y);
            if (direction2 == "right")
            {
                animator.SetBool("turn", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Turnwall")
        {
            if (direction1 == "right")
            {
                direction1 = "left";
            }
            else if (direction1 == "left")
            {
                direction1 = "right";
            }
        }        
    }

    // ���
    public override void Dead()
    {
        animator.SetBool("dead", true);
        Invoke("SetDeadFalse", reviveDelay);    // ��Ȱ ���
    }

    // ��Ȱ ���
    public void Setdeadfalse()
    {
        animator.SetBool("dead", false);
    }

    public void move()
    {
        speed = 4.0f;
    }

    public void Stop()
    {
        speed = 0.0f;
    }
}
