using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RngManager : MonoBehaviour
{
    public GameObject gameClear;  // ���� Ŭ���� �� ������
    public GameObject gameOver;   // ���� ���� �� ������

    public GameObject panel;

    public AudioClip gameStartSound;    // ���� ���� �� ����
    public AudioClip[] gameClearSound;    // ���� Ŭ���� �� ����

    public static bool GameIsPaused = false;

    public string sceneName = "Result";       // ��� ��

    // Start is called before the first frame update
    void Start()
    {
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
            PlayerController.gameState = "gameend";

            AudioSource sound = GetComponent<AudioSource>();
            if (sound != null)
            {
                int random = Random.Range(0, gameClearSound.Length);
                sound.Stop();
                sound.PlayOneShot(gameClearSound[random]);
            }

            gameClear.SetActive(true);

            Invoke("LoadScene", 5);
        }
        else if (PlayerController.gameState == "gameover")
        {
            PlayerController.gameState = "gameend";

            gameOver.SetActive(true);
            Invoke("activePanel", 1.7f);
        }
        else if (PlayerController.gameState == "playing")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                panel.SetActive(true);
                GameIsPaused = true;
            }

            
        }
    }

    void activePanel()
    {
        panel.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
