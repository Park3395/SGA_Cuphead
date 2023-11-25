using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 0;     // ü��
    public float speed = 0.0f;  // �̵��ӵ�
    public float jump = 0.0f;   // ������

    protected string direction1 = "left";      // �̵� ����
    protected string direction2 = "left";      // �ٶ󺸴� ����

    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rbody;
    protected CapsuleCollider2D CsCollider;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        CsCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // �÷��̾� ��ġ�� ���� �̵� ���� ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dx = player.transform.position.x - transform.position.x;
            if (dx < 0)
            {
                direction1 = "left";        // �÷��̾ ���ͺ��� ���ʿ� ���� �� �������� �̵�
            }
            else if (dx > 0)
            {
                direction1 = "right";       // �÷��̾ ���ͺ��� �����ʿ� ���� �� ���������� �̵�
            }
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // ����� ����� ��
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isGround", true);     // Run�ִϸ��̼� ����
        }
        // �÷��̾�� ����� ��
        else if (collision.gameObject.tag == "Player")
        {
            speed = 0.0f;
            hp = 0;

            Dead();
        }
        // �� ���� ���� ����� ��
        else if (collision.gameObject.tag == "Wall")
        {
            CsCollider.isTrigger = true;    // Ʈ���Ÿ� true�� �ٲ� ���� ����ϰ� ��
        }
    }

    // ���
    public void Dead()
    {
        if (hp <= 0)
        {
            Vector3 pos = transform.position;   // ���� ��ġ

            transform.position = new Vector3(pos.x, pos.y + 1, pos.z);  // �ǹ���ġ�� bottom���� �����߱⿡ y��ǥ ����

            int randomA = Random.Range(1, 4);   // ������ �ִϸ��̼��� �������� ����ϱ� ���� ����

            animator.SetInteger("explosion", randomA);  // �ִϸ��̼� ����

            CsCollider.enabled = false;     // CapsuleCollider2D ����
            rbody.simulated = false;        // rigidBody2D ����

            Destroy(gameObject, 1.5f);      // ������Ʈ ����
        }
    }
}
