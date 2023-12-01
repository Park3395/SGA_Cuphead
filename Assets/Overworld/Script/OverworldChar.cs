using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OverworldChar : MonoBehaviour
{
    int OpenRoadOn = 0;
    public GameObject OpenRoad;
    //씬 변경 여부확인
    public GameObject TitleCard;
    public GameObject TitleCard2;
    public GameObject WindowBlack;
    //클리어 여부 확인 10= 클리어
    public GameObject Flag_Dungeon;
    public GameObject Flag_Tree;
    public GameObject Flag_Botanic;
    int Clear_Dungeon = 0;
    int Clear_Tree = 0;
    int Clear_Botanic = 0;
    int Clear_Score = 0;
    //Esc메뉴
    public GameObject EscMenu;
    public Text RETURN;
    public Text OPTIONS;
    public Text EXIT;
    int Sellect_Esc=0;
    bool EscFlag = false;
    //Iris On Off
    public GameObject IrisOn;
    public GameObject IrisOff;
    int Title_flag = 0;
    //이동 관련
    Animator anim;
    public float Speed;
    Rigidbody2D rigid;
    float h;
    float v;
    //1. Home 2. Dungeon 3. Tree 4. Shop 5. Botanic 12.상점 컨트롤 상태 13.esc상태
    int Tag_Num = 0;//무엇과 상호 작용 중인가.
    //상점 스크립트 불러오기
    public GameObject Shop_obj;
    //상점 관련
    int Shop_Num = -1;
    public GameObject Shop;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject LeftDoorObj;
    bool shop_Input = false;//상점 들어갔을 때 바로 입력 하는거 방지
    //Apple과 대화중
    int AppleNpc_Page = 0;
    bool AppleNpc_ZkeyStay = false;//z키 입력 가능 지역일때
    bool isHorizonMove = true;
    bool AppleNpc_Talk = false;//대화 중인지 판별
    //z키 이벤트
    public GameObject Zkey;
    Vector3 dirVec;//캐릭터가 보는방향
    //카메라
    public GameObject CameraObj;

    //임시 텍스트 구현
    public GameObject Text1_1;
    public GameObject Text1_2;
    public GameObject Text1_3;
    public GameObject Text2_1;
    public GameObject Text2_2;
    public GameObject Text2_3;
    int Delay_Flag = 0;

    //GameObject scanObject;

    private void Awake()
    {
        PlayerPrefs.SetInt("OpenTitle", 1);//타이틀을 한번이라도 열었는지 체크
        PlayerPrefs.Save();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        load();
    }
    private void Start()
    {
        Invoke("IrisOn_Start", 1.25f); //검은화면 오픈 애니메이션
    }
    void Update()
    {
        if (OpenRoadOn == 0 && Clear_Dungeon==5)
        {
            OpenRoadOn = 1;
        }
        if (OpenRoadOn == 1)
        {
            OpenRoad.SetActive(true);
            OpenRoadOn = 2;
        }
        //입장 씬 전환
        if (Input.GetKeyUp(KeyCode.Z)&&Tag_Num!=0&&Title_flag==0)
        {
             Ask_Title();//입장 여부확인
        }
        if(Tag_Num==12)
        {
            //상점 컨트롤러
            Shop_Control();
        }
        //ESC메뉴
        if(isHorizonMove==true&& Input.GetKeyDown(KeyCode.Escape)&& EscFlag==false)
        {
            Invoke("Esc_Flag", 0.3f);
            isHorizonMove = false;
            EscMenu.SetActive(true);
            Tag_Num = 13;
        }
        if(Tag_Num==13)
        {
            if (Sellect_Esc == 0)
            {
                RETURN.text = "<color=\"red\">계속하기</color>";
                OPTIONS.text = "타이틀로 가기";
                EXIT.text = "끝내기";
            }
            else if (Sellect_Esc == 1)
            {
                RETURN.text = "계속하기";
                OPTIONS.text = "<color=\"red\">타이틀로 가기</color>";
                EXIT.text = "끝내기";
            }
            else if (Sellect_Esc == 2)
            {
                RETURN.text = "계속하기";
                OPTIONS.text = "타이틀로 가기";
                EXIT.text = "<color=\"red\">끝내기</color>";
            }
        }
        if(Tag_Num==13&&Input.GetKeyDown(KeyCode.UpArrow))
        {
            Sellect_Esc--;
        }
        else if (Tag_Num == 13 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Sellect_Esc++;
        }
        if (Sellect_Esc > 2)
            Sellect_Esc = 0;
        else if (Sellect_Esc < 0)
            Sellect_Esc = 2;
        //ESC-ENTER 이벤트
        if(Tag_Num==13&&(Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.Z))&&Sellect_Esc==0)
        {
            Sellect_Esc = 0;
            isHorizonMove = true;
            EscMenu.SetActive(false);
            Tag_Num = 0;
            EscFlag = false;
        }
        else if (Tag_Num == 13 && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z)) && Sellect_Esc == 1)
        {
            Save();
            SceneManager.LoadScene("StartScene");//타이틀로
        }
        else if (Tag_Num == 13 && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z)) && Sellect_Esc == 2)
        {
            Save();
            Application.Quit();
        }
        //ESC-ESC 이벤트
        if (Tag_Num==13&&Input.GetKeyDown(KeyCode.Escape)&& EscFlag==true)
        {
            Sellect_Esc = 0;
            isHorizonMove = true;
            EscMenu.SetActive(false);
            Tag_Num = 0;
            EscFlag = false;
        }
        //씬 전환을 물어보는 상태
        if (Title_flag==10)
        {

            if (Input.GetKeyDown(KeyCode.Z)||Input.GetKeyDown(KeyCode.Return))
            {
                if (Tag_Num == 1)
                    SceneManager.LoadScene("SampleSceneY");//집
                else if (Tag_Num == 2)
                    SceneManager.LoadScene("TestScene");//던전
                else if (Tag_Num == 3)
                    SceneManager.LoadScene("TestScene");//트리
                else if (Tag_Num == 4)
                {
                    Shop_Event();
                }
                else if (Tag_Num == 5)
                    SceneManager.LoadScene("TestScene");//농장
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Tag_Num == 2)
                {
                    Flag_Dungeon.SetActive(true);
                    Clear_Dungeon = 5;
                }
                else if (Tag_Num == 3)
                {
                    
                    Flag_Tree.SetActive(true);
                    Clear_Tree = 6;
                }
                else if (Tag_Num == 5)
                {
                    Flag_Botanic.SetActive(true);
                    Clear_Botanic = 7;
                }
                TitleCard2.SetActive(false);
                WindowBlack.SetActive(false);
                isHorizonMove = true;
                Title_flag = 1;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TitleCard.SetActive(false);
                TitleCard2.SetActive(false);
                WindowBlack.SetActive(false);
                isHorizonMove = true;
                Title_flag = 1;
            }
        }
        //npc와 상호작용
        if (AppleNpc_Page==0&&Delay_Flag == 0&&AppleNpc_Talk == false && AppleNpc_ZkeyStay == true && (Input.GetKeyDown(KeyCode.Z)))
        {
            AppleNpc_Talk = true;
            isHorizonMove = false;
            if (AppleNpc_Page == 0)
            {
                Text1_1.SetActive(true);
                Text1_2.SetActive(true);
                Text1_3.SetActive(true);
                AppleNpc_Page++;
                Delay_Flag = 1;
                Invoke("DelayFlag", 0.5f);
            }
            
        }
        else if (AppleNpc_Page==1&&Delay_Flag == 0 && AppleNpc_Talk == true && 
            (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Z)))
        {
            if (AppleNpc_Page == 1)
            {
                Text1_1.SetActive(false);
                Text1_2.SetActive(false);
                Text1_3.SetActive(false);
            }
            if (AppleNpc_Page == 1)
            {
                Text2_1.SetActive(true);
                Text2_2.SetActive(true);
                Text2_3.SetActive(true);
                AppleNpc_Page++;
                Delay_Flag = 1;
                Invoke("DelayFlag", 0.5f);
            }
        }
        
        if (AppleNpc_Page==2 && (Input.GetKeyDown(KeyCode.RightArrow)||
            Input.GetKeyDown(KeyCode.Z)) && Tag_Num == 0&&Delay_Flag == 0)
        {
            Text2_1.SetActive(false);
            Text2_2.SetActive(false);
            Text2_3.SetActive(false);
            isHorizonMove = true;
            AppleNpc_Talk = false;
            AppleNpc_Page = 0;
        }
        //이동
        if (isHorizonMove)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");


            //애니메이션
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
            {
                Zkey.transform.localScale = new Vector3(-0.67f, 0.67f, 0.67f);
                transform.localScale = new Vector3(-1.35f, 1.35f, 1.35f);
                CameraObj.transform.localScale = new Vector3(-0.62f, 0.62f, 0.62f);
                EscMenu.transform.localScale = new Vector3(-1.0f, 0.7f, 0.74f);
            }
            if (h == 1)
            {
                Zkey.transform.localScale = new Vector3(0.67f, 0.67f, 0.67f);
                transform.localScale = new Vector3(1.35f, 1.35f, 1.35f);
                CameraObj.transform.localScale = new Vector3(0.62f, 0.62f, 0.62f);
                EscMenu.transform.localScale = new Vector3(1.0f, 0.7f, 0.74f);
            }

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
    void Esc_Flag()
    {
        EscFlag = true;
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
    void Ask_Title()//입장 여부확인
    {
        if (Tag_Num == 1 || Tag_Num == 4)
            TitleCard.SetActive(true);
        else
            TitleCard2.SetActive(true);
        WindowBlack.SetActive(true);
        isHorizonMove = false;
        Title_flag = 10;
    }
    void Shop_Event()
    {
        TitleCard.SetActive(false);
        IrisOff.SetActive(true);
        Invoke("Shop_Event1", 2.0f);
    }
    void Shop_Event1()
    {
        IrisOn.SetActive(true);
        IrisOff.SetActive(false);
        Shop.SetActive(true);
        Invoke("Shop_Event2", 2.0f);
    }
    void Shop_Event2()
    {
        IrisOn.SetActive(false);
        Tag_Num = 12;
        Shop_obj.GetComponent<ShopAnimeM>().Shop_Idle();
        Invoke("Shop_Idle_Control", 1.98f);
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
        shop_Input = true;
    }
    void Shop_Control()
    {
        if (shop_Input == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && Shop_Num < 5)
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
            if (Input.GetKeyDown(KeyCode.LeftArrow) && Shop_Num > 1)
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
        }
        
        //상점 나가기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Shop_obj.GetComponent<ShopAnimeM>().Shop_Exit();
            LeftDoorObj.GetComponent<LeftDoor>().Close();
            Invoke("Shop_Exit_Event_Delay", 2.0f);
        }
    }
    void Shop_Exit_Event_Delay()
    {
        Item1.GetComponent<ItemM>().Item_UnSellect();
        Item2.GetComponent<ItemM>().Item_UnSellect();
        Item3.GetComponent<ItemM>().Item_UnSellect();
        Item4.GetComponent<ItemM>().Item_UnSellect();
        Item5.GetComponent<ItemM>().Item_UnSellect();
        IrisOff.SetActive(true);
        Invoke("Shop_Exit_Event", 2.0f);
    }
    void Shop_Exit_Event()
    {
        IrisOn.SetActive(true);
        IrisOff.SetActive(false);
        Tag_Num = 0;
        Shop_Num = 0;
        shop_Input = false;
        Shop.SetActive(false);
        Invoke("Shop_Exit_Event2", 1.5f);
    }
    void DelayFlag()
    {
        Delay_Flag = 0;
    }
    void Shop_Exit_Event2()
    {
        IrisOn.SetActive(false);
    }
    void IrisOn_Start()
    {
        IrisOn.SetActive(false);
    }
    void Save()
    {
        /*
         * 
         * SaveFileNum==1   첫번째 세이브 파일 내용
         * SaveFileNum==2   두번째 세이브 파일 내용
         * SaveFileNum==3   세번째 세이브 파일 내용
         * 게임 입장시 몇번째 세이브 파일인지 구분하며 세이브 파일이 1일때 Clear_Dungeon1,Clear_Tree1,Clear_Botanic1의 클리어 점수를 갱신하게 되며 각각 클리어시 5,6,7점 얻는다..
         * 또한 오버월드 시작시 첫번째 세이브 파일에 접속시 Clear_Dungeon1이 5점이면 이를 기반으로 깃발이벤트가 발생하여 Clear_Dungeon1은 클리어 된 상태로 로드되게된다.
         * 만약 Clear_Dungeon1이 클리어 됬다면 해당 세이브 파일일 경우(SaveFileNum==1이 첫번째 세이브파일 )Clear_Dungeon1는 5점Clear_Tree1=6점Clear_Botanic1=7점을 주면 되는데
         * 그렇게 되면 오버월드 씬이 열렸을때 load()를하면서 깃발이 열립니다.
         */
        Clear_Score = Clear_Dungeon + Clear_Tree + Clear_Botanic;
        if (PlayerPrefs.GetInt("SaveFileNum") == 1)
        {
            PlayerPrefs.SetInt("Clear_Dungeon1", Clear_Dungeon);
            PlayerPrefs.SetInt("Clear_Tree1", Clear_Tree);
            PlayerPrefs.SetInt("Clear_Botanic1", Clear_Botanic);
            PlayerPrefs.SetInt("Clear_Score1", Clear_Score);
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 2)
        {
            PlayerPrefs.SetInt("Clear_Dungeon2", Clear_Dungeon);
            PlayerPrefs.SetInt("Clear_Tree2", Clear_Tree);
            PlayerPrefs.SetInt("Clear_Botanic2", Clear_Botanic);
            PlayerPrefs.SetInt("Clear_Score2", Clear_Score);
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 3)
        {
            PlayerPrefs.SetInt("Clear_Dungeon3", Clear_Dungeon);
            PlayerPrefs.SetInt("Clear_Tree3", Clear_Tree);
            PlayerPrefs.SetInt("Clear_Botanic3", Clear_Botanic);
            PlayerPrefs.SetInt("Clear_Score3", Clear_Score);
        }
        PlayerPrefs.Save();
    }
    void load()
    {
        if (PlayerPrefs.GetInt("SaveFileNum")==1)
        {
            if (!PlayerPrefs.HasKey("Clear_Dungeon1"))
                return;
            else
                this.transform.position = new Vector3(15.0f, -1.0f, 0.0f);//세이브 파일이 있으면 시작위치 변경
            if (PlayerPrefs.GetInt("Clear_Dungeon1")==5)
            {
                Flag_Dungeon.SetActive(true);
                Clear_Dungeon = 5;
            }
            if (PlayerPrefs.GetInt("Clear_Tree1") == 6)
            {
                Flag_Tree.SetActive(true);
                Clear_Tree = 6;
            }
            if (PlayerPrefs.GetInt("Clear_Botanic1") == 7)
            {
                Flag_Botanic.SetActive(true);
                Clear_Botanic = 7;
            }
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 2)
        {
            if (!PlayerPrefs.HasKey("Clear_Dungeon2"))
                return;
            else
                this.transform.position = new Vector3(15.0f, -1.0f, 0.0f);//세이브 파일이 있으면 시작위치 변경
            if (PlayerPrefs.GetInt("Clear_Dungeon2") == 5)
            {
                Flag_Dungeon.SetActive(true);
                Clear_Dungeon = 5;
            }
            if (PlayerPrefs.GetInt("Clear_Tree2") == 6)
            {
                Flag_Tree.SetActive(true);
                Clear_Tree = 6;
            }
            if (PlayerPrefs.GetInt("Clear_Botanic2") == 7)
            {
                Flag_Botanic.SetActive(true);
                Clear_Botanic = 7;
            }
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 3)
        {
            if (!PlayerPrefs.HasKey("Clear_Dungeon3"))
                return;
            else
                this.transform.position = new Vector3(15.0f, -1.0f, 0.0f);//세이브 파일이 있으면 시작위치 변경

            if (PlayerPrefs.GetInt("Clear_Dungeon3") == 5)
            {
                Flag_Dungeon.SetActive(true);
                Clear_Dungeon = 5;
            }
            if (PlayerPrefs.GetInt("Clear_Tree3") == 6)
            {
                Flag_Tree.SetActive(true);
                Clear_Tree = 6;
            }
            if (PlayerPrefs.GetInt("Clear_Botanic3") == 7)
            {
                Flag_Botanic.SetActive(true);
                Clear_Botanic = 7;
            }
        }
    }
}

