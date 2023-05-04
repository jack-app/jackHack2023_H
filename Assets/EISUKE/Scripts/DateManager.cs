using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    [SerializeField] Exit exit;
    [SerializeField] Image DatePanel;
    [SerializeField] Text dateText;
    int month = 6;
    int date = 23;
    void Start()
    {
        dateText.text = $"{month}月{date}日";
        StartCoroutine(DateFadeOut(1));
    }
    public void SetUpNextDay()
    {
        if(month == 6 && date == 30)
        {
            month++;
            date = 1;
            dateText.text = $"{month}月{date}日";
            StartCoroutine(DateFadeOut(1));
            return;
        }
        date++;
        dateText.text = $"{month}月{date}日";
        StartCoroutine(DateFadeOut(1));
        exit.ToSelect();
        if(month == 7 && date == 7)
        {
            //Endingシーンへ遷移
        }
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
            yield return new WaitForSeconds(4f);
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
