using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;        // �ҷ��� scene

    public void Load()      // ���� �� �ҷ�����
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quitgame()      // ���� ����
    {
        Application.Quit();
    }
}
