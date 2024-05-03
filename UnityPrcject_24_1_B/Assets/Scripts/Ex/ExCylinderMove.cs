using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCylinderMove : MonoBehaviour
{
    public float MoveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�ش� ��ũ��Ʈ�� �پ��ִ� ������Ʈ�� X�� ���̳ʽ� �������� �̵� �Ѵ�.
        // += �� x += 7 <- x = x + 7 ��� ���ִ� ǥ��
        // Vector3�� x,y,z ���� ��Ÿ���� ���� 
        // ������ ���� �ð� (Time.deltaTime) ��� ��ǻ�Ϳ��� �����ϰ� �̵��� ���Ѿ� �ϱ� ������ ���
        // ��ǻ�͸��� �������� �ٸ��� ����
        gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime * MoveSpeed;

        if(gameObject.transform.position.x < -12)       //X�� ��ǥ�� -12 �̸����� �������� 
        {
            gameObject.transform.position += new Vector3(24.0f, 0.0f, 0.0f); //���������� X�� 24��ŭ �̵� 
        }
    }
}
