using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RnGCamera : MonoBehaviour
{
    // 각 방향의 스크롤 제한
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
        // 플레이어를 현제 Scene에서 검색한다.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // 카메라 좌표 갱신
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            // 가로 방향 업데이트(좌우로 이동 제한을 적용한다)
            if (x < leftLimit)
                x = leftLimit;
            else if (x > rightLimit)
                x = rightLimit;

            // 세로 방향 업데이트(상하로 이동 제한을 적용한다)
            if (y < bottomLimit)
                y = bottomLimit;
            else if (y > topLimit)
                y = topLimit;

            // 플레이어의 위치를 기반으로 카메라가 따라갈 수 있도록 한다.
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;

            if (transform.position.x >= cameraPoint1.transform.position.x && transform.position.x < cameraPoint2.transform.position.x)
            {
                if (topLimit != 1.3f)
                {
                    if (topLimit <= 1.3f)
                    {
                        topLimit += movespeed;
                        if (topLimit >= 1.25f && topLimit <= 1.35f)
                        {
                            topLimit = 1.3f;
                        }
                    }                    
                }
                if (bottomLimit != 1.3f)
                {
                    if (bottomLimit <= 1.3f)
                    {
                        bottomLimit += movespeed;
                        if (bottomLimit >= 1.25f && bottomLimit <= 1.35f)
                        {
                            bottomLimit = 1.3f;
                        }
                    }
                }
                    
            }
            else if (transform.position.x >= cameraPoint2.transform.position.x && transform.position.x < cameraPoint3.transform.position.x)
            {
                if (topLimit != 0.1f)
                {
                    if (topLimit > 0.1f)
                    {
                        topLimit -= movespeed;
                        if (topLimit >= 0.05f && topLimit <= 0.15f)
                        {
                            topLimit = 0.1f;
                        }

                    }
                    else if (topLimit < 0.1f)
                    {
                        topLimit += movespeed;
                        if (topLimit >= 0.05f && topLimit <= 0.15f)
                        {
                            topLimit = 0.1f;
                        }
                    }
                }

                if (bottomLimit != 0.1f)
                {
                    if (bottomLimit > 0.1f)
                    {
                        bottomLimit -= movespeed;
                        if (bottomLimit >= 0.05f && bottomLimit <= 0.15f)
                        {
                            bottomLimit = 0.1f;
                        }

                    }
                    else if (bottomLimit < 0.1f)
                    {
                        bottomLimit += movespeed;
                        if (bottomLimit >= 0.05f && bottomLimit <= 0.15f)
                        {
                            bottomLimit = 0.1f;
                        }
                    }
                }
            }
            else if (transform.position.x >= cameraPoint3.transform.position.x && transform.position.x < cameraPoint4.transform.position.x)
            {
                if (topLimit != 0.6f)
                {
                    if (topLimit > 0.6f)
                    {
                        topLimit -= movespeed;
                        if (topLimit >= 0.55f && topLimit <= 0.65f)
                        {
                            topLimit = 0.6f;
                        }

                    }
                    else if (topLimit < 0.6f)
                    {
                        topLimit += movespeed;
                        if (topLimit >= 0.55f && topLimit <= 0.65f)
                        {
                            topLimit = 0.6f;
                        }
                    }
                }

                if (bottomLimit != 0.6f)
                {
                    if (bottomLimit > 0.6f)
                    {
                        bottomLimit -= movespeed;
                        if (bottomLimit >= 0.55f && bottomLimit <= 0.65f)
                        {
                            bottomLimit = 0.6f;
                        }

                    }
                    else if (bottomLimit < 0.6f)
                    {
                        bottomLimit += movespeed;
                        if (bottomLimit >= 0.55f && bottomLimit <= 0.65f)
                        {
                            bottomLimit = 0.6f;
                        }
                    }
                }
            }
            else if (transform.position.x >= cameraPoint4.transform.position.x && transform.position.x < cameraPoint5.transform.position.x)
            {
                if (topLimit != -1.2f)
                {
                    if (topLimit > -1.2f)
                    {
                        topLimit -= movespeed;
                        if (topLimit >= -1.25f && topLimit <= -1.15f)
                        {
                            topLimit = -1.2f;
                        }

                    }
                    else if (topLimit < -1.2f)
                    {
                        topLimit += movespeed;
                        if (topLimit >= -1.25f && topLimit <= -1.15f)
                        {
                            topLimit = -1.2f;
                        }
                    }
                }

                if (bottomLimit != -1.2f)
                {
                    if (bottomLimit > -1.2f)
                    {
                        bottomLimit -= movespeed;
                        if (bottomLimit >= -1.25f && bottomLimit <= -1.15f)
                        {
                            bottomLimit = -1.2f;
                        }

                    }
                    else if (bottomLimit < -1.2f)
                    {
                        bottomLimit += movespeed;
                        if (bottomLimit >= -1.25f && bottomLimit <= -1.15f)
                        {
                            bottomLimit = -1.2f;
                        }
                    }
                }
            }
            else if (transform.position.x >= cameraPoint5.transform.position.x && transform.position.x < cameraPoint6.transform.position.x)
            {
                if (topLimit != -1.7f)
                {
                    if (topLimit > -1.7f)
                    {
                        topLimit -= movespeed;
                        if (topLimit >= -1.75f && topLimit <= -1.65f)
                        {
                            topLimit = -1.7f;
                        }

                    }
                    else if (topLimit < -1.7f)
                    {
                        topLimit += movespeed;
                        if (topLimit >= -1.75f && topLimit <= -1.65f)
                        {
                            topLimit = -1.7f;
                        }
                    }
                }

                if (bottomLimit != -1.7f)
                {
                    if (bottomLimit > -1.7f)
                    {
                        bottomLimit -= movespeed;
                        if (bottomLimit >= -1.75f && bottomLimit <= -1.65f)
                        {
                            bottomLimit = -1.7f;
                        }

                    }
                    else if (bottomLimit < -1.7f)
                    {
                        bottomLimit += movespeed;
                        if (bottomLimit >= -1.75f && bottomLimit <= -1.65f)
                        {
                            bottomLimit = -1.7f;
                        }
                    }
                }
            }
            else if (transform.position.x >= cameraPoint6.transform.position.x)
            {
                if (topLimit != -2.5f)
                {
                    if (topLimit > -2.5f)
                    {
                        topLimit -= movespeed;
                        if (topLimit >= -2.55f && topLimit <= -2.45f)
                        {
                            topLimit = -2.5f;
                        }

                    }
                    else if (topLimit < -2.5f)
                    {
                        topLimit += movespeed;
                        if (topLimit >= -2.55f && topLimit <= -2.45f)
                        {
                            topLimit = -2.5f;
                        }
                    }
                }

                if (bottomLimit != -2.5f)
                {
                    if (bottomLimit > -2.5f)
                    {
                        bottomLimit -= movespeed;
                        if (bottomLimit >= -2.55f && bottomLimit <= -2.45f)
                        {
                            bottomLimit = -2.5f;
                        }

                    }
                    else if (bottomLimit < -2.5f)
                    {
                        bottomLimit += movespeed;
                        if (bottomLimit >= -2.55f && bottomLimit <= -2.45f)
                        {
                            bottomLimit = -2.5f;
                        }
                    }
                }
            }
            else
            {
                if (topLimit != 0.0f)
                {
                    if (topLimit > 0.0f)
                    {
                        topLimit -= movespeed;
                        if (topLimit >= -0.05f && topLimit <= 0.05f)
                        {
                            topLimit = 0.0f;
                        }

                    }
                    else if (topLimit < 0.0f)
                    {
                        topLimit += movespeed;
                        if (topLimit >= -0.05f && topLimit <= 0.05f)
                        {
                            topLimit = 0.0f;
                        }
                    }
                }

                if (bottomLimit != 0.0f)
                {
                    if (bottomLimit > 0.0f)
                    {
                        bottomLimit -= movespeed;
                        if (bottomLimit >= -0.05f && bottomLimit <= 0.05f)
                        {
                            bottomLimit = 0.0f;
                        }

                    }
                    else if (bottomLimit < 0.0f)
                    {
                        bottomLimit += movespeed;
                        if (bottomLimit >= -0.05f && bottomLimit <= 0.05f)
                        {
                            bottomLimit = 0.0f;
                        }
                    }
                }
            }
        }
    }
}
