using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera Camera;                  // ���� ī�޶�
    public GameObject Player;              // �÷��̾�
    Transform p_pos;                       // �÷��̾� ��ġ ���� ����
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
