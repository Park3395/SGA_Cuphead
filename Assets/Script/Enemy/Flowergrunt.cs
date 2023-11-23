using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowergrunt : EnemyController
{
    public float speed = 0.0f;  // �̵��ӵ�
    public float jump = 0.0f;   // ������

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
                if (direction == "right")
                {
                    Turn();
                }
            }
            else if (dx > 0)
            {
                direction = "right";
                if (direction == "left")
                {
                    Turn();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        if (direction == "right")
        {
            rbody.velocity = new Vector2(speed, rbody.velocity.y);
        }
        else
        {
            rbody.velocity = new Vector2(-speed, rbody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            defPos = transform.position;
            animator.SetBool("isGround", true);
            animator.SetBool("Jump", false);
        }

        if (collision.gameObject.tag == "Player")
        {
            HP--;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundLine")
        {            
            animator.SetBool("isGround", true);
        }
        if (collision.gameObject.tag == "JumpLine")
        {
            Jump();
        }
    }

    public void Jump()
    {
        animator.SetBool("Jump", true);
        animator.SetBool("isGround", false);
        Vector2 jumpPw = new Vector2(0, jump);          // ������ ���� ����
        rbody.AddForce(jumpPw, ForceMode2D.Impulse);    // �������� ���� ���Ѵ�.
    }

    public void Turn()
    {
        speed = 0;
        animator.SetBool("Turn", true);        
    }

    public void FlipX()
    {
        if (spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
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
