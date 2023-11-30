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
        if(isAttack == false)
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
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            for(int i = 1; i<5; i++)
            {
                GameObject spread = Instantiate(Spread, transform.position, r);
                float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
                float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);

                //밑에 3줄에 뭘 넣어야하나
                

              
                    Vector3 bulletDir = new Vector3(Mathf.Cos((angleZ-15+15*i) * Mathf.Deg2Rad), Mathf.Sin((angleZ-15+15*i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body = spread.GetComponent<Rigidbody2D>();

                    body.AddForce(bulletDir, ForceMode2D.Impulse);
               


                //bulletDir.x -= 0.3f;
                //bulletDir.x += 0.3f * i;
                //Vector3 v = new Vector3(x, y) * shootspeed;
               
                Invoke("StopAttack", shootdelay);
                Destroy(spread, 1.0f);

            }
           




        }
            
    }
    public void StopAttack()
    {
        isAttack = false;
    }
}
