using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrantWish : MonoBehaviour
{
    [SerializeField] DateManager dateManager;
    [SerializeField] Slider bridgeGauge;
    [SerializeField] Slider staminaGauge;
    [SerializeField] GameObject negaiPanel; 
    [SerializeField] GameObject commands; 
    [SerializeField] GameObject negaiButton;
    [SerializeField] GameObject exitButton;
    int bridgeValue, staminaValue;
    int staminaDownValue = 20;
    int bridgeUpValue = 20;


    void Start()
    {
        bridgeGauge.value = GameDataManager.Instance.bridgeValue;
        negaiPanel.SetActive(false);
    }
    public void OnClickGrantWish()
    {
        negaiPanel.SetActive(true);
        commands.SetActive(false);
        exitButton.SetActive(true);
    }
    public void OnClickNegai()
    {
        negaiButton.SetActive(false);//消す
        UpBridge();
        DownStamina();
        dateManager.SetUpNextDay();
    }
    void UpBridge()
    {
        bridgeValue = GameDataManager.Instance.bridgeValue + bridgeUpValue;
        bridgeGauge.value = bridgeValue; 
        GameDataManager.Instance.bridgeValue = bridgeValue;
    }
    void DownStamina()
    {
        staminaValue = GameDataManager.Instance.staminaValue - staminaDownValue;
        staminaGauge.value = staminaValue;
        GameDataManager.Instance.staminaValue = staminaValue;
    }
}
