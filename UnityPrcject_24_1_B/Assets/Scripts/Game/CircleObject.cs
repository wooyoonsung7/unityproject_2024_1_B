using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;                     //�巡�� ������ �Ǵ��ϴ� (bool)
    public bool isUsed;                    //��� �Ϸ� �Ǵ��ϴ� (bool)
    Rigidbody2D rigidbody2D;        //2D ��ü�� �ҷ��´�.

    public int index;                         //���� ��ȣ�� �����.
    
    public float EndTime = 0.0f;                            //���� �� �Ӱ� üũ ���� (float)
    public SpriteRenderer spriteRenderer;           //����� ��������Ʈ ���� ��ȯ ��Ű�� ���� ���� ����

    public GameManger gameManager;              //GameManager ���� ����

    void Awake()                                                                         //�����ϱ��� �ҽ� �ܰ迡������ ����
    {
        isUsed = false;                                                                 //��� �Ϸᰡ ���� ���� (ó�� ���)
        rigidbody2D = GetComponent<Rigidbody2D>();             //��ü�� �����´�.
        rigidbody2D.simulated = false;                                        //�����ɶ��� �ùķ����� ���� �ʴ´�.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)                                                        //���Ϸ�� ��ü�� ���̻� ������Ʈ �ϱ� �ʱ� ���ؼ� return �� ���� �ش�.
        return;

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition );        //ȭ�鿡�� -> ���� ������ ��ġ ã���ִ� �Լ� ���
            float leftBorrder = -4.5f + transform.localScale.x / 2f;                                                    //�ִ� �������� �� �� �ִ� ����
            float rightBorrder  = -4.5f + transform.localScale.x / 2f;                                                  //�ִ� ���������� �� �� �ִ� ����

            if (mousePos.x < leftBorrder) mousePos.x = leftBorrder;                                                 //�ִ� �������� �� �� �ִ� ������ �Ѿ��� �ִ� ���� ��ġ�� �����ؼ� �Ѿ�� ���ϰ��Ѵ�.
            if (mousePos.x < rightBorrder) mousePos.x = rightBorrder;                                           //�ִ� ���������� �� �� �ִ� ������ �Ѿ��� �ִ� ���� ��ġ�� �����ؼ� �Ѿ�� ���ϰ��Ѵ�

            mousePos.y = 8;                                                                         
            mousePos.z = 0;
            
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);                                      //�� ������Ʈ�� ��ġ�� ���콺 ��ġ�� �̵� �ȴ�. 0.2f �ӵ��� �̵� �ȴ�.

        }

        if (Input.GetMouseButtonDown(0)) Drag();                        //���콺 ��ư�� ������ �� Drag �Լ� ȣ��
        if (Input.GetMouseButtonUp(0)) Drop();                               //���콺 ��ư�� ������ �� Drop �Լ� ȣ��
    }
    void Drag()
    {
        isDrag = true;                                                      //�巡�� ���� (true)
        rigidbody2D.simulated = false;                           //�巡�� �߿��� ���� ������ �Ͼ�� ���� ���� ���ؼ� (false)
    }
    void Drop()
    {
        isDrag = false;                                                     //�巡�װ� ����
        isUsed = true;                                                    //����� �Ϸ�
        rigidbody2D.simulated = true;                               //���� ���� ����

        GameObject Temp = GameObject.FindWithTag("GameManager");
        if (Temp != null)
        {
            Temp.gameObject.GetComponent<GameManger>() .GenObject();
        }
    }


    public void Used()
    {
        isDrag = false;                             //�巡�װ� ����
        isUsed = true;                             //����� �Ϸ�
        rigidbody2D.simulated = true;    //���� ���� ����
    }

    public void OnTriggerStay2D(Collider2D collision)              //Trigger �浹 ���� ��
    {
        if(collision.tag == "EndLine")                                              //�浹���� ��ü���� TAG �� EndLine �� ��� 
        {
            EndTime += Time.deltaTime;                                          //�����ӽ��۸�ŭ ���� ���Ѽ� �ʸ� �����.

            if (EndTime > 1)                                                              //�浹������ 1�� �Ǿ��� ���
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f);     //������ ó��
            }
            if(EndTime > 3)
            {
                gameManager.EndGame();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EndLine")                                                     //�浹 ��ü�� ���� ��������
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;                                      //���� �������� ����
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)                   //2D �浹�� �Ͼ ���
    {
        if (index >= 7)                                                                             //�غ�� ���� 7��
            return;                                                                                     

        if (collision.gameObject.tag == "Fruit")                                        //�浹 ��ü�� TAG �� Furit �� ���
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>(); //�ӽ÷� Class temp�� �����ϰ� �浹ü�� Class(CircleObject)�� �޾ƿ´�
             
            if(temp.index == index)
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())                  //����Ƽ���� �����ϴ� ������ ID�� �޾ƿͼ� ID�� ���� ���� ����
                {
                    // GameManger ���� �����Լ� ȣ�� 
                    GameObject Temp = GameObject.FindWithTag("GameManager");
                    if (Temp != null)
                    {
                        Temp.gameObject.GetComponent<GameManger>().MergedObject(index, gameObject.transform.position);
                    }
                    Destroy(temp.gameObject);                                   //�浹 ��ü �ı�
                    Destroy(gameObject);                                           //�ڱ� �ڽ� �ı�
                }
            }
        }
    }


}
