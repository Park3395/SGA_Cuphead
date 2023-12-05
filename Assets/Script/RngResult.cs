using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RngResult : MonoBehaviour
{
    public GameObject timeText;         // �ð�
    int minute = 0;
    int second = 0;

    public GameObject hpText;           // ü��
    public GameObject goldText;         // ���
    public GameObject gradeText;        // ���

    public string sceneName = "";       // ���� ��

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

    public void Grade() // ��� ���� ���ϱ�
    {
        if (RngManager.clearTime <= 60 && RngManager.goldScore >= 5 && RngManager.hpScore >= 3)     // Ŭ����Ÿ���� 60�� �����̰� ��尡 5�̻��̰� ü���� 3�̻��̸� S
            gradeText.GetComponent<Text>().text = "S";
        else if (RngManager.clearTime <= 90 && RngManager.goldScore >= 5 && RngManager.hpScore >= 2)     // Ŭ����Ÿ���� 90�� �����̰� ��尡 5�̻��̰� ü���� 2�̻��̸� A
            gradeText.GetComponent<Text>().text = "A";
        else if (RngManager.clearTime <= 120 && RngManager.goldScore >= 3 && RngManager.hpScore >= 2)      // Ŭ����Ÿ���� 120�� �����̰� ��尡 3�̻��̰� ü���� 2�̻��̸� B
            gradeText.GetComponent<Text>().text = "B";
        else if (RngManager.clearTime <= 150 && RngManager.goldScore >= 2 && RngManager.hpScore >= 1)     // Ŭ����Ÿ���� 150�� �����̰� ��尡 2�̻��̰� ü���� 1�̻��̸� C
            gradeText.GetComponent<Text>().text = "C";
        else                                                                                            // �� �ܿ� D
            gradeText.GetComponent<Text>().text = "D";
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
