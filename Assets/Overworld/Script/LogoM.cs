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
    // Start is called before the first frame update
    void Start()
    {
        Logo.SetActive(true);
    }
    void Update()
    {
        Invoke("LogoDelete", 12.0f);
        if (Input.anyKeyDown)
        {
            IrisA_.SetActive(true);
            Invoke("StartScene",1.3f);
        }
    }
    void LogoDelete()
    {
        SetTitle();
        Destroy(Logo, .5f);
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
