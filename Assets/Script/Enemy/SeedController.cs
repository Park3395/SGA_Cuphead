using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(collision.transform);

        GetComponent<Animator>().SetTrigger("explosion");

        // 충돌 판정 비활성화
        GetComponent<CircleCollider2D>().enabled = false;
        // 물리 시뮬레이션 비활성화
        GetComponent<Rigidbody2D>().simulated = false;
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
