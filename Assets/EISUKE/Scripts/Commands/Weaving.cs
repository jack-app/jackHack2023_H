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
    int fatherValue,staminaValue;
    int staminaDownValue = 20;
    int fatherUpValue = 1;

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
        fatherValue = GameDataManager.Instance.fatherValue + fatherUpValue;
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
}
