using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuM : MonoBehaviour
{
    
    public GameObject IrisOn;
    //������ ����â
    public Text Yes;
    public Text No;
    public GameObject DataDelete_Window;
    int Shift_Flag = 0;
    int Shift_Sellect = 0;
    //���� �޴� �ؽ�Ʈ
    public Text START;
    public Text OPTIONS;
    public Text DLC;
    public Text EXIT;
    public Text NEW1;//SAVE1
    public Text NEW2;//SAVE2
    public Text NEW3;//SAVE3
    //�ɼ� �޴� �ؽ�Ʈ
    public Text AUDIO;
    public Text VISUAL;
    public Text CONTROLS;
    public Text Back;
    //DLC â
    public GameObject DLC_Screen;
    //�ι�° �޴� �������̽� �̹���
    public GameObject OptionsWindow;
    //��Ʈ�� ��ǲ ������
    public GameObject ControlWindow;
    //ù��° �޴� �������̽� �̹���
    public GameObject WindowboxBackground;
    public GameObject Windowbox1;
    public GameObject Windowboxtl1;
    public GameObject Windowbox2;
    public GameObject Windowboxtl2;
    public GameObject Windowbox3;
    public GameObject Windowboxtl3;
    //���° �ε�� ��������
    public GameObject WindowStart1;
    public GameObject WindowStart2;
    public GameObject WindowStart3;
    //����
    public AudioSource MenuSellect;
    public AudioSource OptionsSellect;
    public AudioSource Reddy;
    public AudioSource StartSellect;

    public AudioSource IntroSound;
    int WindowStart = 0;//SellectNumber
    int DelayFlag = 1;//enter ���Ӵ�������
    int Clear_Score1 = 0;
    int Clear_Score2 = 0;
    int Clear_Score3 = 0;

    //����â���� Ű���������� �޴��� �ѹ��� ������Ѿ������� Ÿ��Ʋ�� ���ƿý� controlâ�� �����Ѵ�
    //�̴� Awake���� ���� �������� ���� 2�� ����� �����ش�.

    //Now_Page 0=���� �޴� 1=ù��° �޴� 10=ù��° �޴� ���Խ� �̺�Ʈ
    int Now_Page = 0;
    int Sellect_Button = -1; //���۸޴� ���Ʒ�Ű �̺�Ʈ �÷���
    int Sellect_Start = -1; //ù��° �޴� ���Ʒ�Ű �̺�Ʈ �÷���
    int Sellect_Options = -1;//�ι�° �޴� ���Ʒ�Ű �̺�Ʈ�÷���
    private void Awake()
    {
        if (PlayerPrefs.GetInt("OpenTitle") == 1)//�ѹ��̶� Ÿ��Ʋ�� ���ƴٸ� �������� ����.
        {
            ControlWindow.SetActive(false);
            PlayerPrefs.DeleteKey("OpenTitle");
        }
        Sellect_Menu(0);
        PlayerPrefs.SetInt("SaveFileNum1", 0);
        PlayerPrefs.SetInt("SaveFileNum2", 0);
        PlayerPrefs.SetInt("SaveFileNum3", 0);
    }
    private void Start()
    {
        IntroSound.Play();
        Invoke("IrisOpenFun", 1.2f);
        ControlWindow.SetActive(false);
    }
    void Update()
    {
        
        //���� �غ񿡼� ����
        if (WindowStart == 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            MenuSellect.Play();
            WindowStart = 0;
            WindowStart1.SetActive(false);
            Invoke("DelayFlag_", 0.5f);
        }
        else if (WindowStart == 2 && Input.GetKeyDown(KeyCode.Escape))
        {
            MenuSellect.Play();
            WindowStart = 0;
            WindowStart2.SetActive(false);
            Invoke("DelayFlag_", 0.5f);
        }
        else if (WindowStart == 3 && Input.GetKeyDown(KeyCode.Escape))
        {
            MenuSellect.Play();
            WindowStart = 0;
            WindowStart3.SetActive(false);
            Invoke("DelayFlag_", 0.5f);
        }
        //���� �޴�
        if (Now_Page == 0)
        {
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                OptionsSellect.Play();
                Sellect_Menu(0);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                OptionsSellect.Play();
                Sellect_Menu(1);
            }
        }
        //ù��° �޴� ��ŸƮ
        else if ((Now_Page == 1 || Now_Page == 10) && WindowStart == 0)
        {
            
            if (Input.GetKeyDown(KeyCode.DownArrow) || Now_Page == 10)
            {
                OptionsSellect.Play();
                StartMenu(0);
            }
                
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                OptionsSellect.Play();
                StartMenu(1);
            }
                
        }
        //�ι�° �޴� �ɼ�
        else if (Now_Page == 2 || Now_Page == 11)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Now_Page == 11)
                OptionsMenu(0);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                OptionsMenu(1);
        }
        //Shift �̺�Ʈ
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MenuSellect.Play();
            if (Now_Page == 1 && Sellect_Start == 0)
            {
                DataDelete_Window.SetActive(true);
                Shift_Flag = 1;
                
            }
            else if (Now_Page == 1 && Sellect_Start == 1)
            {
                DataDelete_Window.SetActive(true);
                Shift_Flag = 1;
            }
            else if (Now_Page == 1 && Sellect_Start == 2)
            {
                DataDelete_Window.SetActive(true);
                Shift_Flag = 1;
            }
        }
        //����â���� Yes No����
        if (Shift_Flag == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && Shift_Sellect == 0)
            {
                OptionsSellect.Play();
                Shift_Sellect++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && Shift_Sellect == 1)
            {
                OptionsSellect.Play();
                Shift_Sellect--;
            }
        }
        //���� ����â
        if (Shift_Flag == 1)
        {
            if (Shift_Sellect == 0)
            {
                Yes.text = "<color=\"red\">Yes</color>";
                No.text = "No";
            }
            else if (Shift_Sellect == 1)
            {
                Yes.text = "Yes";
                No.text = "<color=\"red\">No</color>";
            }
        }
        
        //���� �̺�Ʈ
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
        {
            
            //�� ��ŸƮ
            if (DelayFlag == 1 && Clear_Score1 == -1 && WindowStart == 1)
            {
                Reddy.Play();
                IntroSound.Stop();
                PlayerPrefs.SetInt("SaveFileNum", 1);
                SceneManager.LoadScene("BookScene");
            }
            else if (DelayFlag == 1 && Clear_Score2 == -1 && WindowStart == 2)
            {
                Reddy.Play();
                IntroSound.Stop();
                PlayerPrefs.SetInt("SaveFileNum", 2);
                SceneManager.LoadScene("BookScene");
            }
            else if (DelayFlag == 1 && Clear_Score3 == -1 && WindowStart == 3)
            {
                Reddy.Play();
                IntroSound.Stop();
                PlayerPrefs.SetInt("SaveFileNum", 3);
                SceneManager.LoadScene("BookScene");
            }

            //���� �ε�
            if (Clear_Score1 >= 0 && DelayFlag == 1 && WindowStart == 1)
            {
                Reddy.Play();
                IntroSound.Stop();
                PlayerPrefs.SetInt("SaveFileNum", 1);
                SceneManager.LoadScene("OverWorld");
            }
            else if (Clear_Score1 >= 0 && DelayFlag == 1 && WindowStart == 2)
            {
                Reddy.Play();
                IntroSound.Stop();
                PlayerPrefs.SetInt("SaveFileNum", 2);
                SceneManager.LoadScene("OverWorld");
            }
            else if (Clear_Score1 >= 0 && DelayFlag == 1 && WindowStart == 3)
            {
                Reddy.Play();
                IntroSound.Stop();
                PlayerPrefs.SetInt("SaveFileNum", 3);
                SceneManager.LoadScene("OverWorld");
            }
            //���� �غ� â
            if (DelayFlag == 1 && Now_Page == 1 && Sellect_Start == 0&& WindowStart==0&&Shift_Flag==0)
            {
                MenuSellect.Play();
                DelayFlag = 0;
                WindowStart1.SetActive(true);
                WindowStart = 1;
                Invoke("DelayFlag_", 0.5f);
            }
            else if (DelayFlag == 1 && Now_Page == 1 && Sellect_Start == 1 && WindowStart == 0 && Shift_Flag == 0)
            {
                MenuSellect.Play();
                DelayFlag = 0;
                WindowStart2.SetActive(true);
                WindowStart = 2;
                Invoke("DelayFlag_", 0.5f);
            }
            else if (DelayFlag == 1 && Now_Page == 1 && Sellect_Start == 2 && WindowStart == 0 && Shift_Flag == 0)
            {
                MenuSellect.Play();
                DelayFlag = 0;
                WindowStart3.SetActive(true);
                WindowStart = 3;
                Invoke("DelayFlag_", 0.5f);
            }
            //���� Yes No
            if (Shift_Sellect==0&& Shift_Flag==1)
            {
                MenuSellect.Play();
                Shift_Flag = 0;
                DataDelete_Window.SetActive(false);

                if(Sellect_Start==0)
                {
                    NEW1.text = "<color=\"White\">NEW</color>";
                    PlayerPrefs.DeleteKey("Clear_Dungeon1");
                    PlayerPrefs.DeleteKey("Clear_Tree1");
                    PlayerPrefs.DeleteKey("Clear_Botanic1");
                    PlayerPrefs.DeleteKey("Clear_Score1");
                    PlayerPrefs.DeleteKey("Spread1");
                    PlayerPrefs.DeleteKey("Heart1");
                }
                else if (Sellect_Start == 1)
                {
                    NEW2.text = "<color=\"White\">NEW</color>";
                    PlayerPrefs.DeleteKey("Clear_Dungeon2");
                    PlayerPrefs.DeleteKey("Clear_Tree2");
                    PlayerPrefs.DeleteKey("Clear_Botanic2");
                    PlayerPrefs.DeleteKey("Clear_Score2");
                    PlayerPrefs.DeleteKey("Spread2");
                    PlayerPrefs.DeleteKey("Heart2");
                }
                else if (Sellect_Start == 2)
                {
                    NEW3.text = "<color=\"White\">NEW</color>";
                    PlayerPrefs.DeleteKey("Clear_Dungeon3");
                    PlayerPrefs.DeleteKey("Clear_Tree3");
                    PlayerPrefs.DeleteKey("Clear_Botanic3");
                    PlayerPrefs.DeleteKey("Clear_Score3");
                    PlayerPrefs.DeleteKey("Spread3");
                    PlayerPrefs.DeleteKey("Heart3");
                }
                DelayFlag = 0;
                Invoke("DelayFlag_", 0.6f);
                Shift_Sellect = 0;
            }
            else if (Shift_Sellect == 1)
            {
                DelayFlag = 0;
                Shift_Flag = 0;
                Invoke("DelayFlag_", 0.6f);
                DataDelete_Window.SetActive(false);
                Shift_Sellect = 0;
            }

            //Start ��
            if (Now_Page == 0 && Sellect_Button == 0)
                {
                MenuSellect.Play();
                Sellect_Start = -1;
                    Now_Page = 10;
                }
                //�ɼ� ��
                if (Now_Page == 0 && Sellect_Button == 1)
                {
                MenuSellect.Play();
                Sellect_Options = -1;
                    Now_Page = 11;
                }
                //DLC
                if (Now_Page == 0 && Sellect_Button == 2)
                {
                    MenuSellect.Play();
                    Now_Page = 12;
                    DLC_Screen.SetActive(true);
                }
            if (Now_Page == 0 && Sellect_Button == 3)
            {
                Application.Quit();
            }
            //�ɼǿ��� �������� �ǵ��ư���
            if (Now_Page == 2 && Sellect_Options == 3)
                {
                MenuSellect.Play();
                AUDIO.text = "";
                    VISUAL.text = "";
                    CONTROLS.text = "";
                    Back.text = "";
                    OptionsWindow.SetActive(false);
                    Now_Page = 0;
                    Sellect_Button = 0;
                    Sellect_Menu(0);
                }
                //Controllsâ �������̽� ����
                if (Now_Page == 2 && Sellect_Options == 2)
                {
                MenuSellect.Play();
                Input_Change();
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape) && DelayFlag == 1)
            {
            MenuSellect.Play();
            if (Shift_Flag == 1)
            {
                    DataDelete_Window.SetActive(false);
                    Shift_Flag = 0;
                    Invoke("DelayFlag_", 0.5f);
            }
                if (Now_Page == 13)
                {
                    Sellect_Options = -1;
                    ControlWindow.SetActive(false);
                    Now_Page = 11;
                    Invoke("DelayFlag_", 0.5f);
                }
                if (Now_Page == 1 && WindowStart == 0)
                {
                    NEW1.text = "";
                    NEW2.text = "";
                    NEW3.text = "";
                    START.text = "START";
                    OPTIONS.text = "OPTIONS";
                    DLC.text = "DLC";
                    EXIT.text = "EXIT";
                    WindowboxBackground.SetActive(false);
                    Windowboxtl1.SetActive(false);
                    Windowboxtl2.SetActive(false);
                    Windowboxtl3.SetActive(false);
                    Windowbox1.SetActive(false);
                    Windowbox2.SetActive(false);
                    Windowbox3.SetActive(false);
                    Now_Page = 0;
                    Sellect_Button = -1;
                    Sellect_Menu(0);
                }
                if (Now_Page == 2)
                {
                
                    AUDIO.text = "";
                    VISUAL.text = "";
                    CONTROLS.text = "";
                    Back.text = "";
                    OptionsWindow.SetActive(false);
                    Now_Page = 0;
                    Sellect_Button = 0;
                    Sellect_Menu(0);
                }
                //DLC���� ����â����
                if (Now_Page == 12)
                {
                
                DLC_Screen.SetActive(false);
                    Now_Page = 0;
                    Sellect_Button = 1;
                    Sellect_Menu(0);
                }
            
        }
    }
    void Input_Change()
    {
        Now_Page = 13;
        ControlWindow.SetActive(true);
    }
    void OptionsMenu(int updown)
    {
        OptionsSellect.Play();
        if (Now_Page == 11)
        {
            START.text = "";
            OPTIONS.text = "";
            DLC.text = "";
            EXIT.text = "";

            AUDIO.text = "<color=\"red\">AUDIO</color>";
            VISUAL.text = "VISUAL";
            CONTROLS.text = "CONTROLS";
            Back.text = "Back";
            Sellect_Start--;
            OptionsWindow.SetActive(true);
            Now_Page = 2;
        }

        if (updown == 0)
            Sellect_Options++;
        else
            Sellect_Options--;


        if (Sellect_Options > 3)
            Sellect_Options = 0;
        else if (Sellect_Options < 0)
            Sellect_Options = 3;
        if (Sellect_Options == 0)
        {
            if (updown == 0)
                Back.text = "BACK";
            else if (updown == 1)
                VISUAL.text = "VISUAL";
            AUDIO.text = "<color=\"red\">AUDIO</color>";
        }
        else if (Sellect_Options == 1)
        {
            if (updown == 0)
                AUDIO.text = "AUDIO";
            else if (updown == 1)
                CONTROLS.text = "CONTROLS";
            VISUAL.text = "<color=\"red\">VISUAL</color>";
        }
        else if (Sellect_Options == 2)
        {
            if (updown == 0)
                VISUAL.text = "VISUAL";
            else if (updown == 1)
                Back.text = "BACK";
            CONTROLS.text = "<color=\"red\">CONTROLS</color>";
        }
        else if (Sellect_Options == 3)
        {
            if (updown == 0)
                CONTROLS.text = "CONTROLS";
            else if (updown == 1)
                AUDIO.text = "AUDIO";
            Back.text = "<color=\"red\">BACK</color>";
        }
    }
    void StartMenu(int updown)
    {
        StartSellect.Play();
        if (PlayerPrefs.HasKey("Clear_Dungeon1"))
            Clear_Score1 = PlayerPrefs.GetInt("Clear_Score1");
        else
            Clear_Score1 = -1;
        if (PlayerPrefs.HasKey("Clear_Dungeon2"))
            Clear_Score2 = PlayerPrefs.GetInt("Clear_Score2");
        else
            Clear_Score2 = -1;
        if (PlayerPrefs.HasKey("Clear_Dungeon3"))
            Clear_Score3 = PlayerPrefs.GetInt("Clear_Score3");
        else
            Clear_Score3 = -1;
        if (Now_Page == 10)
        {
            START.text = "";
            OPTIONS.text = "";
            DLC.text = "";
            EXIT.text = "";

            WindowboxBackground.SetActive(true);
            Windowboxtl1.SetActive(true);
            Windowboxtl2.SetActive(true);
            Windowboxtl3.SetActive(true);
            Now_Page = 1;
        }
        if (updown == 0)
            Sellect_Start++;
        else
            Sellect_Start--;

        if (Sellect_Start > 2)
            Sellect_Start = 0;
        else if (Sellect_Start < 0)
            Sellect_Start = 2;

        if (Sellect_Start == 0)
        {
            Windowbox1.SetActive(true);
            Windowbox2.SetActive(false);
            Windowbox3.SetActive(false);
            if (!PlayerPrefs.HasKey("Clear_Dungeon1"))
                NEW1.text = "<color=\"White\">NEW</color>";
            else
                NEW1.text = "<color=\"Red\">���൵ : </color>" + Clear_Score1;
            if (!PlayerPrefs.HasKey("Clear_Dungeon2"))
                NEW2.text = "NEW";
            else
                NEW2.text = "<color=\"White\">���൵ : </color>" + Clear_Score2;
            if (!PlayerPrefs.HasKey("Clear_Dungeon3"))
                NEW3.text = "NEW";
            else
                NEW3.text = "<color=\"White\">���൵ : </color>" + Clear_Score3;
        }

        else if (Sellect_Start == 1)
        {
            Windowbox1.SetActive(false);
            Windowbox2.SetActive(true);
            Windowbox3.SetActive(false);
            if (!PlayerPrefs.HasKey("Clear_Dungeon2"))
                NEW2.text = "<color=\"White\">NEW</color>";
            else
                NEW2.text = "<color=\"Red\">���൵ : </color>" + Clear_Score2;
            if (!PlayerPrefs.HasKey("Clear_Dungeon1"))
                NEW1.text = "NEW";
            else
                NEW1.text = "<color=\"White\">���൵ : </color>" + Clear_Score1;
            if (!PlayerPrefs.HasKey("Clear_Dungeon3"))
                NEW3.text = "NEW";
            else
                NEW3.text = "<color=\"White\">���൵ : </color>" + Clear_Score3;
        }
        else if (Sellect_Start == 2)
        {
            Windowbox1.SetActive(false);
            Windowbox2.SetActive(false);
            Windowbox3.SetActive(true);
            if (!PlayerPrefs.HasKey("Clear_Dungeon3"))
                NEW3.text = "<color=\"White\">NEW</color>";
            else
                NEW3.text = "<color=\"Red\">���൵ : </color>" + Clear_Score3;
            if (!PlayerPrefs.HasKey("Clear_Dungeon1"))
                NEW1.text = "NEW";
            else
                NEW1.text = "<color=\"White\">���൵ : </color>" + Clear_Score1;
            if (!PlayerPrefs.HasKey("Clear_Dungeon2"))
                NEW2.text = "NEW";
            else
                NEW2.text = "<color=\"White\">���൵ : </color>" + Clear_Score2;
        }

    }
    void IrisOpenFun()
    {
        IrisOn.SetActive(false);
    }
    void DelayFlag_()
    {
        DelayFlag = 1;
    }
    void Sellect_Menu(int updown)
    {
        if (updown == 0)
            Sellect_Button++;
        else
            Sellect_Button--;

        if (Sellect_Button > 3)
            Sellect_Button = 0;
        else if (Sellect_Button < 0)
            Sellect_Button = 3;

        if (Sellect_Button == 0)
            START.text = "<color=\"White\">START</color>";
        else
            START.text = "START";

        if (Sellect_Button == 1)
            OPTIONS.text = "<color=\"White\">OPTIONS</color>";
        else
            OPTIONS.text = "OPTIONS";

        if (Sellect_Button == 2)
            DLC.text = "<color=\"White\">DLC</color>";
        else
            DLC.text = "DLC";

        if (Sellect_Button == 3)
            EXIT.text = "<color=\"White\">EXIT</color>";
        else
            EXIT.text = "EXIT";
    }
}