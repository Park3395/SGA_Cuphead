using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    
    public GameObject[] Coins = new GameObject[21];

    public void CoinViewF()
    {
        int Coin = 0;
        if (PlayerPrefs.GetInt("SaveFileNum") == 1)
        {
            Coin = PlayerPrefs.GetInt("Coins1");
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 2)
        {
            Coin = PlayerPrefs.GetInt("Coins2");
        }
        else if (PlayerPrefs.GetInt("SaveFileNum") == 3)
        {
            Coin = PlayerPrefs.GetInt("Coins3");
        }
        Debug.Log("ÄÚÀÎ·® : "+Coin);
        for (int i = 0; i <= 20; i++)
        {
            if (Coin == i)
            {
                Coins[i].SetActive(true);
            }
            else
                Coins[i].SetActive(false);
        }
    }
    
}
