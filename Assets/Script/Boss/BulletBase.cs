using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTYPE
{
    LEFTS,                      // 좌측 직선
    RIGHTS,                     // 우측 직선
    DOWNS,                       // 하강
    UPS,                         // 상승
    TRACKS                       // 추적
}

public class BulletBase : MonoBehaviour
{
    public BTYPE bullet;
    public float speed;
    protected GameObject target;
    protected Vector3 togo;
    protected bool track = true;

    [SerializeField]
    protected string deadAnim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Animator>().Play(deadAnim);

        if (this.CompareTag("Parry"))
            if (collision.gameObject.CompareTag("Player"))
                this.GetComponent<Animator>().Play(deadAnim);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public void destroySelf()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    protected void Update()
    {
        switch (bullet)
        { 
            case BTYPE.LEFTS:
                {
                    this.transform.Translate(new Vector3(-speed*Time.deltaTime, 0, 0));
                    break;
                }
            case BTYPE.RIGHTS:
                {
                this.transform.Translate(new Vector3(speed*Time.deltaTime, 0, 0));
                break;
                }
            case BTYPE.DOWNS:
                {
                this.transform.Translate(new Vector3(0, -speed*Time.deltaTime, 0));
                break;
                }
            case BTYPE.UPS:
                {
                this.transform.Translate(new Vector3(0, speed*Time.deltaTime, 0));
                break;
                }
            case BTYPE.TRACKS:
                {
                    target = GameObject.FindWithTag("Player");

                    float dis = Vector3.Distance(this.transform.position, target.transform.position);

                    if (dis < 3.0f)
                        track = false;

                    if(track)
                    {
                    Vector2 direction1 = new Vector2(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y);
                    float angle = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
                    Quaternion angleAxis = Quaternion.AngleAxis(angle-90f,Vector3.forward);
                    Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, speed * Time.deltaTime);
                    this.transform.rotation = rotation;

                    togo = target.transform.position - this.transform.position;
                    togo.Normalize();
                    }
                    this.transform.Translate(new Vector3(speed * Time.deltaTime * togo.x, -speed * Time.deltaTime, 0));

                    break;
                }
        }

        //if (this.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
        //    Destroy(this.gameObject);
    }
}
