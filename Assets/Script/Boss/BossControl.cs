using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoControl : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Sub;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
