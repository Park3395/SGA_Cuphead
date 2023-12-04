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
                        if (!isTwoPoint)
                            camControl.move = false;
                        else
                        {
                            camControl.ispoint = false;
                            camControl.move = true;
                        }
                    }
                    else
                    {
                        camControl.move = true;

                        if (isTwoPoint && !camControl.ispoint)
                        {
                            camControl.height = (togoPoint.transform.position.y - this.transform.position.y);
                            camControl.pointx = this.transform.position.x;
                            camControl.length = togoPoint.transform.position.x - this.transform.position.x;
                            camControl.startY = Camera.main.transform.position.y;
                            camControl.ispoint = true;
                        }
                    }
                    break;
                case point.RIGHT:
                    if (player.transform.position.x < this.transform.position.x)
                    {
                        camControl.move = true;

                        if (isTwoPoint && !camControl.ispoint)
                        {
                            camControl.height = (togoPoint.transform.position.y - this.transform.position.y);
                            camControl.pointx = this.transform.position.x;
                            camControl.length = this.transform.position.x - togoPoint.transform.position.x;
                            camControl.startY = Camera.main.transform.position.y;

                            camControl.ispoint = true;
                        }
                    }
                    else
                    {
                        if(!isTwoPoint)
                            camControl.move = false;
                        else
                        {
                            camControl.ispoint = false;
                            camControl.move = true;
                        }
                    }
                    break;
            }
        }
    }
}
