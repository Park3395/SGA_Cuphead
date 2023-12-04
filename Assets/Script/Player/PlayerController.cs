using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;                //�¿� ����Ű �Է�
    float axisV = 0.0f;
    public float speed = 4.0f;         //�̵��ӵ�, 3.0f -> 4.0f�� ����

    public float jump = 7.0f;          //������
    public float dash = 50.0f;          //�뽬��
    public LayerMask groundLayer;       //���� ������ ���̾�
    bool goJump = false;               //����Ű �Է»���
    public bool onGround = false;             //����� ���˻���
    bool goDash = false;               //�뽬 �Է� ����
    public bool downJump = false;             //�Ʒ� ����


    //�ִϸ�����
    Animator animator;
    public string stopAnime = "PlayerIdle"; //������ ���� �� �ִϸ��̼�
    public string jumpAnime = "PlayerJump"; //������ �� �ִϸ��̼�
    public string runAnime = "PlayerRun";   //������ �� �ִϸ��̼�
    public string aimupAnime = "PlayerAimUp"; //���� �� �� �ִϸ��̼�
    public string shootstraightAnime = "PlayerShootStraight"; //�������� �߻� �ִϸ��̼�
    public string shootupAnime = "PlayerShootUp"; //������ �߻� �ִϸ��̼�
    public string runshootstraightAnime = "PlayerRunShootStraight"; //�޸��鼭 �������� �߻� �ִϸ��̼�
    public string duckAnime = "PlayerDuck"; //�Ʒ�����Ű�� ������ �� �ִϸ��̼�
    public string duckidleAnime = "PlayerDuckIdle";//�Ʒ�����Ű�� ��� ������ ���� ���� �ִϸ��̼�
    public string duckshootAnime = "PlayerDuckShoot"; //���׸� ���¿��� �߻��� �� �ִϸ��̼�
    public string peashooterspawnanime = "PeaShooterSpawn"; //�峭�� �� �߻�� �� �ִϸ��̼�
    public string rundiagonlaupAnime = "PlayerRunDiagonalUp"; //�����̸鼭 �밢�� �����Ҷ��� �밢�� �߻��� �� �ִϸ��̼�
    public string dashAnime = "PlayerDash";
    public string dustAnime = "PlayerDust"; //�뽬�� �� ������� �ִϸ��̼�
    public string hitAnime = "PlayerHit";   //�¾��� �� �ִϸ��̼�
    public string deadAnime = "PlayerDead"; //�׾��� �� �ִϸ��̼�

    string nowAnime = "";
    string oldAnime = "";

    bool isMoving = false;

    public static string gameState = "playing";
    public float angleZ = -90.0f; //ȸ��
    public static int hp = 3;
    bool inDamage = false;
    public static PlayerController instance; //�̱��� ���Ͽ� ����?
    public bool isParry = false;      //�и� ����
    //�ٵ� �̱��� ������ ������
    private void Awake()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        if (PlayerController.instance == null)
        {
            PlayerController.instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // RigidBody 2D ������Ʈ ���� ��������
        rbody = this.GetComponent<Rigidbody2D>();


        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;

        //���� ����(�÷��� ��)
        gameState = "playing";

        //HP �ҷ�����
        hp = PlayerPrefs.GetInt("PlayerHP");

    }

    // Update is called once per frame
    // GetKeyDown�� GetKey�� �ٲٴ°� ��������
    void Update()
    {
        if (gameState != "playing" || inDamage)
        {
            return;
        }


        //���� ���� �Է� ->GetKeyDown���� ��� �ٲٴ� �� ��������
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }
        //Ű �Է��� ���� �̵������� ���ϱ�
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);

        //Input.GetKeyDown(KeySetting.Keys(KeyAction. ......)

        //ĳ���� ���� ����
        if (Input.GetKeyDown(KeyCode.RightArrow) && onGround)
        {
            //������ �̵�
            Debug.Log("������ �̵�");
            transform.localScale = new Vector2(1, 1);
            //���� 8���� �߻纸�� 8���� �ִϸ��̼��� ������� �ߴµ� �� 8���� �߻簡 ��?

        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && onGround)
        {
            Debug.Log("������ �̵�Ű ��");
            nowAnime = stopAnime;
            animator.Play(nowAnime);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && onGround)
        {
            // ��밢 ����
            Debug.Log("��밢");
            nowAnime = rundiagonlaupAnime;
            animator.Play(nowAnime);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && onGround)
        {
            //���� �̵�
            Debug.Log("���� �̵�");
            transform.localScale = new Vector2(-1, 1); //�¿� ����
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && onGround)
        {
            Debug.Log("���� �̵�Ű ��");
            nowAnime = stopAnime;
            animator.Play(nowAnime);

        }


        if (Input.GetKeyUp(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && onGround)
        {
            Debug.Log("���� �̵�Ű ���鼭 ����������");
            nowAnime = runAnime;
            animator.Play(nowAnime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && onGround)
        {
            //�´밢 ���� �´밢���� �ٶ󺸰� ���� �� ������ �ȵǴµ� ����?
            Debug.Log("�´밢");
            nowAnime = rundiagonlaupAnime;
            animator.Play(nowAnime);
        }
        //(KeySetting.keys[KeyAction.Shot])
        if (Input.GetKeyDown(KeyCode.Z) && onGround)
        {
            Debug.Log("�� �����鼭 �߻�");
            nowAnime = shootstraightAnime;
            animator.Play(nowAnime);

        }
        if (Input.GetKeyUp(KeyCode.Z) && onGround)
        {
            Debug.Log("zŰ���� �� ��");
            nowAnime = stopAnime;
            animator.Play(nowAnime);

        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Z) && axisV == 0 && onGround)
        {
            Debug.Log("������ �̵��ϸ鼭 �߻�");
            transform.localScale = new Vector2(1, 1);
            nowAnime = runshootstraightAnime;
            animator.Play(nowAnime);

        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.Z) && onGround)
        {
            nowAnime = runAnime;
            animator.Play(nowAnime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Z) && axisV == 0 && onGround)
        {
            Debug.Log("���� �̵��ϸ鼭 �߻�");
            transform.localScale = new Vector2(-1, 1);
            nowAnime = runshootstraightAnime;
            animator.Play(nowAnime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.Z) && onGround)
        {
            nowAnime = runAnime;
            animator.Play(nowAnime);
        }


        //ĳ���� ����
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //�� ����Ű�� ������ �� ������ ���� �ִϸ��̼� ����(�ִϸ��̼� ���� �ʼ�)
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            Debug.Log("���� ����");
            nowAnime = aimupAnime;
            animator.Play(nowAnime);
        }
        //�� ����Ű���� ���� ���� �� �ִϸ��̼� �ٲٱ�
        if (Input.GetKeyUp(KeyCode.UpArrow) && onGround)
        {
            Debug.Log("�� ����Ű �� ��");
            nowAnime = stopAnime;
            animator.Play(nowAnime);
        }

        //���� ���鼭 ���ÿ� z�� ������ ��
        //if���� GetKeyDown�� �� �� ���� �� �����ӿ� Ű �� ���� �� �Է��ߴ��� �˻��ϱ⿡ ������ ��ƴ�.
        //������ �߻�
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Z) && axisH == 0 && onGround)
        {
            nowAnime = shootupAnime;
            animator.Play(shootupAnime);
            Debug.Log("������Ű, ZŰ ����");

        }
        //�̷��� if���� ���� ���� �þ�°� �³�????
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.Z) && onGround)
        {
            nowAnime = aimupAnime;
            animator.Play(nowAnime);
            Debug.Log("������Ű, ZŰ ��");
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Z) && onGround)
        {
            //��밢 �߻�
            Debug.Log("��밢 �߻�");
            nowAnime = rundiagonlaupAnime;
            animator.Play(nowAnime);
        }
        //��밢���� �����ϸ� �����̴� �� �� ����Ű���� �� ����
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.UpArrow) && onGround)
        {
            Debug.Log("������Ű �� ��");
            nowAnime = runAnime;
            animator.Play(nowAnime);
        }
        //�´밢���� �����ϸ� �����̴� �� �� ����Ű���� �� ����
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.UpArrow) && onGround)
        {
            Debug.Log("������Ű �� ��");
            nowAnime = runAnime;
            animator.Play(nowAnime);
        }

        //�Ʒ�����Ű�� ������ �� �� �ִϸ��̼ǿ��� ��������Ʈ ��ġ�� �� �ȸ´� ������ ������ �����ؾ���
        if (Input.GetKeyDown(KeyCode.DownArrow) && onGround)
        {
            nowAnime = duckidleAnime;
            animator.Play(nowAnime);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && onGround)
        {
            nowAnime = stopAnime;
            animator.Play(nowAnime);
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Z) && onGround)
        {
            nowAnime = duckshootAnime;
            animator.Play(nowAnime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.Z) && onGround)
        {
            nowAnime = duckidleAnime;
            animator.Play(nowAnime);
        }
        //�뽬, xŰ�� ������ �� �뽬 �ִϸ��̼��� �׳� ��ũ�� �ٲ���
        if (Input.GetKeyDown(KeyCode.X))
        {
            Dash();
            nowAnime = dustAnime;
            animator.Play(nowAnime);

        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space) && onGround)
        {
            DownJump();

        }



        //zŰ�� ������ �� �߻��ϴ� �ִϸ��̼�, ��ǲ�Ŵ��� ���� �ȹٲ㼭 �ӽ÷� z
        /*
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("zŰ ����");
            nowAnime = shootstraightAnime;
            animator.Play(nowAnime);
        }
        //zŰ���� ���� �� �ִϸ��̼� �ٲٱ�, ��ǲ�Ŵ��� ���� �ȹٲ㼭 �ӽ÷� z
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Debug.Log("zŰ ��");
            nowAnime = stopAnime;
            animator.Play(nowAnime);
        }*/
        if (onGround == false && Input.GetKeyDown(KeyCode.Space))
        {
            Parry();
            Invoke("ParryEnd", 0.25f);
        }

    }
    //private �� �տ� �پ��־ ���ֺ����� ������ ���� ���� ó���� �̻��ϴ�->linecast�� y�� ���� �����ϴ� ���� ó���� ����������.
    void FixedUpdate()
    {
        if (gameState != "playing")
            return;
        //���� ���� ó��
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 1.0f), groundLayer);

        //�� if���� ���� �� �÷��̾� ĳ���Ͱ� �����̱� �ϳ� ĳ���Ͱ� ��������.
        //Rigidbody 2D�� Constraints�� Freeze Rotation�� z���� üũ���� ĳ���Ͱ� �������� �ʾ����� �ǵ�ġ�ʰ� ���ӵ��� �ٴ´�.
        if (onGround || axisH != 0)
        {
            //ĳ���Ͱ� ���鿡 �ְų� x�� �Է°��� 0�� �ƴ� ��� velocity ����
            rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
        }
        //�� if������ �־��� �� Jump �Լ��� Ȱ��ȭ �ǳ� ĳ���Ͱ� �������� �ʾҴ�.
        if (onGround && goJump)
        {
            Debug.Log("����!");
            Vector2 jumpPw = new Vector2(0, jump);            //������ ���� ����
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);      //�������� ���� ���Ѵ�
            goJump = false;  //���� �÷��� off

        }
        if (onGround && downJump)
        {
            Debug.Log("�ٿ� ����!");
            Vector2 jumpPw = new Vector2(0, -jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            downJump = false;
        }
        //�� if���� �־��� �� �뽬 �Լ��� �� if���� Ȱ��ȭ �Ǳ� �ϳ� �뽬�� ���� �ʾҴ� �뽬�� �⺻���� ũ�� �÷����� �뽬�� �ߴ�..
        //�뽬�� ���������� ���ϰ� �ϰ� �ͱ������� ���߿� �ð� ���� ��������.
        if (goDash)
        {
            Debug.Log("�뽬!");
            //rbody.velocity = new Vector2(axisH * dash, rbody.velocity.y);
            rbody.AddForce(new Vector2(dash * axisH, 0), ForceMode2D.Impulse);
            goDash = false;



        }

        if (onGround)
        {
            //����� �´������ ��

            if (axisH == 0)
                nowAnime = "PlayerIdle";

            else
                nowAnime = "PlayerRun";

        }
        else
        {
            //���߿� ���� �� ���� �ִϸ��̼�
            nowAnime = jumpAnime;
        }

        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime); //�ִϸ��̼� ��� 
        }


    }

    //���� Ʈ���� on
    public void Jump()
    {
        goJump = true; //���� �÷��� Ȱ��ȭ
        Debug.Log("����");
    }

    public void Dash()
    {
        goDash = true;
        Debug.Log("�뽬");

    }
    public void DashFalse()
    {
        goDash = false;
    }

    //p1���� p2������ ������ ����Ѵ�. �� ����� �� �̷��� �Ǵ����� ���ذ� ��ƴ� ����
    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;

        if (axisH != 0 || axisV != 0)
        {
            //p2�� p1�� ���� ���ϱ�(������ 0���� �ϱ� ����)
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;

            //��ũź��Ʈ �Լ��� ���� ���ϱ�. �ٵ� � ������ ����Ǵ� �Լ���?
            float rad = Mathf.Atan2(dy, dx);

            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }
        return angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("���� �浹");
            //�������� �޴´�
            GetDamage(collision.gameObject);
        }
        if (collision.gameObject.tag == "Parry")
        {
            Debug.Log("���� �浹");
            //�������� �޴´�
            GetDamage(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")        // �� Ʈ���� �����Ѱ͵� �־ Ʈ���� �浹�� ��������ϴ�.
        {
            Debug.Log("���� �浹");
            //�������� �޴´�
            GetDamage(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Dead")       // �� ������ ������ �� dead������Ʈ Ʈ���� �ߵ�
        {
            Debug.Log("���ۿ� ����");
            // �ӽ�
            GetDamage(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Goal")     // clear ������Ʈ�� ������� ����Ŭ����
        {
            Debug.Log("���� Ŭ����");
            gameState = "gameclear";
        }

        if (collision.gameObject.tag == "Parry")
        {
            Debug.Log("�и� ����");
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);

        }
    }

    //�浹���� �� hp�� ���İ��� ���̴°� ����
    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            gameObject.layer = 11; //PlayerDamaged ���̾�� �ٲ㼭 �ǰ����� ���ش�.
            Debug.Log("�� ������ �Լ� �ߵ�");
            hp--;
            PlayerPrefs.SetInt("PlayerHP", hp); //���� hp ����
            if (hp > 0)
            {
                Debug.Log("ü���� 0���� Ŭ �� �� ������ �Լ� �ߵ�");
                //�̵� ����
                rbody.velocity = new Vector2(0, 0);
                animator.Play(hitAnime);
                inDamage = true;
                Invoke("DamageEnd", 1f);
            }
            else
            {
                Debug.Log("���ӿ��� �Լ� ȣ��");
                GameOver();
            }
        }
    }

    void DamageEnd()
    {
        inDamage = false;
        gameObject.layer = 6; //�÷��̾� ���̾�� ��ȯ
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    //�Լ� ȣ���� �Ǵµ� �� �Լ� ������ �ȵ�?
    void GameOver()
    {
        Debug.Log("���ӿ���");
        //���ӿ����� �����
        gameState = "gameover";
        GetComponent<CapsuleCollider2D>().enabled = false; //ĸ�� �ݶ��̴��� ��Ŭ �ݶ��̴��� �����س��� �ȵȴٰ� �ϰ� �־��� ����
        rbody.velocity = new Vector2(0, 0);
        rbody.gravityScale = 1;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        GetComponent<Animator>().Play(deadAnime);
        //�÷��̾� ĳ���Ͱ� ���� ������ ������ �����ϴ�
        Destroy(gameObject, 1.0f);
    }

    public void DownJump()
    {
        downJump = true;
        Debug.Log("�ٿ� ����");

    }

    public void Parry()
    {
        isParry = true;
        GetComponent<CircleCollider2D>().enabled = true;

        Debug.Log("�и�");

    }

    public void ParryEnd()
    {
        isParry = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Debug.Log("�и� ��");
    }
    //Ŭ���� �������ٰ� public bool isParry = false; �߰�
    //BoxCollider2D�� �߰��ؼ� Exclude Layer�� Everything üũ �� Parry üũ�ؼ� Parry���� �����ϰ�
}
