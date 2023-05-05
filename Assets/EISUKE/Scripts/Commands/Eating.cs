using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour
{
    [SerializeField] DateManager dateManager;
    [SerializeField] Text weightText;
    [SerializeField] Slider staminaGauge;
    [SerializeField] GameObject foodsPanel; 
    [SerializeField] GameObject commands; 
    [SerializeField] GameObject taberuButton; 
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject orihimeBody;
    public Button eatingButton{ get; set; } 
    int weight,staminaValue;
    int getWeightValue = 30;
    int staminaUpValue = 30;

    void Start()
    {
        weightText.text = GameDataManager.Instance.weight.ToString()+"kg"; ;
        staminaGauge.value = GameDataManager.Instance.staminaValue;
        foodsPanel.SetActive(false);
    }
    public void OnClickEating()//選択画面の方
    {
        foodsPanel.SetActive(true);
        commands.SetActive(false);
        exitButton.SetActive(true);
    }
    public void OnClickTaberu()//遷移先の方
    {
        taberuButton.SetActive(false);//消す
        GetWeight();
        UpStamina();
        dateManager.SetUpNextDay();
        taberuButton.SetActive(true);
    }
    void GetWeight()
    {
        weight = GameDataManager.Instance.weight + getWeightValue;
        GameDataManager.Instance.weight = weight;
        weightText.text = weight.ToString()+"kg"; //コルーチン入れるのあり
        Vector3 orihimeScale = orihimeBody.transform.localScale;
        orihimeBody.transform.localScale = new Vector3(orihimeScale.x*1.2f, orihimeScale.y*1.2f, orihimeScale.z*1.2f);
    }
    void UpStamina()
    {
        staminaValue = GameDataManager.Instance.staminaValue + staminaUpValue;
        if(staminaValue >= staminaGauge.maxValue)
        {
            staminaValue = (int)staminaGauge.maxValue;
        }
        GameDataManager.Instance.staminaValue = staminaValue;
        staminaGauge.value = staminaValue;
    }
}
