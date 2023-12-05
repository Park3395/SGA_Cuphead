using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject msgCard;
    [SerializeField]
    private GameObject Potato;
    [SerializeField]
    private GameObject Onion;
    [SerializeField]
    private GameObject Carrot;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject overUI;
    [SerializeField]
    private GameObject[] overtext;

    private int bossState = 0;
    private string introMsg = "Ready";
    private string clearMsg = "Clear";
    private string goverMsg = "Gameover";

    private bool isStop = false;
    public void clear()
    {
        msgCard.SetActive(true);
        msgCard.GetComponent<Animator>().Play(clearMsg);
    }

    public void activeOverUI()
    {
        overUI.SetActive(true);
        if(Potato != null)
            overtext[0].SetActive(true);
        else if(Onion != null)
            overtext[1].SetActive(true);
        else if(Carrot != null)
            overtext[2].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        msgCard.SetActive(true);
        msgCard.GetComponent<Animator>().Play(introMsg);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStop && Input.GetKeyDown(KeyCode.Escape))
        {
            isStop = true;
            activeOverUI();
            Time.timeScale = 0;
        }
        else if(isStop && Input.GetKeyDown(KeyCode.Escape))
        {
            isStop = false;
            overUI.SetActive(false);
            Time.timeScale = 1;
        }

        if(bossState == 0 && msgCard.activeSelf == false)
        {
            StartCoroutine(initPotato());
            bossState++;
        }
        if(bossState == 1 && Potato == null)
        {
            StartCoroutine(initOnion());
            bossState++;
        }
        if(bossState == 2 && Onion == null)
        {
            StartCoroutine(initCarrot());
        }

        if(Player == null)
        {
            msgCard.SetActive(true);
            msgCard.GetComponent<Animator>().Play(goverMsg);
        }
    }

    IEnumerator initPotato()
    {
        yield return new WaitForSeconds(1.0f);
        this.Potato.SetActive(true);
        yield break;
    }
    IEnumerator initOnion()
    {
        yield return new WaitForSeconds(1.0f);
        this.Onion.SetActive(true);
        yield break;
    }
    IEnumerator initCarrot()
    {
        yield return new WaitForSeconds(1.0f);
        this.Carrot.SetActive(true);
        yield break;
    }
}
