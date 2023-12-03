using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : EnemyController
{
    public float upForce = 0.0f;

    float currTime;
    float destroytime = 4.0f;

    public AudioClip[] upaudio;
    public AudioClip[] eataudio;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        attack();

        int random = Random.Range(0, upaudio.Length);
        audiosource.PlayOneShot(upaudio[random]);

        int random2 = Random.Range(0, eataudio.Length);
        audiosource.PlayOneShot(eataudio[random2]);
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
            currTime += Time.deltaTime;

            if (currTime > destroytime)
            {
                Destroy(gameObject);
                currTime = 0.0f;
            }
        }

        //if (PlayerController.gameState != "playing")
        //{
        //    int randomA = Random.Range(1, 4);   // ������ �ִϸ��̼��� �������� ����ϱ� ���� ����

        //    animator.SetInteger("explosion", randomA);  // �ִϸ��̼� ����
        //}
    }

    public void attack()
    {
        Vector2 upPw = new Vector2(0, upForce);          // ������ ���� ����

        rbody.AddForce(upPw, ForceMode2D.Impulse);
    }

    public override void collideroff()
    {
        CsCollider.enabled = false;
    }
}
