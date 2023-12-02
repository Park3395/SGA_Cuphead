using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceM : MonoBehaviour
{
    //������������������������������������������������������ī��
    Vector3[] dir = new Vector3[5];//ī�� ���� ��ġ
    public GameObject[] Card = new GameObject[5];
    int Hit_Number = 0;         //���� ������ �� ī��� 35
    int Gage_Number = 0;        //�ִ�0,1,2,3,4 �� 5���� ������ ����
    int UpCard_Front = 0;       //2�ʵ� �������� ���̰� �ִ¾տ� ī�� ����
    int UpCard = 0;             //UpCard��° ī���� �������� ���̴���
    int FirstCard = 0;          //���� �Ǿ� ī�� ����
    //���������������������������������������������������������
    //PlayerPrefs��  ��� ������ ���� ������.
    public GameObject[] Life_Img = new GameObject[4];
    int MaxLife = 3;
    int Life = 3;
    
    
    private void Start()
    {
        //�ʱ� ī����ġ ����
        for (int i = 0; i < 5; i++)
        {
            dir[i] = new Vector3(Card[i].transform.position.x, Card[i].transform.position.y, Card[i].transform.position.z);
        }
    }
    //��ư 3��
    public void OnClicked()//��Ʈ
    {
        GageUp();//�׽�Ʈ ������ Ŭ���� GageUp()�� �ߵ��ϰ� �������� �̸� ��Ʈ�� 1ȸ �ߵ��ϵ��� �ȱ�� �ȵ˴ϴ�.
    }
    public void OnClickedPShot()//ī�� ���
    {
        PShot();
    }
    public void OnClickedDamaged()//������-1
    {
        if (Life>0)
            Life--;
        Life_Show();
    }
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
                Gage_Number++;
                UpCard++;
                Hit_Number = 0;
                UpCard_Front = UpCard - 1;
                Card[UpCard_Front].GetComponent<CardM>().RotateCard_True();
                if (UpCard_Front >= 0)
                    Invoke("Card_Reverse", 1.5f);
                if (UpCard >= 5)
                    UpCard = 0;
            }
                     
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
        Vector3[] dir1 = new Vector3[5];
        for (int i = 0; i < 5; i++)
        {
            if(i-1==-1)
                dir1[i] = new Vector3(Card[4].transform.position.x, Card[4].transform.position.y, Card[4].transform.position.z);
            else
                dir1[i] = new Vector3(Card[i - 1].transform.position.x, Card[i].transform.position.y, Card[i].transform.position.z);
        }
            Card[0].transform.position = dir1[0];
            Card[1].transform.position = dir1[1];
            Card[2].transform.position = dir1[2];
            Card[3].transform.position = dir1[3];
            Card[4].transform.position = dir1[4];
        Card[FirstCard].transform.position = dir[4];
        FirstCard++;
        if (FirstCard >4)
            FirstCard = 0;
    }
    
    //������������������������������������������������������� �Լ�
    void Life_Show()//�������� ���� �� ���� �������� ������
    {
        if(0<=Life)//���� �����+1�� ������Ʈ�� ����
        {
            if(Life<MaxLife)
                Life_Img[Life+1].SetActive(false);
        }
        if(Life==0)//�������� 1�� ���� �ִϸ��̼�
        {
            Life_Img[0].GetComponent<HpM>().HP1Anim_True();
            Invoke("HP1AnimeFalse", 1.5f);
        }
    }
    public void HP1AnimeFalse()//Hp1�� �������� ���� �Լ�
    {
        Life_Img[0].GetComponent<HpM>().HP1Anim_False();
    }
    
}
