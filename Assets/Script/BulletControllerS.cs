using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GetComponent<Animator>().Play("SpreadDead");
            Destroy(gameObject, 0.25f);
        }

        if(collision.gameObject.tag == "Ground")
        {
            GetComponent<Animator>().Play("SpreadDead");
            Destroy(gameObject, 0.25f);
        }
    }
}
