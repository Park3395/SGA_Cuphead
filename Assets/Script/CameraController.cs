using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;                     // ���� ī�޶�
    [SerializeField]
    GameObject player;              // �÷��̾�

    public bool move = false;       // �¿� �̵�
    public bool ispoint;

    public float startY;
    private float yScale;
    public float pointx;
    public float length;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        startY = cam.transform.position.y;
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
                    yScale = startY + height * (Mathf.Abs(player.transform.position.x - pointx) / length);
                Debug.Log(yScale);
                cam.transform.position = Vector3.Lerp(cam.transform.position,new Vector3(player.transform.position.x, yScale, -10), 3f);
            }
        }
    }

}
