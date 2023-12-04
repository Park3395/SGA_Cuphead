using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LogoM : MonoBehaviour
{
    public GameObject Logo;
    public GameObject Title_Cuphead;
    public GameObject Title_Background;
    public GameObject IrisA_;
    public GameObject Title_Text;

    public AudioSource LogoSound;
    bool CanKey = false;

    void Start()
    {
        Logo.SetActive(true);
        Invoke("LogoSound_f", 3.2f);
    }
    void Update()
    {
        Invoke("LogoDelete", 12.0f);
        if (Input.anyKeyDown&& CanKey==true)
        {
            IrisA_.SetActive(true);
            Title_Text.SetActive(false);
            Invoke("StartScene",3.1f);
        }
    }
    void LogoSound_f()
    {
        LogoSound.Play();
    }
    void LogoDelete()
    {
        SetTitle();
        Destroy(Logo,0.5f);
        CanKey = true;
    }
    void SetTitle()
    {
        Title_Text.SetActive(true);
        Title_Cuphead.SetActive(true);
        Title_Background.SetActive(true);
    }
    void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
