using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;                 // 메인 카메라
    [SerializeField]
    GameObject player;          // 플레이어

    public bool move;           // 좌우 이동
    public bool ispoint;
    public float yScale;        // 위쪽 이동
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if(move)
            {
                cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(player.transform.position.x, cam.transform.position.y, -10), 3f);
            }
            
            if(ispoint)
            {
            //    if (!Mathf.Approximately(player.transform.position.x, cam.transform.position.x))
                    cam.transform.Translate(0, yScale, 0);
            }
        }
    }

}
