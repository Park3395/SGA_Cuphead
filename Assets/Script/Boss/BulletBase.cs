using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTYPE
{
    LEFTS,                      // ���� ����
    RIGHTS,                     // ���� ����
    DOWN,                       // �ϰ�
    UP,                         // ���
    TRACK                       // ����
}

public class BulletBase : MonoBehaviour
{
    public BTYPE bullet;
    public float speed;
    public GameObject target;

    [SerializeField]
    protected string deadAnim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Animator>().Play(deadAnim);
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
            this.transform.Translate(new Vector3(-speed, 0, 0));
        else if (this.bullet == BTYPE.RIGHTS)
            this.transform.Translate(new Vector3(speed, 0, 0));
        else if (this.bullet == BTYPE.DOWN)
        {
            this.transform.Translate(new Vector3(0, -speed, 0));
        }
        else if (this.bullet == BTYPE.UP)
        {
            this.transform.Translate(new Vector3(0, speed, 0));
        }
        else if(this.bullet == BTYPE.TRACK)
        {
            // �÷��̾� ���� �ڵ�
            
        }

        if (this.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
            Destroy(this.gameObject);
    }
}
