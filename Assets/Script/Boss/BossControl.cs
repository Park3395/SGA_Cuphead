using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Sub;

    [SerializeField]
    protected string SubEnd;
    [SerializeField]
    private string end;

    void visible()
    {
        Boss.SetActive(true);
        Sub.SetActive(true);
    }

    void invisible()
    {
        Boss.SetActive(false);
        Sub.SetActive(false);
    }
    public void endAnim()
    {
        this.GetComponent<Animator>().Play(end);
    }

    void subEnd()
    {
        Sub.GetComponent<Animator>().Play(SubEnd);
    }

    protected void Dead()
    {
        Destroy(Boss);
        Destroy(Sub);
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
