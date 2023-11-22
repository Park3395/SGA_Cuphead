using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera;                  // 메인 카메라
    public GameObject Player;              // 플레이어
    Transform p_pos;                       // 플레이어 위치 저장 변수
    // Start is called before the first frame update
    void Start()
    {
        p_pos = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
        }
    }
}
