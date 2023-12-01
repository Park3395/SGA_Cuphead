using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float delaytime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delaytime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
