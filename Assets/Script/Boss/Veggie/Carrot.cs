using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : BossBase
{
    [SerializeField]
    private GameObject defaultBack;
    [SerializeField]
    private GameObject eyePoint;
    [SerializeField]
    private GameObject hyper_effect;

    private Animator animator;
    private float camleft;
    private float camright;
    private float bottom;

    private void eyeActive()
    {
        this.eyePoint.SetActive(true);
        this.hyper_effect.SetActive(true);
    }
    private void eyeInactive()
    {
        this.eyePoint.SetActive(false);
        this.hyper_effect.SetActive(false);
    }

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

        if (this.NowHP <= 0)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<Animator>().Play(DeadAnim);
            GameObject.FindWithTag("SceneManager").GetComponent<VeggieSceneManager>().clear();
            explode.SetActive(true);
        }

        if (idleTime > 12.0f && animator.GetBool("eyeform") == false)
        {
            animator.SetBool("eyeform", true);
            idleTime = 0;
        }
        else if (idleTime > 12.0f && animator.GetBool("eyeform") == true)
        {
            animator.SetBool("eyeform", false);
            idleTime = 0;
        }

        if(this.NowHP > 0)
        {
            if(animator.GetBool("eyeform")==false)
            {
                if (shootTime > 2.0f)
                {
                    Instantiate(defaultBack, new Vector3(Random.Range(camleft, camright), bottom, 0), new Quaternion());
                    shootTime = 0;
                }
                else
                    shootTime += Time.deltaTime;
            }
            else
            {
                if (shootTime > 2.5f)
                {
                    hyper_effect.GetComponent<Animator>().Play(EffectAnims[0]);
                    shootTime = 0;
                }
                else
                    shootTime += Time.deltaTime;
            }
        }
    }
}
