using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RnGCamera : MonoBehaviour
{
    // �� ������ ��ũ�� ����
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;

    public float movespeed = 0.01f;

    public GameObject cameraPoint1;
    public GameObject cameraPoint2;
    public GameObject cameraPoint3;
    public GameObject cameraPoint4;
    public GameObject cameraPoint5;
    public GameObject cameraPoint6;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾ ���� Scene���� �˻��Ѵ�.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // ī�޶� ��ǥ ����
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            // ���� ���� ������Ʈ(�¿�� �̵� ������ �����Ѵ�)
            if (x < leftLimit)
                x = leftLimit;
            else if (x > rightLimit)
                x = rightLimit;

            // ���� ���� ������Ʈ(���Ϸ� �̵� ������ �����Ѵ�)
            if (y < bottomLimit)
                y = bottomLimit;
            else if (y > topLimit)
                y = topLimit;

            // �÷��̾��� ��ġ�� ������� ī�޶� ���� �� �ֵ��� �Ѵ�.
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;

            if (transform.position.x >= cameraPoint1.transform.position.x && transform.position.x < cameraPoint2.transform.position.x)
            {
                if (topLimit <= 1.3f)
                    topLimit += movespeed;
                if (bottomLimit <= 1.3f)
                    bottomLimit += movespeed;
            }
            else if (transform.position.x >= cameraPoint2.transform.position.x && transform.position.x < cameraPoint3.transform.position.x)
            {
                if (topLimit > 0.1f)
                    topLimit -= movespeed;
                else if (topLimit < 0.1f)
                    topLimit += movespeed;

                if (bottomLimit > -0.1f)
                    bottomLimit -= movespeed;
                else if (bottomLimit < -0.1f)
                    bottomLimit += movespeed;
            }
            else if (transform.position.x >= cameraPoint3.transform.position.x && transform.position.x < cameraPoint4.transform.position.x)
            {
                if (topLimit > 0.6f)
                    topLimit -= movespeed;
                else if (topLimit < 0.6f)
                    topLimit += movespeed;

                if (bottomLimit > 0.6f)
                    bottomLimit -= movespeed;
                else if (bottomLimit < 0.6f)
                    bottomLimit += movespeed;
            }
            else if (transform.position.x >= cameraPoint4.transform.position.x && transform.position.x < cameraPoint5.transform.position.x)
            {
                if (topLimit > -1.2f)
                    topLimit -= movespeed;
                else if (topLimit < -1.2f)
                    topLimit += movespeed;

                if (bottomLimit > -1.2f)
                    bottomLimit -= movespeed;
                else if (bottomLimit < -1.2f)
                    bottomLimit += movespeed;
            }
            else if (transform.position.x >= cameraPoint5.transform.position.x && transform.position.x < cameraPoint6.transform.position.x)
            {
                if (topLimit > -1.7f)
                    topLimit -= movespeed;
                else if (topLimit < -1.7f)
                    topLimit += movespeed;

                if (bottomLimit > -1.7f)
                    bottomLimit -= movespeed;
                else if (bottomLimit < -1.7f)
                    bottomLimit += movespeed;
            }
            else if (transform.position.x >= cameraPoint6.transform.position.x)
            {
                if (topLimit > -2.5f)
                    topLimit -= movespeed;
                else if (topLimit < -2.5f)
                    topLimit += movespeed;

                if (bottomLimit > -2.5f)
                    bottomLimit -= movespeed;
                else if (bottomLimit < -2.5f)
                    bottomLimit += movespeed;
            }
            else
            {
                topLimit = 0.0f;
                bottomLimit = 0.0f;
                if (topLimit != 0.0f)
                {
                    if (topLimit > 0.0f)
                        topLimit -= movespeed;
                    else if (topLimit < 0.0f)
                        topLimit += movespeed;
                }
                if (bottomLimit != 0.0f)
                {
                    if (bottomLimit > 0.0f)
                        bottomLimit -= movespeed;
                    else if (bottomLimit < 0.0f)
                        bottomLimit += movespeed;
                }
            }
        }
    }
}
