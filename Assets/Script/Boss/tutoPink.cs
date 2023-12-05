using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoPink : MonoBehaviour
{
    public GameObject next;

    public bool isOn;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(next != null)
                next.GetComponent<tutoPink>().isOn = true;
            this.isOn = false;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            this.tag = "Parry";
            this.gameObject.layer = 12;
            this.GetComponent<Animator>().SetBool("pinkOn",true);
        }
        else
        {
            this.tag = "Untagged";
            this.gameObject.layer = 0;
            this.GetComponent<Animator>().SetBool("pinkOn", false);
        }
    }
}
