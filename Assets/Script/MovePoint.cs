using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum point
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}
public class MovePoint : MonoBehaviour
{
    [SerializeField]
    point pcase;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject cameraMaster;
    CameraController camControl;
    // Start is called before the first frame update
    void Start()
    {
        camControl = cameraMaster.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(new Vector3(player.transform.position.x, 0, 0), new Vector3(this.transform.position.x, 0, 0));
        if(dis < 3f)
        {
            switch (pcase)
            {
                case point.LEFT:
                    if (player.transform.position.x < this.transform.position.x)
                        camControl.move = false;
                    else
                        camControl.move = true;
                    break;
                case point.RIGHT:
                    if (player.transform.position.x > this.transform.position.x)
                        camControl.move = false;
                    else
                        camControl.move = true;
                    break;
                //case point.UP:

                //case point.DOWN:
        }

        }

    }
}
