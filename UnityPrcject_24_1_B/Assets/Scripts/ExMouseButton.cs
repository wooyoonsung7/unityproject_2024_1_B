using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               //UI�� ����ϱ����ؼ� �߰� 

public class ExMouseButton : MonoBehaviour
{
    public int Hp = 100;
    public Text text;           //UI �۾� ���ڿ� �߰�

    // Update is called once per frame
    void Update()           //�� �����Ӹ��� ȣ�� �ȴ�.
    {
        //Debug.Log("ü�� : " + Hp);       //ü��Ȯ���� ���� Debug.Log �Լ�

        if (Input.GetMouseButtonDown(0)) //���콺 �Է��� ������ ��  
        {
            Hp -= 10;
            Debug.Log("ü�� : " +  Hp);       //ü��Ȯ���� ���� Debug.Log �Լ� 
            if( Hp <= 0 )        //HP�� 0���Ϸ� ��������
            {
                Destroy(gameObject);        //�� ������Ʈ�� �ı��Ѵٴ� �Լ�
            }
        }
    }
}
