using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RngManager : MonoBehaviour
{
    public GameObject gameClear;  // 게임 클리어 시 프리팹
    public GameObject gameOver;   // 게임 오버 시 프리팹

    public GameObject panel;

    public AudioClip gameStartSound;    // 게임 시작 시 사운드
    public AudioClip[] gameClearSound;    // 게임 클리어 시 사운드

    public static bool GameIsPaused = false;    // esc 창을 띄우고 끄기 위한 것

    TimeController timeCnt;             // TimeController 클래스

    public static float clearTime;                     // 클리어 타임
    public static int goldScore = 0;          // 스테이지 점수
    public static int hpScore = 0;            // 클리어 시 남아있는 체력

    public string sceneName = "";       // 결과 씬

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.hp = 3;

        timeCnt = GetComponent<TimeController>();
        AudioSource sound = GetComponent<AudioSource>();
        if(sound != null)
        {
            sound.PlayOneShot(gameStartSound);
        }

        panel.SetActive(false);
        gameClear.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameState == "gameclear")
        {
            gameClear.SetActive(true);

            Destroy(gameClear, 2.0f);

            PlayerController.gameState = "gameend";

            hpScore = PlayerController.hp;

            if (timeCnt != null)
            {
                // 시간 저장
                clearTime = timeCnt.currentTime;
            }

            AudioSource sound = GetComponent<AudioSource>();
            if (sound != null)
            {
                int random = Random.Range(0, gameClearSound.Length);
                sound.Stop();
                sound.PlayOneShot(gameClearSound[random]);
            }
            
            Invoke("LoadScene", 5);            
        }
        else if (PlayerController.gameState == "gameover")
        {
            PlayerController.gameState = "gameend";

            AudioSource sound = GetComponent<AudioSource>();
            if (sound != null)
            {
                sound.Stop();
            }

            gameOver.SetActive(true);
            Invoke("activePanel", 1.7f);
        }
        else if (PlayerController.gameState == "playing")
        {
            if(!GameIsPaused)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    panel.SetActive(true);
                    GameIsPaused = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    panel.SetActive(false);
                    GameIsPaused = false;
                }
            }
        }
    }

    void activePanel()
    {
        panel.SetActive(true);
        PlayerController.gameState = "gameend";
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
