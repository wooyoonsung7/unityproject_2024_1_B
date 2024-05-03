using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGen : MonoBehaviour
{
    public GameObject item;                 //���� ������Ʈ ������ ����
    public float checkTime;                 //�ð��� üũ ����

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;        //�� ������ �ð��� ���ؼ� �׾Ƽ�
        if(checkTime > 2.0f)                //2�ʰ� �������� 
        {
            GameObject Temp = Instantiate(item);        //������Ʈ�� �����ϴ� �Լ� <Instantiate> ,GameObject�� �ӷ� ������ Temp ���� ���� �Ѵ�.
            Temp.transform.position += new Vector3(0.0f, Random.Range(0, 4), 0.0f); //�������� 0,3�� ������ ��ġ�� �ٲ��ش�. 
            Destroy(Temp, 20.0f);           //������Ʈ�� 20���Ŀ� �ı� 
            checkTime = 0.0f;               //2�ʸ��� �������� �����ϱ����ؼ� �ʱ�ȭ
        }    
    }
}
