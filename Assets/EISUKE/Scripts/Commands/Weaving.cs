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
    int fatherValue,staminaValue;
    int staminaDownValue = 20;
    int fatherUpValue = 1;

    void Start()
    {
        fatherGauge.value = GameDataManager.Instance.fatherValue;
        weavingPanel.SetActive(false);
    }
    public void OnClickWeaving()
    {
        weavingPanel.SetActive(true);
        commands.SetActive(false);
        exitButton.SetActive(true);
    }
    public void OnClickHataori()
    {
        hataoriButton.SetActive(false);//消す
        UpFather();
        DownStamina();
        dateManager.SetUpNextDay();
    }
    void UpFather()
    {
        fatherValue = GameDataManager.Instance.fatherValue + fatherUpValue;
        fatherGauge.value = fatherValue; 
        GameDataManager.Instance.fatherValue = fatherValue;
    }
    void DownStamina()
    {
        staminaValue = GameDataManager.Instance.staminaValue - staminaDownValue;
        staminaGauge.value = staminaValue;
        GameDataManager.Instance.staminaValue = staminaValue;
    }
}
