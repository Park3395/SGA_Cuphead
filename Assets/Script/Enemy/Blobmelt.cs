using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobmelt : EnemyController
{
    public float range = 0.0f;              // 이동 가능한 범위
    Vector3 defPos;                         // 시작 위치
    public float reviveDelay = 0.0f;        // 부활 딜레이

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
            // range값이 0이 아니면 현재 위치와 현재 방향에서 반전을 시킬 것인지 판단한다.
            if (range > 0.0f)
            {
                // 시작 위치에서 왼쪽으로 range의 반보다 더 이동하였는가?
                if (transform.position.x < defPos.x - (range / 2))
                {
                    direction1 = "right";
                    animator.SetBool("turn", true);
                    //transform.localScale = new Vector2(-1, 1);
                }
                // 반대의 경우(오른쪽)를 검사한다.
                if (transform.position.x > defPos.x + (range / 2))
                {
                    direction1 = "left";
                    animator.SetBool("turn", true);
                    //transform.localScale = new Vector2(1, 1);
                }
            }

            float dist = Vector2.Distance(transform.position, player.transform.position);   //몬스터와 플레이어 거리 계산
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
        // 접촉했을 때 방향 바꾸기
        FlipX();
    }

    // 사망
    public void dead()
    {
        animator.SetBool("dead", true);
        Invoke("SetDeadFalse", reviveDelay);    // 부활 대기
    }

    // 부활 대기
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
