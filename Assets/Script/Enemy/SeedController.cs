using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(collision.transform);

        GetComponent<Animator>().SetTrigger("explosion");

        // �浹 ���� ��Ȱ��ȭ
        GetComponent<CircleCollider2D>().enabled = false;
        // ���� �ùķ��̼� ��Ȱ��ȭ
        GetComponent<Rigidbody2D>().simulated = false;
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
