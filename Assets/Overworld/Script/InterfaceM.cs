using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceM : MonoBehaviour
{
    //───────────────────────────카드
    Vector3[] dir = new Vector3[14];//카드 시작 위치
    public GameObject[] Card = new GameObject[14];
    int Hit_Number = 0;         //현재 게이지 량 카드당 35
    int Gage_Number = 0;        //최대0,1,2,3,4 총 5개의 게이지 장전
    int UpCard_Front = 0;       //2초뒤 게이지가 쌓이고 있는앞에 카드 구분
    int UpCard = 0;             //UpCard번째 카드의 게이지가 쌓이는중
    int FirstCard = 0;          //현재 맨앞 카드 구분
    //5개로 돌려쓰려 했으나 오류떠서 수를 늘리는 방향으로 함 Pshot 많이 쓰면 오류
    //───────────────────────────목숨
    //PlayerPrefs로  목숨 갯수는 이후 가져옴.
    public GameObject[] Life_Img = new GameObject[4];
    int MaxLife = 3;
    int Life = 3;
    
    
    private void Start()
    {
        //초기 카드위치 저장
        for (int i = 0; i < 14; i++)
        {
            dir[i] = new Vector3(Card[i].transform.position.x, Card[i].transform.position.y, Card[i].transform.position.z);
        }
    }
    //버튼 3개
    public void OnClicked()//히트
    {
        GageUp();//테스트 에서는 클릭시 GageUp()이 발동하게 되있으나 이를 히트시 1회 발동하도록 옴기면 된됩니다.
    }
    public void OnClickedPShot()//카드 사용
    {
        PShot();
    }
    public void OnClickedDamaged()//라이프-1
    {
        if (Life>0)
            Life--;
        Life_Show();
    }
    public void OnClickedReset()//라이프 최대치
    {
        Life = MaxLife;
        for (int i =0; i<=MaxLife; i++)
            Life_Img[i].SetActive(true);
    }
    //──────────────────────────카드 함수
    public void GageUp()
    {
        if (Gage_Number < 5)//최대 게이지
        {
            if (Hit_Number >= 35)//게이지가 쌓이면
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
                    new Vector3(Card[UpCard].transform.position.x, Card[UpCard].transform.position.y + 0.01f, Card[UpCard].transform.position.z);//Hit시 조금씩 위로 카드이동
                Hit_Number++;//히트한 횟수+1
        }
    }
    public void Card_Reverse()//회전 정지
    {
        Card[UpCard_Front].GetComponent<CardM>().RotateCard_False();
        UpCard_Front = 0;
        Gage_Number++;
    }
    public void Card_Reverse2()//카드 앞면으로
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
        
        //앞의 카드 위치 저장
        Vector3[] dir1 = new Vector3[14];
        for (int i = 0; i < 14; i++)
        {
            if(i-1==-1)
                dir1[i] = new Vector3(Card[13].transform.position.x, Card[13].transform.position.y, Card[13].transform.position.z);
            else
                dir1[i] = new Vector3(Card[i - 1].transform.position.x, Card[i].transform.position.y, Card[i].transform.position.z);
        }
        Card[0].transform.position = dir1[0];
        Card[1].transform.position = dir1[1];
        Card[2].transform.position = dir1[2];
        Card[3].transform.position = dir1[3];
        Card[4].transform.position = dir1[4];
        Card[5].transform.position = dir1[5];
        Card[6].transform.position = dir1[6];
        Card[7].transform.position = dir1[7];
        Card[8].transform.position = dir1[8];
        Card[9].transform.position = dir1[9];
        Card[10].transform.position = dir1[10];
        Card[11].transform.position = dir1[11];
        Card[12].transform.position = dir1[12];
        Card[13].transform.position = dir1[13];

        Card[FirstCard].transform.position = dir[13];
        Card_Reverse2();
        FirstCard++;
        
    }
    
    //──────────────────────────목숨 함수
    void Life_Show()//데미지를 입은 후 현재 라이프를 보여줌
    {
        if(0<=Life)//현재 목숨값+1의 오브젝트를 숨김
        {
            if(Life<MaxLife)
                Life_Img[Life+1].SetActive(false);
        }
        if(Life==0)//라이프가 1로 갈때 애니메이션
        {
            Life_Img[0].GetComponent<HpM>().HP1Anim_True();
            Invoke("HP1AnimeFalse", 1.5f);
        }
    }
    public void HP1AnimeFalse()//Hp1의 깜빡임을 끄는 함수
    {
        Life_Img[0].GetComponent<HpM>().HP1Anim_False();
    }
    
}
