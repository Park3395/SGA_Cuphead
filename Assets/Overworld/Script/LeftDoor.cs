using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeftDoor : MonoBehaviour
{
    public Text Txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void Open()
    {
        transform.position = new Vector3(transform.position.x-7.2f, transform.position.y , transform.position.z);
    }
    public void Close()
    {
        transform.position = new Vector3(transform.position.x + 7.2f, transform.position.y, transform.position.z);
    }
    public void P1()
    {
        if (PlayerPrefs.GetInt("SaveFileNum") == 1)
        {
            if(PlayerPrefs.GetInt("Spread1")==1)
                Txt.text = "������ : Ȯ��ź           ��    ��  :  4\r\n���� ���� : o\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins1");
            else
                Txt.text = "������ : Ȯ��ź           ��    ��  :  4\r\n���� ���� : x\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins1");
        }
        else if(PlayerPrefs.GetInt("SaveFileNum") == 2)
        {
            if (PlayerPrefs.GetInt("Spread2") == 1)
                Txt.text = "������ : Ȯ��ź           ��    ��  :  4\r\n���� ���� : o\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins2");
            else
                Txt.text = "������ : Ȯ��ź           ��    ��  :  4\r\n���� ���� : x\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins2");
        }
        else if(PlayerPrefs.GetInt("SaveFileNum") == 3)
        {
            if (PlayerPrefs.GetInt("Spread1") == 3)
                Txt.text = "������ : Ȯ��ź           ��    ��  :  4\r\n���� ���� : o\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins3");
            else
                Txt.text = "������ : Ȯ��ź           ��    ��  :  4\r\n���� ���� : x\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins3");
        }
    }
    public void P2()
    {
        if (PlayerPrefs.GetInt("SaveFileNum") == 1)
        {
            if (PlayerPrefs.GetInt("Heart1") == 1)
                Txt.text = "������ : ��  Ʈ             ��    ��  :  3\r\n���� ���� : o\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins1");
            else
                Txt.text = "������ : ��  Ʈ             ��    ��  :  3\r\n���� ���� : x\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins1");
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 2)
        {
            if (PlayerPrefs.GetInt("Heart2") == 1)
                Txt.text = "������ : ��  Ʈ             ��    ��  :  3\r\n���� ���� : o\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins2");
            else
                Txt.text = "������ : ��  Ʈ             ��    ��  :  3\r\n���� ���� : x\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins2");
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 3)
        {
            if (PlayerPrefs.GetInt("Heart3") == 3)
                Txt.text = "������ : ��  Ʈ             ��    ��  :  3\r\n���� ���� : o\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins3");
            else
                Txt.text = "������ : ��  Ʈ             ��    ��  :  3\r\n���� ���� : x\r              �� �� �� :   " + PlayerPrefs.GetInt("Coins3");
        }
    }
    public void P3()
    {
        Txt.text = "3�� ������ ";
    }
    public void P4()
    {
        Txt.text = "4�� ������ ";
    }
    public void P5()
    {
        Txt.text = "5�� ������ ";
    }
}
