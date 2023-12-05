using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backCarrot : BulletBase
{
    [SerializeField]
    private BulletBase frontBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if(this.transform.position.y >Camera.main.ScreenToWorldPoint(new Vector3(0,Camera.main.pixelHeight,0)).y)
        {
            Instantiate(frontBullet, this.transform.position, new Quaternion());
            Destroy(this.gameObject);
        }    
    }
}
