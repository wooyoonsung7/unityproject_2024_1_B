using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text bestscoreText;

    private void OnEnable()
    {   
        GameManger.OnPointChanged += UpdatePointText;                                       //�̺�Ʈ ���
        GameManger .OnBestScoreChanged += UpdateBestScoreText;                     //�̺�Ʈ ���
    }

    private void OnDisable()
    {
        GameManger .OnPointChanged -= UpdatePointText;                                      //�̺�Ʈ ����
        GameManger .OnBestScoreChanged -= UpdateBestScoreText;                     //�̺�Ʈ ����
    }

    void UpdatePointText(int newPoint)                                  //�Լ� �̺�Ʈ�� ���� �μ��� ����
    {
        pointText.text = "Points : " + newPoint;
    }

    void UpdateBestScoreText(int newBestScore)                  //�Լ� �̺�Ʈ�� ���� �μ��� ����
    {
        bestscoreText.text = "Best Score : " + newBestScore;
    }
}
 