using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : BossBase
{

    [SerializeField]
    private GameObject defaultBullet;
    [SerializeField]
    private GameObject defaultBack;
    [SerializeField]
    private GameObject eyeBullet;
    [SerializeField]
    private GameObject eyePoint;

    private Animator animator;
    private float camleft;
    private float camright;
    private float bottom;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        camleft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        camright = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
        bottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

    }

    // Update is called once per frame
    void Update()
    {
        idleTime += Time.deltaTime;

        if (idleTime > 6.0f && animator.GetBool("eyeform") == false)
        {
            animator.SetBool("eyeform", true);
            idleTime = 0;
        }
        else if (idleTime > 6.0f && animator.GetBool("eyeform") == true)
        {
            animator.SetBool("eyeform", false);
            idleTime = 0;
        }
        
        if(animator.GetBool("eyeform")==false)
        {
            if (shootTime > 1.5f)
            {
                Instantiate(defaultBack, new Vector3(Random.Range(camleft, camright), bottom, 0), new Quaternion());
                shootTime = 0;
            }
            else
                shootTime += Time.deltaTime;
        }
        else
        {
            if (shootTime > 2.0f)
            {
                Instantiate(eyeBullet, eyePoint.transform.position, new Quaternion());
                shootTime = 0;
            }
            else
                shootTime += Time.deltaTime;
        }
    }
}
