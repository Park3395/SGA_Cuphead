using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NpcM : MonoBehaviour
{
    Animator anim;
    public Text Talktext1;
    public GameObject Textwindow1;
    // Start is called before the first frame update

    public void Action(GameObject Text_)
    {
        Text_ = Textwindow1;
        Talktext1.text = "HEY, GUYS! GOOD TO SEE YA AGAIN!";
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetInteger("PlayerFind") == 1)
        {
            anim.SetBool("isChange", true);
        }
        else
            anim.SetBool("isChange", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isChange", true);
            Find_Player();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isChange", false);
            Find_Player1();
        }
    }
    void Find_Player()
    {
        anim.SetInteger("PlayerFind", 1);
    }
    void Find_Player1()
    {
        anim.SetInteger("PlayerFind", 0);
    }

}
