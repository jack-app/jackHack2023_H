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
    int hikoValue;
    int hikoUpValue = 10;


    void Start()
    {
        hikoGauge.value = GameDataManager.Instance.hikoValue;
        writingPanel.SetActive(false);
    }
    public void OnClickWriting()
    {
        writingPanel.SetActive(true);
        commands.SetActive(false);
        exitButton.SetActive(true);
    }
    public void OnClickTegami()
    {
        tegamiButton.SetActive(false);//消す
        UpHiko();
        dateManager.SetUpNextDay();
    }
    void UpHiko()
    {
        hikoValue = GameDataManager.Instance.hikoValue + hikoUpValue;
        hikoGauge.value = hikoValue; 
        GameDataManager.Instance.hikoValue = hikoValue;
    }
}
