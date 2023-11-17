using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoPlay : MonoBehaviour
{
    public GameObject Logo;
    // Start is called before the first frame update
    public void LogoAnime()
    {
        Debug.Log("Create Logo");
        Instantiate(Logo);
        Logo.GetComponent<Animator>().Play("LogoAnime");
        Destroy(Logo);
        Debug.Log("Destry Logo");
    }
    void Start()
    {
        Invoke("LogoAnime", 2f); // 1초 뒤 시작
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
