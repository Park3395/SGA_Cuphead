using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : EnemyController
{
    public float shootDelay = 0.0f;         // �߻� ����
    public GameObject lobberUpPrefab;       // �õ� �߻��ϴ� ��
    public GameObject seedPrefab;           // �õ�

    bool hasAttacked = true;

    public float shootForce = 5.0f; // ���� �߻��� ��

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float dist = Vector2.Distance(transform.position, player.transform.position);   //���Ϳ� �÷��̾� �Ÿ� ���
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

        Vector2 shootPw = new Vector2(dx, shootForce);          // ������ ���� ����

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
