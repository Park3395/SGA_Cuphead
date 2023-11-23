using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatforms : MonoBehaviour
{
    public float moveX = 0.0f;              // X축 이동 거리
    public float moveY = 0.0f;              // Y축 이동 거리
    public float times = 0.0f;              // 시간
    public float weight = 0.0f;             // 정지

    public bool isCanMove = true;           // 움직임
    float perDX;                            // 프레임 당 X축 이동 값
    float perDY;                            // 프레임 당 Y축 이동 값
    Vector3 defPos;                         // 초기 위치
    bool isReverse = false;                 // 이동 방향 반전


    // Start is called before the first frame update
    void Start()
    {
        // 초기 위치
        defPos = transform.position;
        // 1프레임 당 각 축 이동에 더할 시간 값
        float timestep = Time.fixedDeltaTime;
        // 1프레임 당 X축 이동 값
        perDX = moveX / (1.0f / timestep * times);
        // 1프레임 당 Y축 이동 값
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
                // 방향 반전
                if ((perDX >= 0.0f && x <= defPos.x) || (perDX < 0.0f && x >= defPos.x))
                {
                    // 이동 값이 양수
                    endX = true;        // x축 방향 이동 종료
                }
                if ((perDY >= 0.0f && y <= defPos.y) || (perDY < 0.0f && y >= defPos.y))
                {
                    // 이동 값이 양수
                    endY = true;        // x축 방향 이동 종료
                }
                // 블록 이동
                transform.Translate(new Vector3(-perDX, -perDY, defPos.z));
            }
            else
            {
                // 정방향 이동 처리
                // 방향 반전
                if ((perDX >= 0.0f && x >= defPos.x + moveX) || (perDX < 0.0f && x <= defPos.x + moveX))
                {
                    // 이동 값이 양수
                    endX = true;        // x축 방향 이동 종료
                }
                if ((perDY >= 0.0f && y >= defPos.y + moveY) || (perDY < 0.0f && y <= defPos.y + moveY))
                {
                    // 이동 값이 양수
                    endY = true;        // x축 방향 이동 종료
                }
                // 블록 이동
                Vector3 v = new Vector3(perDX, perDY, defPos.z);
                transform.Translate(v);
            }

            if (endX && endY)
            {
                // 이동 처리 종료
                if (isReverse)
                {
                    // 위치 어긋나기 방지용(정방향 이동으로 돌아가기 전 초기 위치로 되돌리기)
                    transform.position = defPos;
                }
                isReverse = !isReverse;     // 현재 값 반전
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 접촉한 것이 플레이어일 경우 플랫폼 살짝 내리기
                        
        }
    }
}
