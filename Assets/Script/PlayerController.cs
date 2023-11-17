using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;                //�¿� ����Ű �Է�
    public float speed = 3.0f;         //�̵��ӵ�

    public float jump = 5.0f;          //������
    public LayerMask groundLayer;       //���� ������ ���̾�
    bool goJump = false;               //����Ű �Է»���
    bool onGround = false;             //����� ���˻���
    
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
    string nowAnime = "";
    string oldAnime = "";

    bool isMoving = false;

    public static string gameState = "playing";
    public float angleZ; //ȸ���� ����
 
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
        
    }

    // Update is called once per frame
    // GetKeyDown�� GetKey�� �ٲٴ°� ��������
    void Update()
    {
        if (gameState != "playing")
            return;

        //���� ���� �Է� ->GetKeyDown���� ��� �ٲٴ� �� ��������
        if(isMoving == false)
        {
           axisH = Input.GetAxisRaw("Horizontal");
        }

        //ĳ���� ���� ����
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //������ �̵�
            Debug.Log("������ �̵�");
            transform.localScale = new Vector2(1, 1);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //���� �̵�
            Debug.Log("���� �̵�");
            transform.localScale = new Vector2(-1, 1); //�¿� ����
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("�� �����鼭 �߻�");
            nowAnime = shootstraightAnime;
            animator.Play(nowAnime);
          
        }

        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("������ �̵��ϸ鼭 �߻�");
            //transform.localScale = new Vector2(1, 1);
            nowAnime = runshootstraightAnime;
            animator.Play(nowAnime);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            nowAnime = runAnime;
            animator.Play(nowAnime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("���� �̵��ϸ鼭 �߻�");
            //transform.localScale = new Vector2(-1, 1);
            nowAnime = runshootstraightAnime;
            animator.Play(nowAnime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.Z))
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("���� ����");
            nowAnime = aimupAnime;
            animator.Play(nowAnime);
         }
        //�� ����Ű���� ���� ���� �� �ִϸ��̼� �ٲٱ�
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("���� ����Ű ��");
            nowAnime = stopAnime;
            animator.Play(nowAnime);
        }
        //���� ���鼭 ���ÿ� z�� ������ ��
        //if���� GetKeyDown�� �� �� ���� �� �����ӿ� Ű �� ���� �� �Է��ߴ��� �˻��ϱ⿡ ������ ��ƴ�.
        if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.UpArrow))
        {
            nowAnime = shootupAnime;
            animator.Play(nowAnime);
            Debug.Log("������Ű, ZŰ ����");
            
        }
       //�̷��� if���� ���� ���� �þ�°� �³�????
       else if (Input.GetKeyUp(KeyCode.Z) && Input.GetKey(KeyCode.UpArrow))
        {
            nowAnime = aimupAnime;
            animator.Play(nowAnime);
            Debug.Log("������Ű, ZŰ ��");
        }
        //�Ʒ�����Ű�� ������ �� �� �ִϸ��̼ǿ��� ��������Ʈ ��ġ�� �� �ȸ´� ������ ������ �����ؾ���
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            nowAnime = duckidleAnime;
            animator.Play(nowAnime);
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            nowAnime = stopAnime;
            animator.Play(nowAnime);
        }
        if(Input.GetKey(KeyCode.DownArrow)&&Input.GetKeyDown(KeyCode.Z))
        {
            nowAnime = duckshootAnime;
            animator.Play(nowAnime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            nowAnime = duckidleAnime;
            animator.Play(nowAnime);
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
        if (onGround || axisH !=0)
        {
            //ĳ���Ͱ� ���鿡 �ְų� x�� �Է°��� 0�� �ƴ� ��� velocity ����
            rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
        }
        //�� if������ �־��� �� Jump �Լ��� Ȱ��ȭ �ǳ� ĳ���Ͱ� �������� �ʾҴ�.
        if(onGround && goJump)
        {
            Debug.Log("����!");
            Vector2 jumpPw = new Vector2(0, jump);            //������ ���� ����
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);      //�������� ���� ���Ѵ�
            goJump = false;  //���� �÷��� off
                                                                              
        }

        if(onGround)
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
        if(nowAnime !=oldAnime)
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
    
}
