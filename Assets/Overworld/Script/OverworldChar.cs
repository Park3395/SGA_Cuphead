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
    //1. Home 2. Dungeon 3. Tree 4. Shop 5. Botanic 12.���� ��Ʈ�� ����
    int Tag_Num = 0;//������ ��ȣ �ۿ� ���ΰ�.
    //���� ��ũ��Ʈ �ҷ�����
    public GameObject Shop_obj;
    //���� ����
    int Shop_Num = -1;
    public GameObject Shop;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject LeftDoorObj;
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
        if(Tag_Num==12)
        {
            //���� ��Ʈ�ѷ�
            Shop_Control();
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
                {
                    Shop_Event();
                }
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
                transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            if (h == 1)
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            if (v == 1)
                dirVec = Vector3.up;
            else if (v == -1)
                dirVec = Vector3.down;
            else if (h == -1)
                dirVec = Vector3.left;
            else if (h == 1)
                dirVec = Vector3.right;
        }
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * Speed;
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
    void Shop_Event()
    {
        Shop.SetActive(true);
        TitleCard.SetActive(false);
        Tag_Num = 12;
        Invoke("Shop_Idle_Control", 1.3f);
    }
    void Shop_Idle_Control()
    {
        Item1.GetComponent<ItemM>().Item_Sellect();

        if (Shop_Num == -1)
        {
            Shop_Num = 1;
        }
        LeftDoorObj.GetComponent<LeftDoor>().P1();
        LeftDoorObj.GetComponent<LeftDoor>().Open();
        Shop_obj.GetComponent<ShopAnimeM>().Shop_Idle();
    }
    void Shop_Control()
    {
            if (Input.GetKeyDown(KeyCode.RightArrow)&&Shop_Num < 5)
            {
                Shop_Num++;
                if (Shop_Num == 1)
                {
                    Item5.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P1();
                    Item1.GetComponent<ItemM>().Item_Sellect();
                }
                else if (Shop_Num == 2)
                {
                    Item1.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P2();
                Item2.GetComponent<ItemM>().Item_Sellect();
                }
                else if (Shop_Num == 3)
                {
                    Item2.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P3();
                Item3.GetComponent<ItemM>().Item_Sellect();
                }
                else if (Shop_Num == 4)
                {
                    Item3.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P4();
                Item4.GetComponent<ItemM>().Item_Sellect();
                }
                else if (Shop_Num == 5)
                {
                    Item4.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P5();
                Item5.GetComponent<ItemM>().Item_Sellect();
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)&& Shop_Num > 1)
            {
                Shop_Num--;
                if (Shop_Num == 1)
                {
                    Item2.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P1();
                Item1.GetComponent<ItemM>().Item_Sellect();
                }
                else if (Shop_Num == 2)
                {
                    Item3.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P2();
                Item2.GetComponent<ItemM>().Item_Sellect();
                }
                else if (Shop_Num == 3)
                {
                    Item4.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P3();
                Item3.GetComponent<ItemM>().Item_Sellect();
                }
                else if (Shop_Num == 4)
                {
                    Item5.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P4();
                Item4.GetComponent<ItemM>().Item_Sellect();
                }
                else if (Shop_Num == 5)
                {
                    Item1.GetComponent<ItemM>().Item_UnSellect();
                LeftDoorObj.GetComponent<LeftDoor>().P5();
                Item5.GetComponent<ItemM>().Item_Sellect();
                }
            }
        
        //���� ������
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LeftDoorObj.GetComponent<LeftDoor>().Close();
            Tag_Num = 0;
            Shop_Num = 0;
            Shop.SetActive(false);
        }
    }
}
