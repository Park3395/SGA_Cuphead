using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int hp = 0; //�翬�� hp
    public GameObject hpImage; //hp �̹���
    public Sprite hp1Image;    //hp 1
    public Sprite hp2Image;    //hp 2
    public Sprite hp3Image;    //hp 3
    public Sprite deadImage;    //����
    public GameObject resetButton; //���� ��ư

    public string retryScenename = "";
                          
    // Start is called before the first frame update
    void Start()
    {
        UpdateHp();
        resetButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHp();
    }
    //hp �����ϴ� �Լ�
    void UpdateHp()
    {
        if(PlayerController.gameState != "gameend")
        {
           GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null)
            {
                hp = PlayerController.hp;
                if(hp<=0)
                {
                    hpImage.GetComponent<Image>().sprite = deadImage;
                    resetButton.SetActive(true);
                    PlayerController.gameState = "gameend";
                }

                else if (hp==1)
                {
                    hpImage.GetComponent<Image>().sprite = hp1Image;
                }

                else if (hp == 2)
                {
                    hpImage.GetComponent<Image>().sprite = hp2Image;
                }
                else
                {
                    hpImage.GetComponent<Image>().sprite = hp3Image;
                }


            }
        }
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("PlayerHP", 3);
        SceneManager.LoadScene(retryScenename);
    }
    void inactiveImage()
    {

    }
}
