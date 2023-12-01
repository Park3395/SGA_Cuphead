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
        // animation 실행
        animator.SetTrigger("dead");

        // 죽었을 때 flowergrunt 애니메이션 실행
        Vector3 pos = flowergrunt.transform.position;   // 현재 위치

        flowergrunt.transform.position = new Vector3(pos.x, pos.y + 1, pos.z);  // 피벗위치를 bottom으로 변경했기에 y좌표 변경

        int randomA = Random.Range(1, 4);   // 터지는 애니메이션을 랜덤으로 재생하기 위한 변수

        floweranim.SetInteger("explosion", randomA);  // 애니메이션 실행

        CsCollider.enabled = false;     // CapsuleCollider2D 끄기
        rbody.simulated = false;        // rigidBody2D 끄기
    }
}
