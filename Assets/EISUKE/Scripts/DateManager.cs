using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    [SerializeField] Exit exit;
    [SerializeField] StatusManager statusManager;
    [SerializeField] EndingManager endingManager;
    [SerializeField] Image DatePanel;
    [SerializeField] Text leftDaysText;
    [SerializeField] Text dateText;
    int month = 6;
    int date = 23;
    int leftDays = 13;
    void Start()
    {
        dateText.text = $"{month}月{date}日";
        StartCoroutine(DateFadeOut(1));
        leftDaysText.text = $"七夕まであと{leftDays}日";
    }
    public void SetUpNextDay()
    {
        SetUpButtons();
        if(month == 6 && date == 30)
        {
            month++;
            date = 1;
            dateText.text = $"{month}月{date}日";
            StartCoroutine(DateFadeOut(1));
            exit.ToSelect();
            return;
        }
        date++;
        dateText.text = $"{month}月{date}日";
        StartCoroutine(DateFadeOut(1));
        exit.ToSelect();
        if(month == 7 && date == 7)
        {
            endingManager.JudgeEnding();
            FadeManager.Instance.LoadScene("Ending", 3.0f);//Endingシーンへ遷移
        }
        leftDays--;
        leftDaysText.text = $"七夕まであと{leftDays}日";
    }
    void SetUpButtons()
    {
        StaminaZero();
        if(GameDataManager.Instance.fatherValue == 4)
        {
            statusManager.WeavingButtonInActive();
        }
        if(GameDataManager.Instance.bridgeValue == 100)
        {
            statusManager.GrantWishButtonInActive();
        }
        if(GameDataManager.Instance.hikoValue == 100)
        {
            statusManager.WritingButtonInActive();
        }
    }
    void StaminaZero()
    {
        if(GameDataManager.Instance.staminaValue < 20)
        {
            statusManager.WeavingButtonInActive();
            statusManager.GrantWishButtonInActive();
            return;
        }
        statusManager.WeavingButtonActive();
        statusManager.GrantWishButtonActive();
    }
    IEnumerator DateFadeOut(int times)
    {
        DatePanel.gameObject.SetActive(true);
        float speed = 0.005f;
        for (int i=0; i < times; i++)
        {
            while (dateText.color.a < 1)
            {
                DatePanel.color = new Color(DatePanel.color.r, DatePanel.color.g, DatePanel.color.b, DatePanel.color.a + speed);
                dateText.color = new Color(dateText.color.r, dateText.color.g, dateText.color.b, dateText.color.a + speed);
                yield return new WaitForSeconds(speed);
            }
            yield return new WaitForSeconds(2f);
            while (dateText.color.a > 0)
            {
                DatePanel.color = new Color(DatePanel.color.r, DatePanel.color.g, DatePanel.color.b, DatePanel.color.a - speed);
                dateText.color = new Color(dateText.color.r, dateText.color.g, dateText.color.b, dateText.color.a - speed);
                yield return new WaitForSeconds(speed);
            }
        }
        DatePanel.gameObject.SetActive(false);
    }
    
}
