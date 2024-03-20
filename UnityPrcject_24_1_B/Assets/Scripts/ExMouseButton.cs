using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UI를 사용하기 위해서 추가

public class ExMouseButton : MonoBehaviour
{
    // Start is called before the first frame update
        public int Hp = 100;
        public Text textUI;        //UI 글씨 문자열 추가


    // Update is called once per frame
    void Update()         //매 프레임마다 호출 된다.
    {

        textUI.text = "체력 : " + Hp.ToString();   //UI에 체력 표시

        if (Input.GetMouseButtonDown(0)) //마우스 입력이 들어왔을 때
        {
            Hp -= 10;
            Debug.Log("체력 : " + Hp);
            if (Hp < 0)
            {
                textUI.text = "체력 : " + Hp.ToString();
                Destroy(gameObject);
            }
        }
    }
}
    
