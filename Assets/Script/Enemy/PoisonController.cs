using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonController : MonoBehaviour
{
    public float delaytime = 3.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(collision.transform);

        GetComponent<Animator>().SetTrigger("explosion");

        // �浹 ���� ��Ȱ��ȭ
        GetComponent<CircleCollider2D>().enabled = false;
        // ���� �ùķ��̼� ��Ȱ��ȭ
        GetComponent<Rigidbody2D>().simulated = false;

        delaytime = 0.0f;

        OnDestroy();
    }

    public void OnDestroy()
    {
        Destroy(gameObject, delaytime);
    }
}
