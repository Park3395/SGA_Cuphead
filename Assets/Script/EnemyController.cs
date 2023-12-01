using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 0;     // 체력
    public float speed = 0.0f;  // 이동속도
    public float jump = 0.0f;   // 점프력
    public float reactionDistance = 0.0f;   // 인식 거리

    protected string direction1 = "left";      // 이동 방향
    protected string direction2 = "left";      // 바라보는 방향

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
        // 플레이어 위치에 따른 이동 방향 변경
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dx = player.transform.position.x - transform.position.x;
            if (dx < reactionDistance)
            {
                direction1 = "left";        // 플레이어가 몬스터보다 왼쪽에 있을 시 왼쪽으로 이동
            }
            else if (dx > reactionDistance)
            {
                direction1 = "right";       // 플레이어가 몬스터보다 오른쪽에 있을 시 오른쪽으로 이동
            }
        }
        else
        {
            direction1 = "left";
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // 지면과 닿았을 때        
        if (collision.gameObject.tag == "Bullet")
        {
            hp--;
            if (hp <= 0)
            {
                Dead();
            }
        }
    }

    // 사망
    public virtual void Dead()
    {
        Vector3 pos = transform.position;   // 현재 위치

        transform.position = new Vector3(pos.x, pos.y + 1, pos.z);  // 피벗위치를 bottom으로 변경했기에 y좌표 변경

        int randomA = Random.Range(1, 4);   // 터지는 애니메이션을 랜덤으로 재생하기 위한 변수

        animator.SetInteger("explosion", randomA);  // 애니메이션 실행

        CsCollider.enabled = false;     // CapsuleCollider2D 끄기
        rbody.simulated = false;        // rigidBody2D 끄기
    }

    // 턴    
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
