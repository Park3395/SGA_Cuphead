using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : BossBase
{
    [SerializeField]
    private GameObject dirt;
    [SerializeField]
    private GameObject[] tears;

    [SerializeField]
    private GameObject defaultBullet;
    [SerializeField]
    private GameObject pinkBullet;

    [SerializeField]
    private string peaceleave;

    private Animator animator;
    private float camleft;
    private float camright;
    private float height;

    void activeDirt()
    {
        dirt.SetActive(true);
    }
    void activeTear()
    {
        for(int i =0;i<tears.Length;i++)
        {
            tears[i].SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        camleft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        camright = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
        height = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y;
        this.shootTime = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        idleTime += Time.deltaTime;

        if(this.MaxHP != this.NowHP)
            animator.SetBool("attack",true);

        if (NowHP == 0)
        {
            for (int i = 0; i < tears.Length; i++)
            {
                tears[i].SetActive(false);
            }
            animator.Play(DeadAnim);
        }

        if (this.idleTime > 15.0f && animator.GetBool("attack") == false)
        {
            animator.Play(peaceleave);
        }


        if (animator.GetBool("attack") == true && this.NowHP != 0)
        {
            if(shootTime > 1.0f)
            {
                int rand = Random.Range(0, 3);
                Debug.Log(rand);
                if (rand != 2)
                    Instantiate(defaultBullet, new Vector3(Random.Range(camleft, camright), height, 0),new Quaternion());
                else
                    Instantiate(pinkBullet, new Vector3(Random.Range(camleft, camright), height, 0), new Quaternion());
                shootTime = 0;
            }
            else
                shootTime += Time.deltaTime;
        }

    }
}
