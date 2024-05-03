using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject CircleObject;                                             //���� ������ ������Ʈ 
    public Transform GenTransform;                                             //������ ������ ��ġ ������Ʈ
    public float TimeCheck;                                                             //�ð��� üũ�ϱ� ���� (float) ��
    public bool isGen;                                                                     //���� �Ϸ� üũ (bool) ��
    // Start is called before the first frame update
    void Start()
    {
        GenObject();                                                                        //������ ���۵Ǿ����� �Լ��� ȣ���ؼ� �ʱ�ȭ ��Ų��.
    }

    // Update is called once per frame
    void Update()
    { 
        if (!isGen)
        {
            TimeCheck -= Time.deltaTime;                                    //�� �����Ӹ��� ������ �ð��� ���ش�
            if(TimeCheck < 0)                   
            {
                GameObject Temp = Instantiate(CircleObject);            //�����ø��� ������Ʈ�� ���� �����ش�. (Instantiste)
                Temp. transform.position = GenTransform.position;             //������ ��ġ�� �̵� ��Ų��
                isGen = true;                                                           //Gen�� �Ǿ��ٰ� ture��bool ���� �����Ѵ�.
            }
        }
           
    }
    public void GenObject()
    {
        isGen = false;                                                              //�ʱ�ȭ : isGen�� false (���� ���� �ʾҴ�)
        TimeCheck = 1.0f;                                                       //1���� ���� �������� ���� ��Ű�� ���� �ʱ�ȭ
    }
}
