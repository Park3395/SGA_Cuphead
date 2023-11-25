using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldChar : MonoBehaviour
{
    //�� ���� ����Ȯ��
    public GameObject TitleCard;
    public GameObject WindowBlack;
    int Title_flag = 0;
    //�̵� ����
    Animator anim;
    public float Speed;
    Rigidbody2D rigid;
    float h;
    float v;
    //1. Home 2. Dungeon 3. Tree 4. Shop 5. Botanic
    int Tag_Num = 0;//������ ��ȣ �ۿ� ���ΰ�.
    //Apple�� ��ȭ��
    int AppleNpc_Page = 0;
    bool AppleNpc_ZkeyStay = false;//zŰ �Է� ���� �����϶�
    bool isHorizonMove = true;
    bool AppleNpc_Talk = false;//��ȭ ������ �Ǻ�
    //zŰ �̺�Ʈ
    public GameObject Zkey;
    Vector3 dirVec;//ĳ���Ͱ� ���¹���

    //�ӽ� �ؽ�Ʈ ����
    public GameObject Text1_1;
    public GameObject Text1_2;
    public GameObject Text1_3;


    //GameObject scanObject;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //���� �� ��ȯ
        if (Input.GetKeyUp(KeyCode.Z)&&Tag_Num!=0&&Title_flag==0)
        {
            Ask_Title();//���� ����Ȯ��
        }
        //�� ��ȯ�� ����� ����
        if(Title_flag==10)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (Tag_Num == 1)
                    SceneManager.LoadScene("TestScene");//��
                else if (Tag_Num == 2)
                    SceneManager.LoadScene("TestScene");//����
                else if (Tag_Num == 3)
                    SceneManager.LoadScene("TestScene");//Ʈ��
                else if (Tag_Num == 4)
                    SceneManager.LoadScene("TestScene");//��
                else if (Tag_Num == 5)
                    SceneManager.LoadScene("TestScene");//����
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TitleCard.SetActive(false);
                WindowBlack.SetActive(false);
                isHorizonMove = true;
                Title_flag = 1;
            }
        }
        //npc�� ��ȣ�ۿ�
        if (AppleNpc_Talk == false && AppleNpc_ZkeyStay == true && (Input.GetKeyDown(KeyCode.Z)))
        {
            AppleNpc_Talk = true;
            isHorizonMove = false;
            if (AppleNpc_Page == 0)
            {
                Text1_1.SetActive(true);
                Text1_2.SetActive(true);
                Text1_3.SetActive(true);
            }
        }
        if (AppleNpc_Talk = true && AppleNpc_Page == 0 && (Input.GetKeyDown(KeyCode.RightArrow))&& Tag_Num==0)
        {
            Text1_1.SetActive(false);
            Text1_2.SetActive(false);
            Text1_3.SetActive(false);
            isHorizonMove = true;
            AppleNpc_Talk = false;
        }
        //�̵�
        if (isHorizonMove)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");


            //�ִϸ��̼�
            if (anim.GetInteger("hAxisRaw") != h)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }
            else if (anim.GetInteger("vAxisRaw") != v)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else
                anim.SetBool("isChange", false);

            if (h == -1)
                transform.localScale = new Vector3(-1.6f, 1.6f, 1.6f);
            if (h == 1)
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);

            if (v == 1)
                dirVec = Vector3.up;
            else if (v == -1)
                dirVec = Vector3.down;
            else if (h == -1)
                dirVec = Vector3.left;
            else if (h == 1)
                dirVec = Vector3.right;
        }
        /*
        //Scan Object
        if (Input.GetButtonDown("Jump")&&scanObject != null)
            Debug.Log("This is:" + scanObject.name);
        */

    }
    void FixedUpdate()
    {

        rigid.velocity = new Vector2(h, v) * Speed;

        /*
        //�չ�ü ����
        Debug.DrawRay(rigid.position, dirVec, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f,LayerMask.GetMask("NPC"));
        if (rayHit.collider != null)
        {
            Debug.Log("11");
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
        */
    }
    //Apple Npc
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Zkey")
        {
            AppleNpc_ZkeyStay = true;
            Zkey.SetActive(true);
        }
        if (collision.gameObject.tag == "Home")
        {
            Zkey.SetActive(true);
            Tag_Num = 1;
        }
        if (collision.gameObject.tag == "Dungeon")
        {
            Zkey.SetActive(true);
            Tag_Num = 2;
        }
        if (collision.gameObject.tag == "Tree")
        {
            Zkey.SetActive(true);
            Tag_Num = 3;
        }
        if (collision.gameObject.tag == "Shop")
        {
            Zkey.SetActive(true);
            Tag_Num = 4;
        }
        if (collision.gameObject.tag == "Botanic")
        {
            Zkey.SetActive(true);
            Tag_Num = 5;
        }
        Debug.Log(Tag_Num);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zkey")
        {
            AppleNpc_ZkeyStay = false;
            Zkey.SetActive(false);
        }
        if (collision.gameObject.tag == "Home" ||
            collision.gameObject.tag == "Dungeon" ||
            collision.gameObject.tag == "Tree" ||
            collision.gameObject.tag == "Shop" ||
            collision.gameObject.tag == "Botanic")
        {
            Zkey.SetActive(false);
            Tag_Num = 0;
            Title_flag = 0;
        }

    }
    void Ask_Title()//���� ����Ȯ��
    {
        TitleCard.SetActive(true);
        WindowBlack.SetActive(true);
        isHorizonMove = false;
        Title_flag = 10;
    }
}
