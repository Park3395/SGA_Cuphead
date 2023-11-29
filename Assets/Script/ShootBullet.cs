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
        if (Input.GetKey(KeyCode.Z))
        {
            Attack();
        }
    }

    //�����Լ�
    public void Attack()
    {
        if(isAttack == false)
        {
            isAttack = true;
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;

            //�Ѿ��� ĳ���� �������� ȸ��
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            //�Ѿ� ����
            GameObject peashooter = Instantiate(peashooterPrefab, transform.position, r);

            //ȭ���� �߻��ϱ� ���� ���� ����
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
    public void StopAttack()
    {
        isAttack = false;
    }
}
