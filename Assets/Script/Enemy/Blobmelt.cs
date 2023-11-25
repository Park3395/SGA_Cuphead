using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobmelt : EnemyController
{
    public float range = 0.0f;              // �̵� ������ ����
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
            // range���� 0�� �ƴϸ� ���� ��ġ�� ���� ���⿡�� ������ ��ų ������ �Ǵ��Ѵ�.
            if (range > 0.0f)
            {
                // ���� ��ġ���� �������� range�� �ݺ��� �� �̵��Ͽ��°�?
                if (transform.position.x < defPos.x - (range / 2))
                {
                    direction1 = "right";
                    animator.SetBool("turn", true);
                    //transform.localScale = new Vector2(-1, 1);
                }
                // �ݴ��� ���(������)�� �˻��Ѵ�.
                if (transform.position.x > defPos.x + (range / 2))
                {
                    direction1 = "left";
                    animator.SetBool("turn", true);
                    //transform.localScale = new Vector2(1, 1);
                }
            }

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
        // �������� �� ���� �ٲٱ�
        FlipX();
    }

    // ���
    public void dead()
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
