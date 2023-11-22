using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;                //좌우 방향키 입력
    float axisV = 0.0f;                
    public float speed = 4.0f;         //이동속도, 3.0f -> 4.0f로 변경

    public float jump = 5.0f;          //점프력
    public float dash = 50.0f;          //대쉬력
    public LayerMask groundLayer;       //착지 가능한 레이어
    bool goJump = false;               //점프키 입력상태
    bool onGround = false;             //지면과 접촉상태
    bool goDash = false;               //대쉬 입력 상태
    
    //애니메이터
    Animator animator;
    public string stopAnime = "PlayerIdle"; //가만히 있을 때 애니메이션
    public string jumpAnime = "PlayerJump"; //점프할 때 애니메이션
    public string runAnime = "PlayerRun";   //움직일 때 애니메이션
    public string aimupAnime = "PlayerAimUp"; //위를 볼 때 애니메이션
    public string shootstraightAnime = "PlayerShootStraight"; //직선방향 발사 애니메이션
    public string shootupAnime = "PlayerShootUp"; //윗방향 발사 애니메이션
    public string runshootstraightAnime = "PlayerRunShootStraight"; //달리면서 직선방향 발사 애니메이션
    public string duckAnime = "PlayerDuck"; //아래방향키를 눌렀을 때 애니메이션
    public string duckidleAnime = "PlayerDuckIdle";//아래방향키를 계속 누르고 있을 때의 애니메이션
    public string duckshootAnime = "PlayerDuckShoot"; //수그린 상태에서 발사할 때 애니메이션
    public string peashooterspawnanime = "PeaShooterSpawn"; //장난감 총 발사될 때 애니메이션
    public string rundiagonlaupAnime = "PlayerRunDiagonalUp"; //움직이면서 대각선 조준할때나 대각선 발사할 때 애니메이션
    public string dashAnime = "PlayerDash";
    public string dustAnime = "PlayerDust"; //대쉬할 때 사라지는 애니메이션
    public string hitAnime = "PlayerHit";   //맞았을 때 애니메이션

    string nowAnime = "";
    string oldAnime = "";

    bool isMoving = false;

    public static string gameState = "playing";
    public float angleZ = -90.0f; //회전
    public static int hp = 3;
    bool inDamage = false;
 
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
    // GetKeyDown을 GetKey로 바꾸는게 맞을수도
    void Update()
    {
        if (gameState != "playing")
            return;

        //수평 방향 입력 ->GetKeyDown으로 모두 바꾸는 게 나을수도
        if(isMoving == false)
        {
           axisH = Input.GetAxisRaw("Horizontal");
           axisV = Input.GetAxisRaw("Vertical");
        }
        //키 입력을 통해 이동각도를 구하기
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);

       

        //캐릭터 방향 조절
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //오른쪽 이동
            Debug.Log("오른쪽 이동");
            transform.localScale = new Vector2(1, 1);
            //나는 8방향 발사보단 8방향 애니메이션을 만들려고 했는데 왜 8방향 발사가 됨?
            
        }
        
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            // 우대각 방향
            Debug.Log("우대각");
            nowAnime = rundiagonlaupAnime;
            animator.Play(nowAnime);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //왼쪽 이동
            Debug.Log("왼쪽 이동");
            transform.localScale = new Vector2(-1, 1); //좌우 반전
        }

        if(Input.GetKey(KeyCode.LeftArrow)&&Input.GetKey(KeyCode.UpArrow))
        {
            //좌대각 방향
            Debug.Log("좌대각");
            nowAnime = rundiagonlaupAnime;
            animator.Play(nowAnime);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("서 있으면서 발사");
            nowAnime = shootstraightAnime;
            animator.Play(nowAnime);
          
        }
        if(Input.GetKeyUp(KeyCode.Z))
        {
            Debug.Log("z키에서 손 땜");
            nowAnime = stopAnime;
            animator.Play(nowAnime);

        }

        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Z) && axisV ==0)
        {
            Debug.Log("오른쪽 이동하면서 발사");
            transform.localScale = new Vector2(1, 1);
            nowAnime = runshootstraightAnime;
            animator.Play(nowAnime);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            nowAnime = runAnime;
            animator.Play(nowAnime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Z) && axisV == 0)
        {
            Debug.Log("왼쪽 이동하면서 발사");
            transform.localScale = new Vector2(-1, 1);
            nowAnime = runshootstraightAnime;
            animator.Play(nowAnime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.Z))
        {
            nowAnime = runAnime;
            animator.Play(nowAnime);
        }


            //캐릭터 점프
            if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //윗 방향키를 눌렀을 때 위쪽을 보는 애니메이션 실행(애니메이션 수정 필수)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("위쪽 방향");
            nowAnime = aimupAnime;
            animator.Play(nowAnime);
         }
        //윗 방향키에서 손을 뗐을 때 애니메이션 바꾸기
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("윗 방향키 손 땜");
            nowAnime = stopAnime;
            animator.Play(nowAnime);
        }

        //위를 보면서 동시에 z를 눌렀을 때
        //if문에 GetKeyDown을 두 개 쓰면 한 프레임에 키 두 개를 다 입력했는지 검사하기에 구현이 어렵다.
        //윗방향 발사
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Z) && axisH == 0)
        {
            nowAnime = shootupAnime;
            animator.Play(shootupAnime);
            Debug.Log("윗방향키, Z키 누름");
            
        }
       //이렇게 if문이 수도 없이 늘어나는게 맞나????
       if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.Z)  )
        {
            nowAnime = aimupAnime;
            animator.Play(nowAnime);
            Debug.Log("윗방향키, Z키 땜");       
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Z))
        {
            //우대각 발사
            Debug.Log("우대각 발사");
            nowAnime = rundiagonlaupAnime;
            animator.Play(nowAnime);
        }

        //아래방향키를 눌렀을 때 이 애니메이션에서 스프라이트 위치가 잘 안맞는 문제가 있으니 수정해야함
        if (Input.GetKeyDown(KeyCode.DownArrow))
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
        //대쉬, x키를 눌렀을 때 대쉬 애니메이션을 그냥 블링크로 바꾸자
        if(Input.GetKeyDown(KeyCode.X))
        {
            Dash();
            nowAnime = dustAnime;
            animator.Play(nowAnime);
            
        }



        //z키를 눌렀을 때 발사하는 애니메이션, 인풋매니저 설정 안바꿔서 임시로 z
        /*
        if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("z키 누름");
            nowAnime = shootstraightAnime;
            animator.Play(nowAnime);
        }
        //z키에서 뗐을 때 애니메이션 바꾸기, 인풋매니저 설정 안바꿔서 임시로 z
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Debug.Log("z키 뗌");
            nowAnime = stopAnime;
            animator.Play(nowAnime);
        }*/


    }
    //private 가 앞에 붙어있어서 없애봤지만 여전히 착지 판정 처리가 이상하다->linecast의 y축 값을 조정하니 판정 처리가 괜찮아졌다.
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
        //이 if문을 넣었을 때 대쉬 함수와 이 if문이 활성화 되긴 하나 대쉬가 되진 않았다 대쉬의 기본값을 크게 늘려주자 대쉬를 했다..
        //대쉬를 연속적으로 못하게 하고 싶긴하지만 나중에 시간 날때 구현하자.
        if(goDash)
        {
            Debug.Log("대쉬!");
            //rbody.velocity = new Vector2(axisH * dash, rbody.velocity.y);
            rbody.AddForce(new Vector2(dash * axisH, 0), ForceMode2D.Impulse);
            goDash = false;



        }

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

    public void Dash()
    {
        goDash = true;
        Debug.Log("대쉬");
        
    }
    public void DashFalse()
    { 
        goDash = false; 
    }

    //p1에서 p2까지의 각도를 계산한다. 이 계산이 왜 이렇게 되는지는 이해가 어렵다 아직
    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;

        if(axisH != 0 || axisV != 0)
        {
            //p2와 p1의 차를 구하기(원점을 0으로 하기 위해)
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;

            //아크탄젠트 함수로 라디안 구하기. 근데 어떤 식으로 적용되는 함수임?
            float rad = Mathf.Atan2(dy, dx);

            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }
        return angle;
    }
}
