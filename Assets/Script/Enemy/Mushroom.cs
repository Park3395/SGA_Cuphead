using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : EnemyController
{
    public float shootDelay = 0.0f;         // �߻� ����
    public GameObject mushroomshooter;       // ������ �߻��ϴ� ��
    public GameObject poisonPrefab;           // ������
    public GameObject parringpoisonPrefab;      // �и����� ������

    bool hasAttacked = false;

    public float shootForce = 5.0f; // ���� �߻��� ��

    protected override void Start()
    {
        base.Start();

        hasAttacked = true;
    }

    protected override void Update()
    {        
        // �÷��̾� ��ġ�� ���� �̵� ���� ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dx = player.transform.position.x - transform.position.x;
            if (dx < reactionDistance)
            {
                direction1 = "left";        // �÷��̾ ���ͺ��� ���ʿ� ���� �� �������� �̵�
                direction2 = "left";
                spriteRenderer.flipX = false;
            }
            else if (dx > reactionDistance)
            {
                direction1 = "right";       // �÷��̾ ���ͺ��� �����ʿ� ���� �� ���������� �̵�
                direction2 = "right";
                spriteRenderer.flipX = true;
            }
        }

        if (player != null)
        {
            float dist = Vector2.Distance(transform.position, player.transform.position);   //���Ϳ� �÷��̾� �Ÿ� ���
            if (dist < reactionDistance)
            {
                animator.SetBool("discover", true);
                if (hasAttacked)
                {
                    Attackanime();
                }
            }
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    public void Attack()
    {
        GameObject poisonObj = Instantiate(poisonPrefab, mushroomshooter.transform.position, Quaternion.identity);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dx = player.transform.position.x - mushroomshooter.transform.position.x;

        Vector2 shootPw = new Vector2(dx, shootForce);

        Rigidbody2D body = poisonObj.GetComponent<Rigidbody2D>();
        body.AddForce(shootPw, ForceMode2D.Impulse);
    }

    public void Attack2()
    {
        GameObject poisonObj = Instantiate(parringpoisonPrefab, mushroomshooter.transform.position, Quaternion.identity);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dx = player.transform.position.x - mushroomshooter.transform.position.x;

        Vector2 shootPw = new Vector2(dx, shootForce);

        Rigidbody2D body = poisonObj.GetComponent<Rigidbody2D>();
        body.AddForce(shootPw, ForceMode2D.Impulse);
    }

    public void Attackanime()
    {
        animator.SetBool("attack", true);
        hasAttacked = false;
    }

    public void stopAttack()
    {
        animator.SetBool("attack", false);
        Invoke("Attackpossible", shootDelay);
    }

    public void Attackpossible()
    {
        hasAttacked = true;
    }

    public override void Dead()
    {
        if (hp <= 0)
        {
            animator.SetTrigger("dead");
        }

        base.Dead();        
    }
}
