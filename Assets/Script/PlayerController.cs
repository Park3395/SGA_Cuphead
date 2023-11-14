using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;                //좌우 방향키 입력
    public float speed = 3.0f;         //이동속도

    public float jump = 9.0f;          //점프력
    public LayerMask groundLayer;       //착지 가능한 레이어
    bool goJump = false;               //점프키 입력상태
    bool onGround = false;             //지면과 접촉상태

    //애니메이터
    Animator animator;
    public string stopAnime = "PlayerIdle"; //가만히 있을 때 애니메이션
    public string jumpAnime = "PlayerJump"; //점프할 때 애니메이션
    public string runAnime = "PlayerRun";   //움직일 때 애니메이션
    string nowAnime = "";
    string oldAnime = "";

    bool isMoving = false;

    public static string gameState = "playing";
 
    // Start is called before the first frame update
    void Start()
    {
        // RigidBody 2D 컴포넌트 정보 가져오기
        rbody = this.GetComponent<Rigidbody2D>();
   

        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;

        //게임 상태(플레이 중)
        gameState = "playing";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState != "playing")
            return;

        //수평 방향 입력
        if(isMoving == false)
        {
           axisH = Input.GetAxisRaw("Horizontal");
        }

        //캐릭터 방향 조절
        if(axisH > 0.0f)
        {
            //오른쪽 이동
            Debug.Log("오른쪽 이동");
            transform.localScale = new Vector2(1, 1);
        }
        else if(axisH <0.0f)
        {
            //왼쪽 이동
            Debug.Log("왼쪽 이동");
            transform.localScale = new Vector2(-1, 1); //좌우 반전
        }

        //캐릭터 점프
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    //private 가 앞에 붙어있어서 없애봤지만 여전히 착지 판정 처리가 이상하다
    void FixedUpdate()
    {
        if (gameState != "playing")
            return;
        //착지 판정 처리
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 1.0f), groundLayer);
        
        //이 if문이 있을 때 플레이어 캐릭터가 움직이긴 하나 캐릭터가 엎어졌다.
        //Rigidbody 2D의 Constraints의 Freeze Rotation의 z축을 체크하자 캐릭터가 엎어지진 않았으나 의도치않게 가속도가 붙는다.
        if (onGround || axisH !=0)
        {
            //캐릭터가 지면에 있거나 x축 입력값이 0이 아닐 경우 velocity 변경
            rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);
        }
        //이 if문까지 넣었을 때 Jump 함수가 활성화 되나 캐릭터가 점프하진 않았다.
        if(onGround && goJump)
        {
            Debug.Log("점프!");
            Vector2 jumpPw = new Vector2(0, jump);            //점프를 위한 벡터
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);      //순간적인 힘을 가한다
            goJump = false;  //점프 플래그 off
                                                                              
        }

        //onGround에 뭔가 문제가 있다.
        if(onGround)
        {
            //지면과 맞닿아있을 때
            if (axisH == 0)
                nowAnime = "PlayerIdle";
            
            else
                nowAnime = "PlayerRun";
        }
        else
        {
            //공중에 있을 때 점프 애니메이션
            nowAnime = jumpAnime; 
        }
        if(nowAnime !=oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime); //애니메이션 재생 
        }
       
    }

    //점프 트리거 on
    public void Jump()
    {
        goJump = true; //점프 플래그 활성화
        Debug.Log("점프");
    }

    
}
