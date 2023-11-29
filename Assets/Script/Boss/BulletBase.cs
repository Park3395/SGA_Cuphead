using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTYPE
{
    LEFTS,                      // ���� ����
    RIGHTS,                     // ���� ����
    TRACK                       // ����
}

public class BulletBase : MonoBehaviour
{
    public BTYPE bullet;
    public float speed;
    public GameObject target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Animator>().SetBool("isDestroy", true);
    }

    public void destroySelf()
    {
        Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.bullet == BTYPE.LEFTS)
            this.transform.Translate(new Vector3(speed, 0, 0));
        else if (this.bullet == BTYPE.RIGHTS)
            this.transform.Translate(new Vector3(-speed, 0, 0));
        else if(this.bullet == BTYPE.TRACK)
        {
            // �÷��̾� ���� �ڵ�
            
        }
    }
}
