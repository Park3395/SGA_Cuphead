using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : EnemyController
{
    public float shootDelay = 0.0f;         // 발사 간격
    public GameObject lobberUpPrefab;       // 시드 발생하는 곳
    public GameObject seedPrefab;           // 시드

    bool hasAttacked = true;

    public float shootForce = 5.0f; // 위로 발사할 힘

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dist = Vector2.Distance(transform.position, player.transform.position);   //몬스터와 플레이어 거리 계산
            if (dist < reactionDistance)
            {
                if (hasAttacked)
                {
                    Attackanime();
                }
            }
        }
    }

    public void Attack()
    {                
        GameObject seedObj = Instantiate(seedPrefab, lobberUpPrefab.transform.position, Quaternion.identity);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dx = player.transform.position.x - lobberUpPrefab.transform.position.x;

        Vector2 shootPw = new Vector2(dx, shootForce);          // 점프를 위한 벡터

        Rigidbody2D body = seedObj.GetComponent<Rigidbody2D>();
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
}
