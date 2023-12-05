using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RngResult : MonoBehaviour
{
    public GameObject timeText;         // 시간
    int minute = 0;
    int second = 0;

    public GameObject hpText;           // 체력
    public GameObject goldText;         // 골드
    public GameObject gradeText;        // 등급

    public string sceneName = "";       // 다음 씬

    // Start is called before the first frame update
    void Start()
    {
        second = (int)(RngManager.clearTime % 60);
        minute = (int)(RngManager.clearTime / 60) % 60;

        timeText.GetComponent<Text>().text = minute.ToString("00") + ":" + second.ToString("00");
        hpText.GetComponent<Text>().text = RngManager.hpScore.ToString("0") + "/3";
        goldText.GetComponent<Text>().text = RngManager.goldScore.ToString("0") + "/5";
        gradeText.GetComponent<Text>().text = "?";
        Grade();

        Invoke("LoadScene", 8);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Grade() // 등급 조건 구하기
    {
        if (RngManager.clearTime <= 60 && RngManager.goldScore >= 5 && RngManager.hpScore >= 3)     // 클리어타임이 60초 이하이고 골드가 5이상이고 체력이 3이상이면 S
            gradeText.GetComponent<Text>().text = "S";
        else if (RngManager.clearTime <= 90 && RngManager.goldScore >= 5 && RngManager.hpScore >= 2)     // 클리어타임이 90초 이하이고 골드가 5이상이고 체력이 2이상이면 A
            gradeText.GetComponent<Text>().text = "A";
        else if (RngManager.clearTime <= 120 && RngManager.goldScore >= 3 && RngManager.hpScore >= 2)      // 클리어타임이 120초 이하이고 골드가 3이상이고 체력이 2이상이면 B
            gradeText.GetComponent<Text>().text = "B";
        else if (RngManager.clearTime <= 150 && RngManager.goldScore >= 2 && RngManager.hpScore >= 1)     // 클리어타임이 150초 이하이고 골드가 2이상이고 체력이 1이상이면 C
            gradeText.GetComponent<Text>().text = "C";
        else                                                                                            // 그 외엔 D
            gradeText.GetComponent<Text>().text = "D";
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
