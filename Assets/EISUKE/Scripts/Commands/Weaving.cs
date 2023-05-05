using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weaving : MonoBehaviour
{
    [SerializeField] DateManager dateManager;
    [SerializeField] Slider fatherGauge;
    [SerializeField] Slider staminaGauge;
    [SerializeField] GameObject weavingPanel; 
    [SerializeField] GameObject commands; 
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject hataoriButton;
    public Button weavingButton{ get; set; }  
    int successNum;
    int fatherValue,staminaValue;
    int staminaDownValue = 20;

    void Start()
    {
        weavingButton = GetComponent<Button>();
        fatherGauge.value = GameDataManager.Instance.fatherValue;
        weavingPanel.SetActive(false);
    }
    public void OnClickWeaving()//選択画面の方
    {
        weavingPanel.SetActive(true);
        commands.SetActive(false);
        exitButton.SetActive(true);
        SuccessRate();//ここで決めておく
    }
    public void OnClickHataori()//遷移先の方
    {
        hataoriButton.SetActive(false);
        UpFather();
        DownStamina();
        dateManager.SetUpNextDay();
        hataoriButton.SetActive(true);
    }
    void UpFather()
    {
        fatherValue = GameDataManager.Instance.fatherValue + successNum;
        if(fatherValue >= fatherGauge.maxValue)
        {
            fatherValue = (int)fatherGauge.maxValue;
        }
        GameDataManager.Instance.fatherValue = fatherValue;
        fatherGauge.value = fatherValue; 
    }
    void DownStamina()
    {
        staminaValue = GameDataManager.Instance.staminaValue - staminaDownValue;
        if(staminaValue <= staminaGauge.minValue)
        {
            staminaValue = (int)staminaGauge.minValue;
        }
        GameDataManager.Instance.staminaValue = staminaValue;
        staminaGauge.value = staminaValue;
    }
    void SuccessRate()
    {
        int specialSuccessProb = 10;
        int successProb = 70;
        if(EndingManager.Probability(specialSuccessProb))//大成功
        {
            successNum = 2;
            return;
        }
        else if(EndingManager.Probability(successProb))//成功
        {
            successNum = 1;
            return;
        }
        successNum = 0;//失敗
    }
}
