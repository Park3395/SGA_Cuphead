using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitHyper : MonoBehaviour
{
    [SerializeField]
    private GameObject hyperBullet;

    private float followTime;
    private int initcnt = 0;
    private void initHyper()
    {
        Instantiate(hyperBullet, this.transform.position, new Quaternion());
        if(initcnt == 0)
            initcnt = 1;
    }

    private void Update()
    {
        followTime+=Time.deltaTime;

        if(initcnt > 0)
        {
            if (followTime > 0.05f && initcnt < 4)
            {
                initHyper();
                followTime = 0.0f;
                initcnt++;
            }
            if(initcnt >= 4)
            {
                followTime = 0.0f;
                initcnt = 0;
            }
        }
    }
}
