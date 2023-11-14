using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;                //�¿� ����Ű �Է�
    public float speed = 3.0f;         //�̵��ӵ�

    public float jump = 9.0f;          //������
    public LayerMask groundLayer;       //���� ������ ���̾�
    bool goJump = false;               //����Ű �Է»���
    bool onGround = false;             //����� ���˻���

    //�ִϸ�����
    Animator animator;
    public string stopAnime = "PlayerIdle"; //������ ���� �� �ִϸ��̼�
    public string jumpAnime = "PlayerJump"; //������ �� �ִϸ��̼�
    public string runAnime = "PlayerRun";   //������ �� �ִϸ��̼�
    string nowAnime = "";
    string oldAnime = "";

    bool isMoving = false;

    public static string gameState = "playing";
 
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
    void Update()
    {
        if (gameState != "playing")
            return;

        //���� ���� �Է�
        if(isMoving == false)
        {
           axisH = Input.GetAxisRaw("Horizontal");
        }

        //ĳ���� ���� ����
        if(axisH > 0.0f)
        {
            //������ �̵�
            Debug.Log("������ �̵�");
            transform.localScale = new Vector2(1, 1);
        }
        else if(axisH <0.0f)
        {
            //���� �̵�
            Debug.Log("���� �̵�");
            transform.localScale = new Vector2(-1, 1); //�¿� ����
        }

        //ĳ���� ����
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    //private �� �տ� �پ��־ ���ֺ����� ������ ���� ���� ó���� �̻��ϴ�
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

        //onGround�� ���� ������ �ִ�.
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
