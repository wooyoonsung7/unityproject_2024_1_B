using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowObject : MonoBehaviour
{
    public Transform targetObhect;          //따라갈 3D 오브젝트
    public Vector3 offseet;                 //위치값 보정
    public Slider slider;                   //따라다닐 SliderUI
    // Update is called once per frame
    void Update()
    {
        if(targetObhect != null && slider != null)
        {   
            //3D 오브젝트의 위치를 화면 좌표로 변환
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObhect.position);
            //화면 좌표를 Canvas 좌표로 변환
            RectTransform canvaRext = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvaRext, screenPos, null, out canvasPos);
            //Slider UI 위치를 업데이트
            slider.transform.localPosition = canvasPos;
        }
    }
}
