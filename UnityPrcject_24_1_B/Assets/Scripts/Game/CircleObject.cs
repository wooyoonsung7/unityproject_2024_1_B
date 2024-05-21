using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;                     //드래그 중인지 판단하는 (bool)
    public bool isUsed;                    //사용 완료 판단하는 (bool)
    Rigidbody2D rigidbody2D;        //2D 강체를 불러온다.

    public int index;                         //과일 번호를 만든다.
    
    public float EndTime = 0.0f;                            //종료 선 ㅣ간 체크 변수 (float)
    public SpriteRenderer spriteRenderer;           //종료시 스프라이트 색을 변환 시키기 위해 접근 선언

    public GameManger gameManager;              //GameManager 접근 선언

    void Awake()                                                                         //시작하기전 소스 단계에서부터 셋팅
    {
        isUsed = false;                                                                 //사용 완료가 되지 않음 (처움 사용)
        rigidbody2D = GetComponent<Rigidbody2D>();             //강체를 가져온다.
        rigidbody2D.simulated = false;                                        //생성될때는 시뮬레이팅 되지 않는다.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)                                                        //사용완료된 물체를 더이상 업데이트 하기 않기 위해서 return 로 돌려 준다.
        return;

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition );        //화면에서 -> 월드 포지션 위치 찾아주는 함수 사용
            float leftBorrder = -4.5f + transform.localScale.x / 2f;                                                    //최대 왼쪽으로 갈 수 있는 범위
            float rightBorrder  = -4.5f + transform.localScale.x / 2f;                                                  //최대 오른쪽으로 갈 수 있는 범위

            if (mousePos.x < leftBorrder) mousePos.x = leftBorrder;                                                 //최대 왼쪽으로 갈 수 있는 범위를 넘어갈경우 최대 범위 위치를 대입해서 넘어가지 못하게한다.
            if (mousePos.x < rightBorrder) mousePos.x = rightBorrder;                                           //최대 오른쪽으로 갈 수 있는 범위를 넘어갈경우 최대 범위 위치를 대입해서 넘어가지 못하게한다

            mousePos.y = 8;                                                                         
            mousePos.z = 0;
            
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);                                      //이 오브젝트의 위치는 마우스 위치로 이동 된다. 0.2f 속도로 이동 된다.

        }

        if (Input.GetMouseButtonDown(0)) Drag();                        //마우스 버튼이 눌렸을 때 Drag 함수 호출
        if (Input.GetMouseButtonUp(0)) Drop();                               //마우스 버튼이 눌렸을 때 Drop 함수 호출
    }
    void Drag()
    {
        isDrag = true;                                                      //드래그 시작 (true)
        rigidbody2D.simulated = false;                           //드래그 중에는 물리 현상이 일어나는 것을 막기 위해서 (false)
    }
    void Drop()
    {
        isDrag = false;                                                     //드래그가 종료
        isUsed = true;                                                    //사용이 완료
        rigidbody2D.simulated = true;                               //물리 현상 시작

        GameObject Temp = GameObject.FindWithTag("GameManager");
        if (Temp != null)
        {
            Temp.gameObject.GetComponent<GameManger>() .GenObject();
        }
    }


    public void Used()
    {
        isDrag = false;                             //드래그가 종료
        isUsed = true;                             //사용이 완료
        rigidbody2D.simulated = true;    //물리 현상 시작
    }

    public void OnTriggerStay2D(Collider2D collision)              //Trigger 충돌 중일 때
    {
        if(collision.tag == "EndLine")                                              //충돌중인 물체가의 TAG 가 EndLine 일 경우 
        {
            EndTime += Time.deltaTime;                                          //프레임시작만큼 누적 시켜서 초를 만든다.

            if (EndTime > 1)                                                              //충돌진행이 1초 되었을 경우
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f);     //빨강색 처리
            }
            if(EndTime > 3)
            {
                gameManager.EndGame();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EndLine")                                                     //충돌 물체가 빠져 나갔을때
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;                                      //기존 색상으로 변경
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)                   //2D 충돌이 일어날 경우
    {
        if (index >= 7)                                                                             //준비된 과일 7개
            return;                                                                                     

        if (collision.gameObject.tag == "Fruit")                                        //충돌 물체의 TAG 가 Furit 일 경우
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>(); //임시로 Class temp를 선언하고 충돌체의 Class(CircleObject)를 받아온다
             
            if(temp.index == index)
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())                  //유니티에서 지원하는 고유의 ID를 받아와서 ID가 다음 과일 생성
                {
                    // GameManger 에서 생성함수 호출 
                    GameObject Temp = GameObject.FindWithTag("GameManager");
                    if (Temp != null)
                    {
                        Temp.gameObject.GetComponent<GameManger>().MergedObject(index, gameObject.transform.position);
                    }
                    Destroy(temp.gameObject);                                   //충돌 물체 파괴
                    Destroy(gameObject);                                           //자기 자신 파괴
                }
            }
        }
    }


}
