using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookM : MonoBehaviour
{
    public GameObject IrisOff;
    //애니메이션
    public GameObject Intro;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;
    public GameObject page8;
    public GameObject page9;
    public GameObject page10;
    //고정 페이지
    public GameObject Intro_;
    public GameObject page1_;
    public GameObject page2_;
    public GameObject page3_;
    public GameObject page4_;
    public GameObject page5_;
    public GameObject page6_;
    public GameObject page7_;
    public GameObject page8_;
    public GameObject page9_;
    public GameObject page10_;

    //사운드
    public AudioSource NextPageSound;
    public AudioSource DevilLaugh;
    public AudioSource DevilLaugh2;
    public AudioSource DevilKick;
    public AudioSource BookBgm;
    bool CanKey = false;
    int Bookmark = 0;//현재 페이지
    // Start is called before the first frame update
    void Awake()
    {
        Intro.SetActive(true);
        Invoke("IntroOff", 9.0f);
        BookBgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IrisOff.SetActive(true);
            Invoke("Overworld_Enter", 1.2f);
        }
        if (CanKey)
        {
            NextPageSound.Play();
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Bookmark++;
                PageRight(Bookmark);
                CanKey = false;
            }
            else if (Input.GetKeyDown(KeySetting.keys[KeyAction.Right]))
            {
                Bookmark++; 
                PageRight(Bookmark);
                CanKey = false;
            }
        }
    }
    void IntroOff()
    {
        Intro_.SetActive(true);
        Intro.SetActive(false);
        CanKey = true;
    }
    void PageRight(int Page)
    {
        if(Page == 1)
        {
            page1.SetActive(true);
            Intro_.SetActive(false);
            Invoke("Page1", 1.9f);
        }
        if (Page == 2)
        {
            page2.SetActive(true);
            page1_.SetActive(false);
            Invoke("Page2", 1.9f);
        }
        if (Page == 3)
        {
            DevilLaugh.Play();
            page3.SetActive(true);
            page2_.SetActive(false);
            Invoke("Page3", 1.9f);
        }
        if (Page == 4)
        {
            page4.SetActive(true);
            page3_.SetActive(false);
            Invoke("Page4", 1.9f);
        }
        if (Page == 5)
        {
            
            page5.SetActive(true);
            page4_.SetActive(false);
            Invoke("Page5", 1.9f);
        }
        if (Page == 6)
        {
            DevilLaugh2.Play();
            page6.SetActive(true);
            page5_.SetActive(false);
            Invoke("Page6", 1.9f);
        }
        if (Page == 7)
        {
            
            page7.SetActive(true);
            page6_.SetActive(false);
            Invoke("Page7", 1.9f);
        }
        if (Page == 8)
        {
            page8.SetActive(true);
            page7_.SetActive(false);
            Invoke("Page8", 1.9f);
        }
        if (Page == 9)
        {
            DevilKick.Play();
            page9.SetActive(true);
            page8_.SetActive(false);
            Invoke("Page9", 1.9f);
        }
        if (Page == 10)
        {
            page10.SetActive(true);
            page9_.SetActive(false);
            Invoke("Page10", 1.9f);
        }
        if (Page == 11)
        {
            IrisOff.SetActive(true);
            Invoke("Overworld_Enter", 1.2f);
        }
    }
    void Overworld_Enter()
    {
        BookBgm.Stop();
        SceneManager.LoadScene("OverWorld");
    }
    void Page1()
    {
        page1_.SetActive(true);
        page1.SetActive(false);
        CanKey = true;
    }
    void Page2()
    {
        page2_.SetActive(true);
        page2.SetActive(false);
        CanKey = true;
    }
    void Page3()
    {
        page3_.SetActive(true);
        page3.SetActive(false);
        CanKey = true;
    }
    void Page4()
    {
        page4_.SetActive(true);
        page4.SetActive(false);
        CanKey = true;
    }
    void Page5()
    {
        page5_.SetActive(true);
        page5.SetActive(false);
        CanKey = true;
    }
    void Page6()
    {
        page6_.SetActive(true);
        page6.SetActive(false);
        CanKey = true;
    }
    void Page7()
    {
        page7_.SetActive(true);
        page7.SetActive(false);
        CanKey = true;
    }
    void Page8()
    {
        page8_.SetActive(true);
        page8.SetActive(false);
        CanKey = true;
    }
    void Page9()
    {
        page9_.SetActive(true);
        page9.SetActive(false);
        CanKey = true;
    }
    void Page10()
    {
        page10_.SetActive(true);
        page10.SetActive(false);
        CanKey = true;
    }

}
