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
    int weight,staminaValue;
    int getWeightValue = 10;
    int staminaUpValue = 20;

    void Start()
    {
        weightText.text = GameDataManager.Instance.weight.ToString()+"kg"; ;
        staminaGauge.value = GameDataManager.Instance.staminaValue;
        foodsPanel.SetActive(false);
    }
    public void OnClickEating()
    {
        foodsPanel.SetActive(true);
        commands.SetActive(false);
        exitButton.SetActive(true);
    }
    public void OnClickTaberu()
    {
        taberuButton.SetActive(false);//消す
        GetWeight();
        UpStamina();
        dateManager.SetUpNextDay();
    }
    void GetWeight()
    {
        weight = GameDataManager.Instance.weight + getWeightValue;
        weightText.text = weight.ToString()+"kg"; 
        GameDataManager.Instance.weight = weight;
    }
    void UpStamina()
    {
        staminaValue = GameDataManager.Instance.staminaValue + staminaUpValue;
        staminaGauge.value = staminaValue;
        GameDataManager.Instance.staminaValue = staminaValue;
    }
}
