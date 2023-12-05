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
    //5
    //───────────────────────개로 돌려쓰려 했으나 오류떠서 수를 늘리는 방향으로 함 Pshot 많이 쓰면 오류────목숨
    //PlayerPrefs로  목숨 갯수는 이후 가져옴.
    public GameObject[] Life_Img = new GameObject[5];
    
    int MaxLife = 3;
    int Life = 3;

    int Spread = 0;//1이면 Tab가능하게
    int Heart = 0;
    
    private void Start()
    {
        //초기 카드위치 저장
        for (int i = 0; i < 14; i++)
        {
            dir[i] = new Vector3(Card[i].transform.position.x, Card[i].transform.position.y, Card[i].transform.position.z);
        }
        //Heart 아이템을 들고있는지 들고 있다면 Spread/Heart는 1이됩니다.
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
        //하트 아이템이 있을시 최대 목숨이랑 현제4라이프 되있던게 까이게된다. 
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


    //버튼 3개────────────────────────────────
    public void OnClicked()//히트
    {
        GageUp();//타겟을 1회 맞출때 불러옴
    }
    public void OnClickedPShot()//카드 사용 
    {
        PShot();//ex샷시 발동
    }
    public void OnClickedDamaged()//라이프-1
    {
        Life_Show();//맞았을 때
    }
    //────────────────────────────────────





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
        for (int i=0; i<14;i++)
            Card[i].transform.position = dir1[i];

        Card[FirstCard].transform.position = dir[13];
        Card_Reverse2();
        FirstCard++;
    }
    
    //──────────────────────────목숨 함수
    public void Life_Show()//데미지를 입은 후 현재 라이프를 보여줌
    {
        if (Life > 0)
        {
            Life_Img[Life + 1].SetActive(false);
            
            if (Life == 1)//라이프가 1로 갈때 애니메이션
            {
                Life_Img[1].GetComponent<HpM>().HP1Anim_True();
                Invoke("HP1AnimeFalse", 1.5f);
            }
        }
        else//사망 상태
            Life_Img[1].SetActive(false);
    }
    public void HP1AnimeFalse()//Hp1의 깜빡임을 끄는 함수
    {
        Life_Img[1].GetComponent<HpM>().HP1Anim_False();
    }
    
}
