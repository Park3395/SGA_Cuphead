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
        // 맨 왼쪽 벽에 닿았을 때
        if (collision.gameObject.tag == "Wall")
        {
            CsCollider.isTrigger = true;    // 트리거를 true로 바꿔 벽을 통과하게 함
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

    // 점프
    public void Jump()
    {
        animator.SetBool("jumpA", true);
        Vector2 jumpPw = new Vector2(0, jump);          // 점프를 위한 벡터
        rbody.AddForce(jumpPw, ForceMode2D.Impulse);    // 순간적인 힘을 가한다.
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

    // 움직임
    public void Move()
    {
        speed = 3.0f;
    }

    // 멈춤
    public void Stop()
    {
        speed = 0.0f;
    }
}
