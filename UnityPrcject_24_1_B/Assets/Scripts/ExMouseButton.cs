using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UI�� ����ϱ� ���ؼ� �߰�

public class ExMouseButton : MonoBehaviour
{
    // Start is called before the first frame update
        public int Hp = 100;
        public Text textUI;        //UI �۾� ���ڿ� �߰�


    // Update is called once per frame
    void Update()         //�� �����Ӹ��� ȣ�� �ȴ�.
    {

        textUI.text = "ü�� : " + Hp.ToString();   //UI�� ü�� ǥ��

        if (Input.GetMouseButtonDown(0)) //���콺 �Է��� ������ ��
        {
            Hp -= 10;
            Debug.Log("ü�� : " + Hp);
            if (Hp < 0)
            {
                textUI.text = "ü�� : " + Hp.ToString();
                Destroy(gameObject);
            }
        }
    }
}
    
