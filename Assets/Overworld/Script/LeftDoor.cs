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
        Txt.text = "1�� ������ ���� : ";
    }
    public void P2()
    {
        Txt.text = "2�� ������ ���� : ";
    }
    public void P3()
    {
        Txt.text = "3�� ������ ���� : ";
    }
    public void P4()
    {
        Txt.text = "4�� ������ ���� : ";
    }
    public void P5()
    {
        Txt.text = "5�� ������ ���� : ";
    }
}
