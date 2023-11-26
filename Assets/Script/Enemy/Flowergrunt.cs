using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowergrunt : EnemyController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base .Update();
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

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        // �� ���� ���� ����� ��
        if (collision.gameObject.tag == "Wall")
        {
            CsCollider.isTrigger = true;    // Ʈ���Ÿ� true�� �ٲ� ���� ����ϰ� ��
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Jump();
        }
        else if (collision.gameObject.tag == "Dead")
        {
            speed = 0.0f;
            hp = 0;

            Dead();
        }
    }

    // ����
    public void Jump()
    {
        animator.SetBool("jumpA", true);
        Vector2 jumpPw = new Vector2(0, jump);          // ������ ���� ����
        rbody.AddForce(jumpPw, ForceMode2D.Impulse);    // �������� ���� ���Ѵ�.
    }
    public void NextJumpBAni()
    {
        animator.SetBool("jumpA", false);
        animator.SetBool("jumpB", true);
    }

    public void NextJumpCAni()
    {
        animator.SetBool("jumpA", false);
        animator.SetBool("jumpB", false);
        animator.SetBool("jumpC", true);
    }
    public void Jumpend()
    {
        animator.SetBool("jumpA", false);
        animator.SetBool("jumpB", false);
        animator.SetBool("jumpC", false);
    }

    // ������
    public void Move()
    {
        speed = 3.0f;
    }

    // ����
    public void Stop()
    {
        speed = 0.0f;
    }
}
