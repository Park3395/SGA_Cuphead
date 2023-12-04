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

    private int bossState = 0;
    private string introMsg = "Ready";
    private string clearMsg = "Clear";
    private string goverMsg = "GameOver";

    // Start is called before the first frame update
    void Start()
    {
        msgCard.SetActive(true);
        msgCard.GetComponent<Animator>().Play(introMsg);
    }

    // Update is called once per frame
    void Update()
    {
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
