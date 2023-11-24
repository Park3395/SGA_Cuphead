using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowergrunt : EnemyController
{
    public float speed = 0.0f;  // �̵��ӵ�
    public float jump = 4.0f;   // ������

    bool onGround = false;          // ����� ���� ���� �˻�

    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rbody;    

    public string direction = "left";       // �̵� ����
    Vector3 defPos;                         // ���� ��ġ

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dx = player.transform.position.x - transform.position.x;
            if (dx < 0)
            {
                direction = "left";
            }
            else if (dx > 0)
            {
                direction = "right";
            }
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        if (direction == "right")
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y);
            if (direction == "left")
            {
                animator.SetBool("Turn", true);
            }
        }
        else
        {
            rbody.velocity = new Vector2(-speed, rbody.velocity.y);
            if (direction == "right")
            {
                animator.SetBool("Turn", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            defPos = transform.position;
            animator.SetBool("isGround", true);
            animator.SetBool("Jump", false);
            onGround = true;
        }
        
        if (collision.gameObject.tag == "Player")
        {
            HP--;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            if (onGround)
            {
                Jump();
            }
        }
    }

    public void Jump()
    {
        animator.SetBool("Jump", true);
        animator.SetBool("isGround", false);
        Vector2 jumpPw = new Vector2(0, jump);          // ������ ���� ����
        rbody.AddForce(jumpPw, ForceMode2D.Impulse);    // �������� ���� ���Ѵ�.
    }

    public void FlipX()
    {
        if(direction=="right")
        {
            spriteRenderer.flipX = true;
        }
        else if(direction=="left")
        {
            spriteRenderer.flipX = false;
        }
    }

    public void Jumpend()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("isGround", true);
    }

    public void Move()
    {
        speed = 3.0f;
    }

    public void Stop()
    {
        speed = 0.0f;
    }

    public void Dead()
    {
        if (HP <= 0)
        {

        }
    }
}
