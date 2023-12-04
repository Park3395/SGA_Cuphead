using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float shootspeed = 10.0f;
    public float shootdelay = 0.1f; //shootdelay�� �÷�����

    public GameObject peashooterPrefab; //�峭�� ��(�⺻ ��)
    public GameObject Spread;           //Ȯ��ź
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

    //�����Լ�
    public void Attack()
    {
        if (isAttack == false)
        {
            isAttack = true;
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;

            //�Ѿ��� ĳ���� �������� ȸ��
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            //�Ѿ� ����
            GameObject peashooter = Instantiate(peashooterPrefab, transform.position, r);

            //�Ѿ��� �߻��ϱ� ���� ���� ����
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
            //�Ѿ��� ������ ���� �ٵ� ���� ���⼭ �÷��̾ ���� ���⿡ ���� �ٸ��� ���� ����;
            body.AddForce(v, ForceMode2D.Impulse);

            //shootdelay�� �� ���� �� ���⵵ �ϴ�
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

                //������ �ٶ� �� �߻簢

                if (angleZ == 0)
                {
                    Vector3 bulletDir = new Vector3(Mathf.Cos((angleZ + 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body = spread.GetComponent<Rigidbody2D>();
                    body.AddForce(bulletDir, ForceMode2D.Impulse);
                }
                //bulletDir.x -= 0.3f;
                //bulletDir.x += 0.3f * i;
                //Vector3 v = new Vector3(x, y) * shootspeed;
                //���� �ٶ� �� �߻簢
                if (angleZ == 90)
                {
                    Vector3 bulletDir90 = new Vector3(Mathf.Cos((angleZ - 30.0f + 20.0f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ - 30.0f + 20.0f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body90 = spread.GetComponent<Rigidbody2D>();
                    body90.AddForce(bulletDir90, ForceMode2D.Impulse);
                }
                //��밢 �϶� �߻簢
                if (angleZ == 45)
                {
                    Vector3 bulletDir45 = new Vector3(Mathf.Cos((angleZ - 20.0f + 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ - 20.0f + 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body45 = spread.GetComponent<Rigidbody2D>();
                    body45.AddForce(bulletDir45, ForceMode2D.Impulse);
                }

                //������ �ٶ󺼶� �߻簢
                if (angleZ == 180)
                {
                    Vector3 bulletDir180 = new Vector3(Mathf.Cos((angleZ - 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ - 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body180 = spread.GetComponent<Rigidbody2D>();
                    body180.AddForce(bulletDir180, ForceMode2D.Impulse);
                }

                //�´밢�� �� �߻簢
                if (angleZ == 135)
                {
                    Vector3 bulletDir135 = new Vector3(Mathf.Cos((angleZ + 20.0f - 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 20.0f - 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D body135 = spread.GetComponent<Rigidbody2D>();
                    body135.AddForce(bulletDir135, ForceMode2D.Impulse);
                }

                //������ �߻� N->negative(����)

                if (angleZ == -90)
                {
                    Vector3 bulletDirN90 = new Vector3(Mathf.Cos((angleZ + 30.0f - 20.0f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 30.0f - 20.0f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyN90 = spread.GetComponent<Rigidbody2D>();
                    bodyN90.AddForce(bulletDirN90, ForceMode2D.Impulse);
                }
                //������ �ƴϸ鼭 ���� �ٶ󺼶� �Ѿ��� ȸ�������� �ٲ���ϴ� ������ �����.
                /*
                if (Onground && angleZ == -90)
                {
                    Vector3 bulletDirON90 = new Vector3(Mathf.Cos((angleZ + 90 + 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 90 + 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyON90 = spread.GetComponent<Rigidbody2D>();
                    bodyON90.AddForce(bulletDirON90, ForceMode2D.Impulse);
                }
                */

                //�� �´밢
                
                if (angleZ == -135)
                {
                    Vector3 bulletDirN135 = new Vector3(Mathf.Cos((angleZ - 20.0f + 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ - 20.0f + 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyN135 = spread.GetComponent<Rigidbody2D>();
                    bodyN135.AddForce(bulletDirN135, ForceMode2D.Impulse);
                }

                //�Ʒ��� ���� ���·� ������ �ٶ� �� angleZ 0�� �� �߻簢���� angleZ 0�� �Ǵ� ������ �����.
                /*
                if (Onground && angleZ == -135)
                {
                    Vector3 bulletDirON135 = new Vector3(Mathf.Cos((angleZ + 315 - 11.25f * i) * Mathf.Deg2Rad), Mathf.Sin((angleZ + 315 - 11.25f * i) * Mathf.Deg2Rad)) * shootspeed;
                    Rigidbody2D bodyON135 = spread.GetComponent<Rigidbody2D>();
                    bodyON135.AddForce(bulletDirON135, ForceMode2D.Impulse);
                }*/



                //�� ��밢
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