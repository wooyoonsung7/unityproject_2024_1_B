using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowObject : MonoBehaviour
{
    public Transform targetObhect;          //���� 3D ������Ʈ
    public Vector3 offseet;                 //��ġ�� ����
    public Slider slider;                   //����ٴ� SliderUI
    // Update is called once per frame
    void Update()
    {
        if(targetObhect != null && slider != null)
        {   
            //3D ������Ʈ�� ��ġ�� ȭ�� ��ǥ�� ��ȯ
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObhect.position);
            //ȭ�� ��ǥ�� Canvas ��ǥ�� ��ȯ
            RectTransform canvaRext = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvaRext, screenPos, null, out canvasPos);
            //Slider UI ��ġ�� ������Ʈ
            slider.transform.localPosition = canvasPos;
        }
    }
}
