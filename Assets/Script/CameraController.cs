using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;                     // ���� ī�޶�
    [SerializeField]
    GameObject player;       // �÷��̾�

    public bool move;

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
                cam.transform.position = Vector3.Lerp(cam.transform.position,
                new Vector3(player.transform.position.x, 0, -10), 3f);
            }
            
        }
    }

}
