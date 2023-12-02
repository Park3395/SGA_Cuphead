using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : EnemyController
{
    public float upForce = 0.0f;

    float currTime;
    float destroytime = 4.0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        attack();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (RngManager.GameIsPaused)
        {
            rbody.velocity = new Vector2(0, 0);
        }
        else
        {
            int randomA = Random.Range(1, 4);   // 터지는 애니메이션을 랜덤으로 재생하기 위한 변수

            animator.SetInteger("explosion", randomA);  // 애니메이션 실행

            currTime += Time.deltaTime;

            if (currTime > destroytime)
            {
                Destroy(gameObject);
                currTime = 0.0f;
            }
        }        
    }

    public void attack()
    {
        Vector2 upPw = new Vector2(0, upForce);          // 점프를 위한 벡터

        rbody.AddForce(upPw, ForceMode2D.Impulse);
    }
}
