using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardM : MonoBehaviour
{
    Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RotateCard_True()//ȸ��
    {
        Anim.SetBool("isChange", true);
    }
    public void RotateCard_False()//ȸ������ �� �ո�
    {
        Anim.SetBool("isChange", false);
    }
    public void RotateCard_True2()//�޸�����
    {
        Anim.SetBool("isChange2", true);
    }
}
