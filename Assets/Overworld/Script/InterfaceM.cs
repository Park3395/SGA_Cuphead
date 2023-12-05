using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceM : MonoBehaviour
{
    //������������������������������������������������������ī��
    Vector3[] dir = new Vector3[14];//ī�� ���� ��ġ
    public GameObject[] Card = new GameObject[14];
    int Hit_Number = 0;         //���� ������ �� ī��� 35
    int Gage_Number = 0;        //�ִ�0,1,2,3,4 �� 5���� ������ ����
    int UpCard_Front = 0;       //2�ʵ� �������� ���̰� �ִ¾տ� ī�� ����
    int UpCard = 0;             //UpCard��° ī���� �������� ���̴���
    int FirstCard = 0;          //���� �Ǿ� ī�� ����
    //5
    //�������������������������������������������������� �������� ������ �������� ���� �ø��� �������� �� Pshot ���� ���� ���������������
    //PlayerPrefs��  ��� ������ ���� ������.
    public GameObject[] Life_Img = new GameObject[5];
    
    int MaxLife = 3;
    int Life = 3;

    int Spread = 0;//1�̸� Tab�����ϰ�
    int Heart = 0;
    
    private void Start()
    {
        //�ʱ� ī����ġ ����
        for (int i = 0; i < 14; i++)
        {
            dir[i] = new Vector3(Card[i].transform.position.x, Card[i].transform.position.y, Card[i].transform.position.z);
        }
        //Heart �������� ����ִ��� ��� �ִٸ� Spread/Heart�� 1�̵˴ϴ�.
        if (PlayerPrefs.GetInt("SaveFileNum") == 1)
        {
            if (PlayerPrefs.GetInt("Spread1") == 1)
                Spread = 1;
            if (PlayerPrefs.GetInt("Heart1") == 1)
                Heart = 1;
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 2)
        {
            if (PlayerPrefs.GetInt("Spread2") == 1)
                Spread = 1;
            if (PlayerPrefs.GetInt("Heart2") == 1)
                Heart = 1;
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 3)
        {
            if (PlayerPrefs.GetInt("Spread3") == 1)
                Spread = 1;
            if (PlayerPrefs.GetInt("Heart3") == 1)
                Heart = 1;
        }
        //��Ʈ �������� ������ �ִ� ����̶� ����4������ ���ִ��� ���̰Եȴ�. 
        if(Heart==1)
        {
            Life_Img[Life + 1].SetActive(false);
            MaxLife -= 1;
            Life -= 1;
        }
    }

    private void Update()
    {
        Life = PlayerController.hp;

        Life_Show();
    }


    //��ư 3������������������������������������������������������������������
    public void OnClicked()//��Ʈ
    {
        GageUp();//Ÿ���� 1ȸ ���⶧ �ҷ���
    }
    public void OnClickedPShot()//ī�� ��� 
    {
        PShot();//ex���� �ߵ�
    }
    public void OnClickedDamaged()//������-1
    {
        Life_Show();//�¾��� ��
    }
    //������������������������������������������������������������������������





    public void OnClickedReset()//������ �ִ�ġ
    {
        Life = MaxLife;
        for (int i =0; i<=MaxLife; i++)
            Life_Img[i].SetActive(true);
    }
    //����������������������������������������������������ī�� �Լ�
    public void GageUp()
    {
        if (Gage_Number < 5)//�ִ� ������
        {
            if (Hit_Number >= 35)//�������� ���̸�
            {
                UpCard++;
                Hit_Number = 0;
                UpCard_Front = UpCard - 1;
                Card[UpCard_Front].GetComponent<CardM>().RotateCard_True();
                if (UpCard_Front >= 0)
                    Invoke("Card_Reverse", 1.5f);
            }
            if (UpCard >= 14)
                UpCard = 0;
            Debug.Log(UpCard);
                Card[UpCard].transform.position =
                    new Vector3(Card[UpCard].transform.position.x, Card[UpCard].transform.position.y + 0.01f, Card[UpCard].transform.position.z);//Hit�� ���ݾ� ���� ī���̵�
                Hit_Number++;//��Ʈ�� Ƚ��+1
        }
    }
    public void Card_Reverse()//ȸ�� ����
    {
        Card[UpCard_Front].GetComponent<CardM>().RotateCard_False();
        UpCard_Front = 0;
        Gage_Number++;
    }
    public void Card_Reverse2()//ī�� �ո�����
    {
        Card[FirstCard].GetComponent<CardM>().RotateCard_True2();
        UpCard_Front = 0;
    }
    public void PShot()
    {
        if (Gage_Number >= 1)
        {
            Gage_Number--;
            CardPositionChange();
        }
    }
    public void CardPositionChange()
    {
        
        //���� ī�� ��ġ ����
        Vector3[] dir1 = new Vector3[14];
        for (int i = 0; i < 14; i++)
        {
            if(i-1==-1)
                dir1[i] = new Vector3(Card[13].transform.position.x, Card[13].transform.position.y, Card[13].transform.position.z);
            else
                dir1[i] = new Vector3(Card[i - 1].transform.position.x, Card[i].transform.position.y, Card[i].transform.position.z);
        }
        for (int i=0; i<14;i++)
            Card[i].transform.position = dir1[i];

        Card[FirstCard].transform.position = dir[13];
        Card_Reverse2();
        FirstCard++;
    }
    
    //������������������������������������������������������� �Լ�
    public void Life_Show()//�������� ���� �� ���� �������� ������
    {
        if (Life > 0)
        {
            Life_Img[Life + 1].SetActive(false);
            
            if (Life == 1)//�������� 1�� ���� �ִϸ��̼�
            {
                Life_Img[1].GetComponent<HpM>().HP1Anim_True();
                Invoke("HP1AnimeFalse", 1.5f);
            }
        }
        else//��� ����
            Life_Img[1].SetActive(false);
    }
    public void HP1AnimeFalse()//Hp1�� �������� ���� �Լ�
    {
        Life_Img[1].GetComponent<HpM>().HP1Anim_False();
    }
    
}
