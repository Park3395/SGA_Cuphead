using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum point
{
    LEFT,
    RIGHT
}
public class MovePoint : MonoBehaviour
{
    public bool isTwoPoint;
    public point pcase;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject cameraMaster;
    [SerializeField]
    GameObject togoPoint;

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
                    {
                        camControl.move = false;
                        if (camControl.ispoint)
                        {
                            camControl.move = true;
                            camControl.ispoint = false;
                        }
                    }
                    else
                    {
                        camControl.move = true;

                        if (isTwoPoint)
                        {
                            camControl.yScale = (togoPoint.transform.position.y - this.transform.position.y) / Vector3.Distance(this.transform.position, togoPoint.transform.position);
                            camControl.ispoint = true;
                        }
                    }
                    break;
                case point.RIGHT:
                    if (player.transform.position.x < this.transform.position.x)
                    {
                        camControl.move = true;

                        if (isTwoPoint)
                        {
                            camControl.yScale = (togoPoint.transform.position.y - this.transform.position.y) / Vector3.Distance(this.transform.position, togoPoint.transform.position);
                            camControl.ispoint = true;
                        }
                    }
                    else
                    {
                        camControl.move = false;
                        if(camControl.ispoint)
                        {
                            camControl.move = true;
                            camControl.ispoint = false;
                        }
                    }
                    break;
            }
        }
    }
}
