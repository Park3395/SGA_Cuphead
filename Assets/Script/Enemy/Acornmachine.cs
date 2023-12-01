using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acornmachine : EnemyController
{
    // flowergrunt
    public GameObject flowergrunt;
    Animator floweranim;


    protected override void Start()
    {
        base.Start();
        floweranim = flowergrunt.GetComponent<Animator>();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.tag == "Bullet")
        {
            this.GetComponent<Animator>().Play("onHit");
        }
    }

    public override void Dead()
    {
        // animation ����
        animator.SetTrigger("dead");

        // �׾��� �� flowergrunt �ִϸ��̼� ����
        Vector3 pos = flowergrunt.transform.position;   // ���� ��ġ

        flowergrunt.transform.position = new Vector3(pos.x, pos.y + 1, pos.z);  // �ǹ���ġ�� bottom���� �����߱⿡ y��ǥ ����

        int randomA = Random.Range(1, 4);   // ������ �ִϸ��̼��� �������� ����ϱ� ���� ����

        floweranim.SetInteger("explosion", randomA);  // �ִϸ��̼� ����

        CsCollider.enabled = false;     // CapsuleCollider2D ����
        rbody.simulated = false;        // rigidBody2D ����
    }
}
