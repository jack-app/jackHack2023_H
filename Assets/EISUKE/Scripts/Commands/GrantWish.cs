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
    public Button grantWishButton{ get; set; } 
    int bridgeValue, staminaValue;
    int staminaDownValue = 20;
    int bridgeUpValue = 20;


    void Start()
    {
        grantWishButton = GetComponent<Button>();
        bridgeGauge.value = GameDataManager.Instance.bridgeValue;
        negaiPanel.SetActive(false);
    }
    public void OnClickGrantWish()//選択画面の方
    {
        negaiPanel.SetActive(true);
        commands.SetActive(false);
        exitButton.SetActive(true);
    }
    public void OnClickNegai()//遷移先の方
    {
        negaiButton.SetActive(false);//消す
        UpBridge();
        DownStamina();
        dateManager.SetUpNextDay();
        negaiButton.SetActive(true);
    }
    void UpBridge()
    {
        bridgeValue = GameDataManager.Instance.bridgeValue + bridgeUpValue;
        if(bridgeValue >= bridgeGauge.maxValue)
        {
            bridgeValue = (int)bridgeGauge.maxValue;
        }
        GameDataManager.Instance.bridgeValue = bridgeValue;
        bridgeGauge.value = bridgeValue; 
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
