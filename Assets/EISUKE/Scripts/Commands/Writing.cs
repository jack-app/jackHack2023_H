using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Writing : MonoBehaviour
{
    [SerializeField] DateManager dateManager;
    [SerializeField] Slider hikoGauge;
    [SerializeField] GameObject writingPanel; 
    [SerializeField] GameObject commands; 
    [SerializeField] GameObject tegamiButton;
    [SerializeField] GameObject exitButton;
    public Button writingButton{ get; set; } 
    int hikoValue;
    int hikoUpValue = 5;


    void Start()
    {
        hikoGauge.value = GameDataManager.Instance.hikoValue;
        writingPanel.SetActive(false);
    }
    public void OnClickWriting()//選択画面の方
    {
        writingPanel.SetActive(true);
        commands.SetActive(false);
        exitButton.SetActive(true);
    }
    public void OnClickTegami()//遷移先の方
    {
        tegamiButton.SetActive(false);//消す
        UpHiko();
        dateManager.SetUpNextDay();
        tegamiButton.SetActive(true);
    }
    void UpHiko()
    {
        hikoValue = GameDataManager.Instance.hikoValue + hikoUpValue;
        if(hikoValue >= hikoGauge.maxValue)
        {
            hikoValue = (int)hikoGauge.maxValue;
        }
        GameDataManager.Instance.hikoValue = hikoValue;
        hikoGauge.value = hikoValue; 
    }
}
