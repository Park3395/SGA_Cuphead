using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (NewBehaviourScript.instance.equipPeashooter && collision.gameObject.tag == "Enemy")
        {
            GetComponent<Animator>().Play("PeaShooterDead");
            Destroy(gameObject, 0.25f);
        }
        if(NewBehaviourScript.instance.equipPeashooter && collision.gameObject.tag == "Ground")
        {
            GetComponent<Animator>().Play("PeaShooterDead");
            Destroy(gameObject, 0.25f);

        }

        if (NewBehaviourScript.instance.equipSpread && collision.gameObject.tag == "Enemy")
        {
            GetComponent<Animator>().Play("SpreadDead");
            Destroy(gameObject, 0.25f);
        }

        if (NewBehaviourScript.instance.equipSpread && collision.gameObject.tag == "Ground")
        {
            GetComponent<Animator>().Play("SpreadDead");
            Destroy(gameObject, 0.25f);

        }

    }

   

}
