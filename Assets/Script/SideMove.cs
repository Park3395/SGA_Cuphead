using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMove : MonoBehaviour
{
    public bool isRight = true;
    public float speed = 0.03f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight)
        {

            this.transform.Translate(new Vector3(speed, 0, 0));

            if (this.transform.position.x > 15)
            {
                this.transform.position = new Vector3(-15, this.transform.position.y, this.transform.position.z);
            }
        }
        else
        {
            this.transform.Translate(new Vector3(-speed, 0, 0));

            if(this.transform.position.x < -15)
            this.transform.position = new Vector3(15, this.transform.position.y, this.transform.position.z);
        }
    }
}
