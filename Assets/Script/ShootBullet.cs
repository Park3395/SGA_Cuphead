using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float shootspeed = 10.0f;
    public float shootdelay = 0.1f; //shootdelay를 늘려보자

    public GameObject peashooterPrefab; //장난감 총(기본 총)
    public GameObject Spread;           //확산탄
    bool isAttack = false;
    GameObject spawnBullet;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Z))
        {
            Attack();
        }*/

        if (Input.GetKey(KeyCode.Z))
        {
            SpreadAttack();
        }

    }

    //공격함수
    public void Attack()
    {
        if (isAttack == false)
        {
            isAttack = true;
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;

            //총알이 캐릭터 방향으로 회전
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            //총알 생성
            GameObject peashooter = Instantiate(peashooterPrefab, transform.position, r);

            //총알을 발사하기 위한 벡터 생성
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            Vector3 v = new Vector3(x, y) * shootspeed;

            /*
            if (Input.GetKey(KeyCode.UpArrow))
            {
                v =  0.9f*v;
            }
            */

            Rigidbody2D body = peashooter.GetComponent<Rigidbody2D>();
            //총알이 앞으로 가게 근데 이제 여기서 플레이어가 보는 방향에 따라 다르게 가야 ㅎㅎ;
            body.AddForce(v, ForceMode2D.Impulse);

            //shootdelay가 좀 빠른 거 같기도 하다
            Invoke("StopAttack", shootdelay);
            Destroy(peashooter, 3.0f);


        }

    }
    public void SpreadAttack()
    {

        if (isAttack == false)
        {
            isAttack = true;
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;
            bool Onground = playerCnt.onGround;
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            for (int i = 0; i < 4; i++)
            {
                GameObject spread = Instantiate(Spread, transform.position, r);
                float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);

                //오른쪽 바라볼 때 발사각

                if (angleZ == 0)
                {
                    Vector3 bulletDir = new Vector3(Mathf.Cos((angleZ + 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body = spread.GetComponent<Rigidbody2D>();
                    body.AddForce(bulletDir, ForceMode2D.Impulse);
                }
                //bulletDir.x -= 0.3f;
                //bulletDir.x += 0.3f * i;
                //Vector3 v = new Vector3(x, y) * shootspeed;
                //위를 바라볼 때 발사각
                if (angleZ == 90)
                {
                    Vector3 bulletDir90 = new Vector3(Mathf.Cos((angleZ - 30.0f + 20.0f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ - 30.0f + 20.0f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body90 = spread.GetComponent<Rigidbody2D>();
                    body90.AddForce(bulletDir90, ForceMode2D.Impulse);
                }
                //우대각 일때 발사각
                if (angleZ == 45)
                {
                    Vector3 bulletDir45 = new Vector3(Mathf.Cos((angleZ - 20.0f + 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ - 20.0f + 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body45 = spread.GetComponent<Rigidbody2D>();
                    body45.AddForce(bulletDir45, ForceMode2D.Impulse);
                }

                //왼쪽을 바라볼때 발사각
                if (angleZ == 180)
                {
                    Vector3 bulletDir180 = new Vector3(Mathf.Cos((angleZ - 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ - 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body180 = spread.GetComponent<Rigidbody2D>();
                    body180.AddForce(bulletDir180, ForceMode2D.Impulse);
                }

                //좌대각일 때 발사각
                if (angleZ == 135)
                {
                    Vector3 bulletDir135 = new Vector3(Mathf.Cos((angleZ + 20.0f - 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 20.0f - 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body135 = spread.GetComponent<Rigidbody2D>();
                    body135.AddForce(bulletDir135, ForceMode2D.Impulse);
                }

                //밑으로 발사 N->negative(음수)

                if (angleZ == -90)
                {
                    Vector3 bulletDirN90 = new Vector3(Mathf.Cos((angleZ + 30.0f - 20.0f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 30.0f - 20.0f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyN90 = spread.GetComponent<Rigidbody2D>();
                    bodyN90.AddForce(bulletDirN90, ForceMode2D.Impulse);
                }
                //점프가 아니면서 밑을 바라볼때 총알의 회전각도도 바꿔야하는 문제가 생겼다.
                /*
                if (Onground && angleZ == -90)
                {
                    Vector3 bulletDirON90 = new Vector3(Mathf.Cos((angleZ + 90 + 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 90 + 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyON90 = spread.GetComponent<Rigidbody2D>();
                    bodyON90.AddForce(bulletDirON90, ForceMode2D.Impulse);
                }
                */

                //밑 좌대각
                
                if (angleZ == -135)
                {
                    Vector3 bulletDirN135 = new Vector3(Mathf.Cos((angleZ - 20.0f + 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ - 20.0f + 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyN135 = spread.GetComponent<Rigidbody2D>();
                    bodyN135.AddForce(bulletDirN135, ForceMode2D.Impulse);
                }

                //아래쪽 누른 상태로 왼쪽을 바라볼 때 angleZ 0일 때 발사각도도 angleZ 0이 되는 문제가 생겼다.
                /*
                if (Onground && angleZ == -135)
                {
                    Vector3 bulletDirON135 = new Vector3(Mathf.Cos((angleZ + 315 - 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 315 - 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyON135 = spread.GetComponent<Rigidbody2D>();
                    bodyON135.AddForce(bulletDirON135, ForceMode2D.Impulse);
                }*/



                //밑 우대각
                if (angleZ == -45)
                {
                    Vector3 bulletDirN45 = new Vector3(Mathf.Cos((angleZ + 20.0f - 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 20.0f - 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyN45 = spread.GetComponent<Rigidbody2D>();
                    bodyN45.AddForce(bulletDirN45, ForceMode2D.Impulse);
                }




                Invoke("StopAttack", shootdelay);
                Destroy(spread, 0.7f);

            }





        }

    }
    public void StopAttack()
    {
        isAttack = false;
    }
}