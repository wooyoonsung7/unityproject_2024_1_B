using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{

    public static AchievementManager instance;          //�̱��� ȭ
    public List<Achievement> achievements;              //Achievement Ŭ������ List�� ����

    public Text[] AchievementTexts = new Text[4];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);              //�ٸ� Scene������ ���� �ϱ� ���ؼ� �ı� ���� �ʰ� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateAchievementUI()
    {
        AchievementTexts[0].text = achievements[0].name;
        AchievementTexts[1].text = achievements[0].description;
        AchievementTexts[2].text = $"{achievements[0].currentProgress}/{achievements[0].goal}";
        AchievementTexts[3].text = achievements[0].isUnlocked? "�޼�" : "�̴޼�";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddProgress("����", 1);
            UpdateAchievementUI();
        }
    }


    public void AddProgress(string achievementName, int amount) //���� ���� ��Ȱ ���� �Լ�
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);         //�μ����� �޾ƿ� �̸����� ���� ����Ʈ���� ã�Ƽ� ��ȯ
        if(achievement != null )                                                            //��ȯ�� ������ ���� ���
        {
            achievement.AddProgress(amount);                                                //���α׷����� ���� ��Ų��.
        }
    }

    //���ο� ���� �߰� �Լ�
    public void AddAchievement(Achievement achievement)
    {
        //Achievement temp = new Achievement("�̸�", "����", 5);
        achievements.Add(achievement);                              //List�� ���� �߰�
    }

    void Start()
    {
            
        
    }
}
