using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    public float moveX = 0.0f;              // X�� �̵� �Ÿ�
    public float moveY = 0.0f;              // Y�� �̵� �Ÿ�
    public float times = 0.0f;              // �ð�
    public float weight = 0.0f;             // ����

    public bool isCanMove = true;           // ������
    float perDX;                            // ������ �� X�� �̵� ��
    float perDY;                            // ������ �� Y�� �̵� ��
    Vector3 defPos;                         // �ʱ� ��ġ
    bool isReverse = false;                 // �̵� ���� ����


    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ��ġ
        defPos = transform.position;
        // 1������ �� �� �� �̵��� ���� �ð� ��
        float timestep = Time.fixedDeltaTime;
        // 1������ �� X�� �̵� ��
        perDX = moveX / (1.0f / timestep * times);
        // 1������ �� Y�� �̵� ��
        perDY = moveY / (1.0f / timestep * times);
    }

    private void FixedUpdate()
    {
        if (isCanMove)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            bool endX = false;
            bool endY = false;
            if (isReverse)
            {
                // ���� ����
                if ((perDX >= 0.0f && x <= defPos.x) || (perDX < 0.0f && x >= defPos.x))
                {
                    // �̵� ���� ���
                    endX = true;        // x�� ���� �̵� ����
                }
                if ((perDY >= 0.0f && y <= defPos.y) || (perDY < 0.0f && y >= defPos.y))
                {
                    // �̵� ���� ���
                    endY = true;        // x�� ���� �̵� ����
                }
                // ��� �̵�
                transform.Translate(new Vector3(-perDX, -perDY, defPos.z));
            }
            else
            {
                // ������ �̵� ó��
                // ���� ����
                if ((perDX >= 0.0f && x >= defPos.x + moveX) || (perDX < 0.0f && x <= defPos.x + moveX))
                {
                    // �̵� ���� ���
                    endX = true;        // x�� ���� �̵� ����
                }
                if ((perDY >= 0.0f && y >= defPos.y + moveY) || (perDY < 0.0f && y <= defPos.y + moveY))
                {
                    // �̵� ���� ���
                    endY = true;        // x�� ���� �̵� ����
                }
                // ��� �̵�
                Vector3 v = new Vector3(perDX, perDY, defPos.z);
                transform.Translate(v);
            }

            if (endX && endY)
            {
                // �̵� ó�� ����
                if (isReverse)
                {
                    // ��ġ ��߳��� ������(������ �̵����� ���ư��� �� �ʱ� ��ġ�� �ǵ�����)
                    transform.position = defPos;
                }
                isReverse = !isReverse;     // ���� �� ����
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // ������ ���� �÷��̾��� ��� �÷��� ��¦ ������
                        
        }
    }
}
