using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 0;     // ü��
    public float speed = 0.0f;  // �̵��ӵ�
    public float jump = 0.0f;   // ������
    public float reactionDistance = 0.0f;   // �ν� �Ÿ�

    protected string direction1 = "left";      // �̵� ����
    protected string direction2 = "left";      // �ٶ󺸴� ����

    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rbody;
    protected CapsuleCollider2D CsCollider;
    protected AudioSource audiosource;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        CsCollider = GetComponent<CapsuleCollider2D>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // �÷��̾� ��ġ�� ���� �̵� ���� ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dx = player.transform.position.x - transform.position.x;
            if (dx < reactionDistance)
            {
                direction1 = "left";        // �÷��̾ ���ͺ��� ���ʿ� ���� �� �������� �̵�
            }
            else if (dx > reactionDistance)
            {
                direction1 = "right";       // �÷��̾ ���ͺ��� �����ʿ� ���� �� ���������� �̵�
            }
        }
        else
        {
            direction1 = "left";
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // ����� ����� ��        
        if (collision.gameObject.tag == "Bullet")
        {
            hp--;
            if (hp <= 0)
            {
                Dead();
            }
        }
    }

    // ���
    public virtual void Dead()
    {
        Vector3 pos = transform.position;   // ���� ��ġ

        transform.position = new Vector3(pos.x, pos.y + 1, pos.z);  // �ǹ���ġ�� bottom���� �����߱⿡ y��ǥ ����

        int randomA = Random.Range(1, 4);   // ������ �ִϸ��̼��� �������� ����ϱ� ���� ����

        animator.SetInteger("explosion", randomA);  // �ִϸ��̼� ����

        CsCollider.enabled = false;     // CapsuleCollider2D ����
        rbody.simulated = false;        // rigidBody2D ����
    }

    // ��    
    public void FlipX()
    {
        if (direction1 == "right")
        {
            spriteRenderer.flipX = true;
            direction2 = "right";
            animator.SetBool("turn", false);
        }
        else if (direction1 == "left")
        {
            spriteRenderer.flipX = false;
            direction2 = "left";
            animator.SetBool("turn", false);
        }
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void collideroff()
    {
        CsCollider.enabled = false;
        rbody.simulated = false;
    }

    public void collideron()
    {
        CsCollider.enabled = true;
        rbody.simulated = true;
    }
}
