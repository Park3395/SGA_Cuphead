using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;        // 불러올 scene

    public void Load()      // 다음 씬 불러오기
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void Quitgame()      // 게임 종료
    {
        Application.Quit();
    }
}
