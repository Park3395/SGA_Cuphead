using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;                 // ���� ī�޶�
    [SerializeField]
    GameObject player;          // �÷��̾�

    public bool move;           // �¿� �̵�
    public bool ispoint;
    public float yScale;        // ���� �̵�
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
