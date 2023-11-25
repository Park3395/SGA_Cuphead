using System;
using System.Collections;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuM : MonoBehaviour
{
    //시작 메뉴 텍스트
    public Text START;
    public Text OPTIONS;
    public Text DLC;
    public Text EXIT;
    public Text NEW1;//SAVE1
    public Text NEW2;//SAVE2
    public Text NEW3;//SAVE3

    //옵션 메뉴 텍스트
    public Text AUDIO;
    public Text VISUAL;
    public Text CONTROLS;
    public Text Back;

    //두번째 메뉴 인터페이스 이미지
    public GameObject OptionsWindow;
    //첫번째 메뉴 인터페이스 이미지
    public GameObject WindowboxBackground;
    public GameObject Windowbox1;
    public GameObject Windowboxtl1;
    public GameObject Windowbox2;
    public GameObject Windowboxtl2;
    public GameObject Windowbox3;
    public GameObject Windowboxtl3;

    



    //Now_Page 0=시작 메뉴 1=첫번째 메뉴 10=첫번째 메뉴 진입시 이벤트
    int Now_Page = 0;
    int Sellect_Button = -1; //시작메뉴 위아래키 이벤트 플래그
    int Sellect_Start = -1; //첫번째 메뉴 위아래키 이벤트 플래그
    int Sellect_Options = -1;//두번째 메뉴 위아래키 이벤트플래그
    private void Awake()
    {
        Sellect_Menu(0);
    }
    void Update()
    {
        //시작 메뉴
        if (Now_Page == 0)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
                Sellect_Menu(0);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Sellect_Menu(1);
        }
        //첫번째 메뉴 스타트
        else if (Now_Page == 1 || Now_Page == 10)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Now_Page == 10)
                StartMenu(0);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                StartMenu(1);
        }
        //두번째 메뉴 옵션
        else if (Now_Page == 2 || Now_Page == 11)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Now_Page == 11)
                OptionsMenu(0);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                OptionsMenu(1);
        }
        //엔터 이벤트
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (Now_Page == 0 && Sellect_Button == 0)
            {
                Now_Page = 10;
            }
            if (Now_Page == 0 && Sellect_Button == 1)
            {
                Now_Page = 11;
            }
            if (Now_Page == 1 && Sellect_Start == 0)
            {
                SceneManager.LoadScene("BookScene");
            }
            if (Now_Page == 2 && Sellect_Options == 3)
            {
                Sellect_Menu(0);
                AUDIO.text = "";
                VISUAL.text = "";
                CONTROLS.text = "";
                Back.text = "";
                OptionsWindow.SetActive(false);
                Now_Page = 0;
            }
        }
    }
    void OptionsMenu(int updown)
    {
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
            if(updown==0)
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
        if (Now_Page == 10)
        {
            START.text = "";
            OPTIONS.text = "";
            DLC.text = "";
            EXIT.text = "";

            NEW1.text = "NEW";
            NEW2.text = "NEW";
            NEW3.text = "NEW";

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
            NEW1.text = "<color=\"White\">NEW</color>";
            NEW2.text = "NEW";
            NEW3.text = "NEW";
        }
        else if (Sellect_Start == 1)
        {
            Windowbox1.SetActive(false);
            Windowbox2.SetActive(true);
            Windowbox3.SetActive(false);
            NEW2.text = "<color=\"White\">NEW</color>";
            NEW1.text = "NEW";
            NEW3.text = "NEW";
        }
        else if (Sellect_Start == 2)
        {
            Windowbox1.SetActive(false);
            Windowbox2.SetActive(false);
            Windowbox3.SetActive(true);
            NEW3.text = "<color=\"White\">NEW</color>";
            NEW1.text = "NEW";
            NEW2.text = "NEW";
        }
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