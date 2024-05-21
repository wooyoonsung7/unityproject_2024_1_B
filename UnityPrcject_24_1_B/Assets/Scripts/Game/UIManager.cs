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
        GameManger.OnPointChanged += UpdatePointText;                                       //이벤트 등록
        GameManger .OnBestScoreChanged += UpdateBestScoreText;                     //이벤트 등록
    }

    private void OnDisable()
    {
        GameManger .OnPointChanged -= UpdatePointText;                                      //이벤트 삭제
        GameManger .OnBestScoreChanged -= UpdateBestScoreText;                     //이벤트 삭제
    }

    void UpdatePointText(int newPoint)                                  //함수 이벤트를 만들어서 인수를 설정
    {
        pointText.text = "Points : " + newPoint;
    }

    void UpdateBestScoreText(int newBestScore)                  //함수 이벤트를 만들어서 인수를 설정
    {
        bestscoreText.text = "Best Score : " + newBestScore;
    }
}
 